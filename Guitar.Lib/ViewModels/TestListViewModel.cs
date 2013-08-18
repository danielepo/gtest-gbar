using System.Collections.Generic;
using System.ComponentModel;
using Guitar.Lib.GTest;

namespace Guitar.Lib.ViewModels
{
    public class TestListViewModel : INotifyPropertyChanged
    {
        public const string SuitesProperty = "Suites";
        public List<ITestSuite> Suites { get; private set; } 

        public TestListViewModel()
        {
            Suites = new List<ITestSuite>();
        }

        public void AddSuite(string filePath)
        {
            GTestExtractor extractor = new GTestExtractor();
            ITestSuite suite = extractor.ExtractFrom(filePath);

            Suites.Add(suite);
            OnPropertyChanged(SuitesProperty);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
