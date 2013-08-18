using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Guitar.Lib.ViewModels
{
    public class TestOptionsViewModel : ITestSettings, INotifyPropertyChanged
    {
        private string _workingDirectory;
        private bool _shuffleTests;
        private bool _runDisabledTests;

        public const string WorkingDirectoryProperty = "WorkingDirectory";
        public const string ShuffleTestsProperty = "ShuffleTests";
        public const string RunDisabledTestsProperty = "RunDisabledTests";

        public TestOptionsViewModel()
        {
            
        }

        public string WorkingDirectory
        {
            get { return _workingDirectory; }
            set { _workingDirectory = value; OnPropertyChanged(WorkingDirectoryProperty); }
        }

        public bool ShuffleTests
        {
            get { return _shuffleTests; }
            set { _shuffleTests = value; OnPropertyChanged(ShuffleTestsProperty); }
        }

        public bool RunDisabledTests
        {
            get { return _runDisabledTests; }
            set { _runDisabledTests = value; OnPropertyChanged(RunDisabledTestsProperty); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
