using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Guitar.Lib.GTest
{
    public class GTestExtractor : ITestExtractor
    {
        private readonly bool _async;

        private class ExtractArgs
        {
            public ITestSuite Suite;
        }

        private BackgroundWorker _worker;
        public GTestExtractor(bool async = true)
        {
            _async = async;
            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += WorkerDoWork;
        }

        private void WorkerDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            Extract(doWorkEventArgs.Argument as ExtractArgs);
        }

        private void QueueExtract(ITestSuite suite)
        {
            _worker.RunWorkerAsync(new ExtractArgs() {Suite = suite});

            if(!_async)
            {
                while(_worker.IsBusy)
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        public ITestSuite ExtractFrom(string filePath)
        {
            System.IO.FileInfo info = new FileInfo(filePath);
            ITestSuite suite = GTestTestFactory.BuildTestSuite(info.Name, filePath);

            Extract(new ExtractArgs() {Suite = suite});
            return suite;
        }

        private void Extract(ExtractArgs args)
        {
            GTestTestListParser parser = new GTestTestListParser(args.Suite);
            DataReceivedEventHandler handler = (sender, eventArgs) => parser.ParseLine(eventArgs.Data);
            parser.TestDiscovered += OnTestDiscovered;

            ProcessStartInfo gtestProcInfo = new ProcessStartInfo(args.Suite.RunTarget)
            {
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                UseShellExecute = false,
                Arguments = "--gtest_list_tests"
            };

            Process gtestProc = new Process();
            gtestProc.StartInfo = gtestProcInfo;
            gtestProc.OutputDataReceived += handler;

            gtestProc.Start();
            gtestProc.BeginOutputReadLine();

            while (!gtestProc.HasExited)
            {
                gtestProc.WaitForExit(500);
                if (_worker.CancellationPending)
                {
                    gtestProc.Close();
                    break;
                }
            }

            gtestProc.WaitForExit(); //clear stdout buffer

            gtestProc.OutputDataReceived -= handler;
            parser.TestDiscovered -= OnTestDiscovered;
        }

        public event TestDiscoveredHandler TestDiscovered;

        protected virtual void OnTestDiscovered(ITest test)
        {
            TestDiscoveredHandler handler = TestDiscovered;
            if (handler != null) handler(test);
        }
    }
}
