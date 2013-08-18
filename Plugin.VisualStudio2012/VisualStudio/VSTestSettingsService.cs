using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;

namespace Plugin.VisualStudio2012.VisualStudio
{
    [SettingsName(VSTestSettings.SettingsName)]
    public class VSTestSettingsService : ISettingsProvider
    {
        private readonly XmlSerializer serializer;
        public VSTestSettings Settings;

        public VSTestSettingsService()
        {
            serializer = new XmlSerializer(typeof(VSTestSettings));
        }

        public void Load(XmlReader reader)
        {
            if (reader != null)
            {
                if (reader.Read() && reader.Name.Equals(VSTestSettings.SettingsName))
                {
                    Settings = serializer.Deserialize(reader) as VSTestSettings;
                }
            }
        }
    }
}
