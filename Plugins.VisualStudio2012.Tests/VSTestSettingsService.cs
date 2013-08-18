using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NUnit.Framework;
using Plugin.VisualStudio2012.VisualStudio;

namespace Plugins.VisualStudio2012.Tests
{
    [TestFixture]
    class VSTestSettingsServiceTests
    {
        [Test]
        public void VSTestSettingsService_Load_SetsWorkingDirectory()
        {
            string xml = @"<Guitar>
                                <WorkingDirectory>C:\</WorkingDirectory>
                            </Guitar>";

            VSTestSettingsService service = new VSTestSettingsService();
            service.Load(new XmlTextReader(new StringReader(xml)));

            Assert.AreEqual("C:\\", service.Settings.WorkingDirectory);
        }
        [Test]
        public void VSTestSettingsService_Load_SetsWorkingDirectory_EnvironmentVariable()
        {
            string xml = @"<Guitar>
                                <WorkingDirectory>%TEMP%</WorkingDirectory>
                            </Guitar>";

            VSTestSettingsService service = new VSTestSettingsService();
            service.Load(new XmlTextReader(new StringReader(xml)));

            Assert.AreNotEqual("%TEMP%", service.Settings.WorkingDirectory);
        }

        [Test]
        public void VSTestSettingsService_Load_SetsShuffle_True()
        {
            string xml = @"<Guitar>
                                <ShuffleTests>true</ShuffleTests>
                            </Guitar>";

            VSTestSettingsService service = new VSTestSettingsService();
            service.Load(new XmlTextReader(new StringReader(xml)));

            Assert.AreEqual(true, service.Settings.ShuffleTests);
        }
        [Test]
        public void VSTestSettingsService_Load_SetsShuffle_False()
        {
            string xml = @"<Guitar>
                                <ShuffleTests>false</ShuffleTests>
                            </Guitar>";

            VSTestSettingsService service = new VSTestSettingsService();
            service.Load(new XmlTextReader(new StringReader(xml)));

            Assert.AreEqual(false, service.Settings.ShuffleTests);
        }

        [Test]
        public void VSTestSettingsService_Load_SetsRunDisabled_True()
        {
            string xml = @"<Guitar>
                                <RunDisabledTests>true</RunDisabledTests>
                            </Guitar>";

            VSTestSettingsService service = new VSTestSettingsService();
            service.Load(new XmlTextReader(new StringReader(xml)));

            Assert.AreEqual(true, service.Settings.RunDisabledTests);
        }
        [Test]
        public void VSTestSettingsService_Load_SetsRunDisabled_False()
        {
            string xml = @"<Guitar>
                                <RunDisabledTests>false</RunDisabledTests>
                            </Guitar>";

            VSTestSettingsService service = new VSTestSettingsService();
            service.Load(new XmlTextReader(new StringReader(xml)));

            Assert.AreEqual(false, service.Settings.RunDisabledTests);
        }
        [Test]
        public void VSTestSettingsService_Load_SetsRunDisabled_1()
        {
            string xml = @"<Guitar>
                                <RunDisabledTests>1</RunDisabledTests>
                            </Guitar>";

            VSTestSettingsService service = new VSTestSettingsService();
            service.Load(new XmlTextReader(new StringReader(xml)));

            Assert.AreEqual(true, service.Settings.RunDisabledTests);
        }
        [Test]
        public void VSTestSettingsService_Load_SetsRunDisabled_0()
        {
            string xml = @"<Guitar>
                                <RunDisabledTests>0</RunDisabledTests>
                            </Guitar>";

            VSTestSettingsService service = new VSTestSettingsService();
            service.Load(new XmlTextReader(new StringReader(xml)));

            Assert.AreEqual(false, service.Settings.RunDisabledTests);
        }
    }
}
