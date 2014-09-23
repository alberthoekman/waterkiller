using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
﻿using ContourAnalysisNS;
// ReSharper disable once RedundantUsingDirective
using Emgu.CV;
using Emgu.CV.Structure;

namespace Waterkiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btScan_Click(object sender, EventArgs e)
        {
            label1.Text = "Running";
            ImageProcessor processor = new ImageProcessor();
            processor.ProcessImage(new Image<Bgr, byte>((Bitmap)Bitmap.FromFile("Geen_Water.jpg")));
            var foundTemplates = processor.foundTemplates;

            int number = 0;
            foreach (var foundTemplateDesc in foundTemplates)
            {
                number++;
                label1.Text = number.ToString();
            }
        }

        private void btMapSelect_Click(object sender, EventArgs e)
        {

        }
    }
}
