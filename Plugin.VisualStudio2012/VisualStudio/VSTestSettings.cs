using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Guitar.Lib;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;

namespace Plugin.VisualStudio2012.VisualStudio
{
    [XmlRoot(VSTestSettings.SettingsName)]
    public class VSTestSettings : TestRunSettings, ITestSettings
    {
        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(VSTestSettings));
        private string _workingDirectory;
        public const string SettingsName = "Guitar";

        public VSTestSettings() : base(SettingsName)
        {
            
        }

        public string WorkingDirectory
        {
            get { return _workingDirectory; }
            set { _workingDirectory = Environment.ExpandEnvironmentVariables(value); }
        }

        public bool ShuffleTests { get; set; }
        public bool RunDisabledTests { get; set; }

        public override XmlElement ToXml()
        {
            var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, this);
            var xml = stringWriter.ToString();
            var document = new XmlDocument();
            document.LoadXml(xml);
            return document.DocumentElement;
        }
    }
}
