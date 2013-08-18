using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Guitar.Lib;

namespace Guitar
{
    public class TextBoxLogger : ITestLogger
    {
        private delegate void LogDelegate(string message);

        private RichTextBox _textBox;

        public TextBoxLogger(RichTextBox textBox)
        {
            _textBox = textBox;
        }

        public void Clear()
        {
            _textBox.Text = string.Empty;
        }

        public void Error(string errorMessage)
        {
            _textBox.BeginInvoke(new LogDelegate(WriteLine), errorMessage);
        }

        public void Warning(string message)
        {
            _textBox.BeginInvoke(new LogDelegate(WriteLine), message);
        }

        public void Information(string message)
        {
            _textBox.BeginInvoke(new LogDelegate(WriteLine), message);
        }

        public void Debug(string message)
        {
            _textBox.BeginInvoke(new LogDelegate(WriteLine), message);
        }

        void WriteLine(string message)
        {
            _textBox.Text += message + Environment.NewLine;
        }
    }
}
