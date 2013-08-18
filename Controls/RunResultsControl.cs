using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Guitar.Lib.ViewModels;

namespace Guitar.Controls
{
    public partial class RunResults : UserControl
    {
        private delegate void SetLabelDelegate(Label label, string text);
        private delegate void SetProgressPropertyDelegate(int value);

        public TestRunViewModel ViewModel;
        public TextBoxLogger TextLogger;

        public RunResults()
        {
            ViewModel = new TestRunViewModel();
            InitializeComponent();

            ViewModel.PropertyChanged += ViewModelOnPropertyChanged;

            TextLogger = new TextBoxLogger(errorScreen3);
        }

        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == TestRunViewModel.TestCountProperty)
            {
                progressBar.Invoke(new SetProgressPropertyDelegate(SetProgressMax), ViewModel.TestCount);

                numTestsLabel.Invoke(new SetLabelDelegate(SetLabel), numTestsLabel,
                                        ViewModel.TestCount.ToString(CultureInfo.InvariantCulture));
            }
            else if (propertyChangedEventArgs.PropertyName == TestRunViewModel.TestsFailedProperty)
            {
                numFailuresLabel.Invoke(new SetLabelDelegate(SetLabel), numFailuresLabel,
                                        ViewModel.TestsFailed.ToString(CultureInfo.InvariantCulture));
            }
            else if (propertyChangedEventArgs.PropertyName == TestRunViewModel.TestsCompletedProperty)
            {
                progressBar.Invoke(new SetProgressPropertyDelegate(SetProgressValue), ViewModel.TestsCompleted);
            }
        }

        void SetLabel(Label label, string text)
        {
            label.Text = text;
        }

        void SetProgressValue(int value)
        {
            progressBar.Value = value;
            progressBar.Refresh();
        }

        void SetProgressMax(int value)
        {
            progressBar.Maximum = value;
            progressBar.Refresh();
        }
    }
}
