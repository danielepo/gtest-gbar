using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Guitar.Lib;
using Guitar.Lib.ViewModels;

namespace Guitar
{
    public partial class GuitarForm : Form
    {
        const int DEFAULT_MAX_HISTORY = 5;

        List<string> Failures = new List< string>();
        private bool inWindows;
        private bool gotCommandlinePath = false;
        private bool isTestFail = false;
        private String commmandlinePath;
        private bool closeOnEsc;

        private Dictionary<string, ComboBox> controls;
        
        Configurator configurator;

        private TestOptionsViewModel optionsViewModel;

        public GuitarForm()
        {
            initializeForm();

            testTree.RunRequested += TestTreeOnRunRequested;

            closeOnEsc = false;
        }

        private void TestTreeOnRunRequested(object sender, RunRequestEventArgs runRequestEventArgs)
        {
            runResults1.TextLogger.Clear();
            if (runRequestEventArgs.RunTarget is ITest)
            {
                runResults1.ViewModel.RequestRun(runRequestEventArgs.RunTarget as ITest, runResults1.TextLogger, optionsViewModel);
            }
            else if (runRequestEventArgs.RunTarget is ITestCase)
            {
                runResults1.ViewModel.RequestRun(runRequestEventArgs.RunTarget as ITestCase, runResults1.TextLogger, optionsViewModel);
            }
            else if (runRequestEventArgs.RunTarget is ITestSuite)
            {
                runResults1.ViewModel.RequestRun(runRequestEventArgs.RunTarget as ITestSuite, runResults1.TextLogger, optionsViewModel);
            }
        }

        public GuitarForm(String fileName) : this()
        {
            guitarReceivedAPathToATestExecutable();
            setFileNameInputbox(fileName);
        }
        public GuitarForm(CommandLineParameters parameters) : this()
        {
            if (parameters.testFilePath != "")
            {
                guitarReceivedAPathToATestExecutable();
            }
            setFileNameInputbox(parameters.testFilePath);

            if (parameters.autoCloseTimeout > 0)
            {
                formCloseTimer.Enabled = true;
                formCloseTimer.Interval = parameters.autoCloseTimeout * 1000;
                formCloseTimer.Tick += new System.EventHandler(formCloseTimer_Tick);
            }
            closeOnEsc = parameters.closeOnEsc;
        }
        private void initializeForm(){
            inWindows = (System.Environment.OSVersion.Platform != System.PlatformID.Unix && System.Environment.OSVersion.Platform != System.PlatformID.MacOSX);
            InitializeComponent();

            splitContainer2.Panel1Collapsed = true;

            optionsViewModel = new TestOptionsViewModel();

            startupFolder.DataBindings.Add(new Binding("Text", optionsViewModel,
                                                       TestOptionsViewModel.WorkingDirectoryProperty, false,
                                                       DataSourceUpdateMode.OnPropertyChanged));
            shouldShuffle.DataBindings.Add(new Binding("Checked", optionsViewModel,
                                                       TestOptionsViewModel.ShuffleTestsProperty, false,
                                                       DataSourceUpdateMode.OnPropertyChanged));
            shouldRunDisabled.DataBindings.Add(new Binding("Checked", optionsViewModel,
                                                       TestOptionsViewModel.RunDisabledTestsProperty, false,
                                                       DataSourceUpdateMode.OnPropertyChanged));

            controls = new Dictionary<string, ComboBox>();
            controls.Add(Configurator.SETTING_GTEST_EXES, exeFilename);
            controls.Add(Configurator.SETTING_GTEST_PARAMS, clParams);
            controls.Add(Configurator.SETTING_GTEST_STARTUP_FOLDER, startupFolder);

            configurator = new Configurator(controls);

            //setConfigurationFile();
        }
      
        private void guitarReceivedAPathToATestExecutable()
        {
            gotCommandlinePath = true;
        }
        private void setFileNameInputbox(String filename)
        {
            commmandlinePath = filename;
        }
        
        private void GuitarForm_Load(object sender, EventArgs e)
        {
            configurator.autoloadFromValues();

            if (gotCommandlinePath)
            {
                exeFilename.Text = commmandlinePath;
            }

            goBtn.Enabled = canRun();
            //errorScreen3.Text = configurator.getFilePath();

            if (goBtn.Enabled)
            {
                goBtn_Click(sender, e);
            }
        }
        private void saveConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoNewComboboxesItemsInHistory();
            configurator.saveSettings();
        }
        private void goBtn_Click(object sender, EventArgs e)
        {
        }
        private void autoNewComboboxesItemsInHistory()
        {
            Dictionary<string, ComboBox>.Enumerator en = controls.GetEnumerator();
            while (en.MoveNext())
            {
                putNewItemOnHistorysTop(en.Current.Value);
            }
        }

        private void putNewItemOnHistorysTop(ComboBox cb)
        {
            // Is this an old item selection or a new item
            string selText = cb.Text;

            Boolean isNew = !cb.Items.Contains(selText);
            if (!isNew)
            {
                // remove older reference to same file
                cb.Items.Remove(selText);
            }
            cb.Items.Insert(0, selText);
            cb.SelectedIndex = 0;

            maintainHistoryLength(cb.Items);
        }
        private void maintainHistoryLength(ComboBox.ObjectCollection items)
        {
            if (items.Count > DEFAULT_MAX_HISTORY)
            {
                int lastIndex = items.Count - 1;
                items.RemoveAt(lastIndex);
            }

        }
       
        private void cls()
        {
            //progressBar.Value = 0;
            //failureListBox.Items.Clear();
            //errorScreen3.Text = "";
            //errorScreen3.Refresh();
        }

        private void calibrateProgressBar(int n)
        {
            //Failures.Clear();
            //numTestsLabel.Text = "" + n;
            //numFailuresLabel.Text = "0";
            //failureListBox.Items.Clear();

            //progressBar.Value = 0;
            //progressBar.Minimum = 0;
            //progressBar.Maximum = n;


            //numTestsLabel.Refresh();
            //numFailuresLabel.Refresh();
        }

        private void advanceProgressBar(string testName, string error)
        {
            //if (error != null)
            //{
            //    progressBar.ProgressBarColor = Color.Red;
            //    Failures.Add(error);
            //    numFailuresLabel.Text = "" + Failures.Count;
            //    failureListBox.Items.Add(testName);
            //    failureListBox.SelectedIndex = 0;
            //    failureListBox.Refresh();
            //}
            //else
            //{
            //    progressBar.ProgressBarColor = Color.Green;
            //}

            //progressBar.Value++;
            //progressBar.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog1.ShowDialog();
            if (DialogResult.OK == r)
            {
                testTree.ViewModel.AddSuite(openFileDialog1.FileName);
                exeFilename.Text = openFileDialog1.FileName;
            }
        }

        private void exeFilename_TextChanged(object sender, EventArgs e)
        {
            goBtn.Enabled = canRun();
        }

        private bool canRun()
        {
            bool ret = System.IO.File.Exists(exeFilename.Text);

            if (inWindows)
            {
                ret = ret && (exeFilename.Text.TrimEnd().EndsWith("exe") || exeFilename.Text.TrimEnd().EndsWith("bat"));
            }
            return ret;
        }

        private void failureListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //errorScreen3.Text = Failures[failureListBox.SelectedIndex];
        }

        private void buttonSelectStartupFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string startupPath = Application.StartupPath;
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    dialog.Description = "Select a startup folder";
                    dialog.ShowNewFolderButton = false;
                    dialog.RootFolder = Environment.SpecialFolder.MyComputer;

                    // Select current startup folder
                    if (startupFolder.Text != "")
                    {
                        if (System.IO.Directory.Exists(startupFolder.Text))
                            dialog.SelectedPath = startupFolder.Text;
                    }
                    else
                    {
                        // try to select folder where google test exe is located
                        string strExePath = exeFilename.Text;
                        if (System.IO.File.Exists(strExePath))
                        {           
                            string folder = System.IO.Path.GetDirectoryName(strExePath);
                            dialog.SelectedPath = folder;
                        }
                    }
                    
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string folder = dialog.SelectedPath;
                        startupFolder.Text = folder;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Selection of a startup folder failed (" + exc.Message + ").");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutGuitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Guitar a UI for a Google Test (https://code.google.com/p/gtest-gbar/).  Test status icons are from the silk icon set, courtesy of Mark James of FAMFAMFAM (http://www.famfamfam.com)", "About");
        }



        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            optionsToolStripMenuItem.Checked = splitContainer2.Panel1Collapsed;
            splitContainer2.Panel1Collapsed = !splitContainer2.Panel1Collapsed;
            
        }

        private void formCloseTimer_Tick(object sender, EventArgs e)
        {
            if (!isTestFail)
            {
                Close();
            }
        }

        private void GuitarForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && closeOnEsc)
            {
                Close();
            }
        }
    }
}
