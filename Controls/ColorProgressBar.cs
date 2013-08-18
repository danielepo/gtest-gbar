using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Guitar.Lib.ViewModels;

namespace ColorProgressBar
{
    public partial class ColorProgressBar : UserControl
    {
        public ColorProgressBar(TestRunViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }
    }
}
