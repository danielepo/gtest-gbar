using System.Drawing;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using Guitar.Lib.ViewModels;

namespace ColorProgressBar
{
    partial class ColorProgressBar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public TestRunViewModel ViewModel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ColorProgressBar
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Name = "ColorProgressBar";
            this.Size = new System.Drawing.Size(146, 146);
            this.ResumeLayout(false);

        }

        #endregion

        int min = 0;	// Minimum value for progress range
        int max = 100;	// Maximum value for progress range
        int val = 0;		// Current progress

        protected override void OnResize(EventArgs e)
        {
            // Invalidate the control to get a repaint.
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            float percent = (float)(val - min) / (float)(max - min);
            Rectangle rect = this.ClientRectangle;
            // Calculate area for drawing the progress.
            int rectWidth = (int)((float)rect.Width * percent  / (val != 0 ? val : 1));

            Graphics g = e.Graphics;
            SolidBrush brush;
            LinearGradientBrush linGrBrush;

            int countGreen = ViewModel.TestsPassed;
            int countRed = ViewModel.TestsFailed;
            int countYellow = ViewModel.TestsIgnored;
            int countGray = ViewModel.TestCount;

            countGray -=  countGreen + countRed + countYellow;

            linGrBrush = new LinearGradientBrush(
                   new Point(0, 0),
                   new Point(0, 24),
                   Color.LightGreen,  
                   Color.Green); 


            //brush = new SolidBrush(Color.Green);
            
            rect.X = 0;
            rect.Width = rectWidth * countGreen;


            g.FillRectangle(linGrBrush, rect);
            linGrBrush = new LinearGradientBrush(
                   new Point(0, 0),
                   new Point(0, 24),
                   Color.Red,
                   Color.DarkRed);
            //brush = new SolidBrush(Color.Red);
            rect.X = rectWidth * countGreen;
            rect.Width = rectWidth * countRed;

            g.FillRectangle(linGrBrush, rect);

            linGrBrush = new LinearGradientBrush(new Point(0,0), new Point(0,24), Color.Khaki, Color.DarkKhaki);
            rect.X = rectWidth * (countGreen + countRed);
            rect.Width = rectWidth * countYellow;
            g.FillRectangle(linGrBrush, rect);

            linGrBrush = new LinearGradientBrush(
                   new Point(0, 0),
                   new Point(0, 24),
                   Color.LightGray,
                   Color.Gray);
            //brush = new SolidBrush(Color.Gray);
            rect.X = rectWidth * ( countGreen + countRed + countYellow );
            rect.Width = rectWidth * countGray;
            g.FillRectangle(linGrBrush, rect);
            // Clean up.
            linGrBrush.Dispose();
            // Draw a three-dimensional border around the control.
            //Draw3DBorder(g);

            
            g.Dispose();
        }

        public int Minimum
        {
            get
            {
                return min;
            }

            set
            {
                // Make sure that the min is never negative.
                min = Math.Max(value, 0);
                // Make sure that the min is never set greater than the maximum;
                min = Math.Min(value, max);
                // Make sure that the value is never greater than the minimum;s
                val = Math.Min(min, val);

                // Invalidate the control to get a repaint.
                this.Invalidate();
            }
        }

        public int Maximum
        {
            get
            {
                return max;
            }

            set
            {
                // Make sure that the maximum value is never set lower than the minimum value.
                min = Math.Min(min, value);
                
                max = value;

                // Make sure that value is still in range.
                val = EnforceValueConstraint(min, max, val);

                // Invalidate the control to get a repaint.
                this.Invalidate();
            }
        }

        public int Value
        {
            get
            {
                return val;
            }

            set
            {
                int oldValue = val;

                // Make sure that the value does not stray outside the valid range.
                val = EnforceValueConstraint(min, max, value);
                
                // Invalidate only the changed area.
                float percent;

                Rectangle newValueRect = this.ClientRectangle;
                Rectangle oldValueRect = this.ClientRectangle;

                // Use a new value to calculate the rectangle for progress.
                percent = (float)(val - min) / (float)(max - min);
                newValueRect.Width = (int)((float)newValueRect.Width * percent);

                // Use an old value to calculate the rectangle for progress.
                percent = (float)(oldValue - min) / (float)(max - min);
                oldValueRect.Width = (int)((float)oldValueRect.Width * percent);

                Rectangle updateRect = new Rectangle();

                // Find only the part of the screen that must be updated.
                if (newValueRect.Width > oldValueRect.Width)
                {
                    updateRect.X = oldValueRect.Size.Width;
                    updateRect.Width = newValueRect.Width - oldValueRect.Width;
                }
                else
                {
                    updateRect.X = newValueRect.Size.Width;
                    updateRect.Width = oldValueRect.Width - newValueRect.Width;
                }

                updateRect.Height = this.Height;

                // Invalidate the intersection region only.
                this.Invalidate(updateRect);
            }
        }

        private int EnforceValueConstraint(int min, int max, int value)
        {
            value = Math.Min(value, max);
            value = Math.Max(value, min);

            return value;
        }

    }
}
