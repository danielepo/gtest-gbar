using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guitar.Lib;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace Plugin.VisualStudio2012.VisualStudio
{
    class VSLogger : ITestLogger
    {
        private readonly IMessageLogger _logger;

        public VSLogger(IMessageLogger logger)
        {
            _logger = logger;
        }

        public void Error(string errorMessage)
        {
            _logger.SendMessage(TestMessageLevel.Error, errorMessage);
        }

        public void Warning(string message)
        {
            _logger.SendMessage(TestMessageLevel.Warning, message);
        }

        public void Information(string message)
        {
            _logger.SendMessage(TestMessageLevel.Informational, message);
        }

        public void Debug(string message)
        {
            _logger.SendMessage(TestMessageLevel.Informational, message);
        }
    }
}
