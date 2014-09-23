using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
﻿using System.IO;
﻿using System.Linq;
﻿using System.Runtime.Serialization.Formatters.Binary;
﻿using System.Text;
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
        private ImageProcessor processor;

        public Form1()
        {
            processor = new ImageProcessor();
            InitializeComponent();
            ApplySettings();
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

        private void ApplySettings()
        {
            try
            {
                processor.equalizeHist = false;
                processor.finder.maxRotateAngle = 45;
                processor.minContourArea = 100;
                processor.minContourLength = 100;
                processor.finder.maxACFDescriptorDeviation = 5;
                processor.finder.minACF = 0.85;
                processor.finder.minICF = 0.96;
                processor.blur = true;
                processor.noiseFilter = true;
                processor.cannyThreshold = 50;
                processor.adaptiveThresholdBlockSize = 5;
                processor.adaptiveThresholdParameter = 1.5;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
