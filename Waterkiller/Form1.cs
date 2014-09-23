using System;
using System.IO;
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
using Waterkiller;
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
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowser.SelectedPath;
                loadDirectory(path);
            }
        }

        private void loadDirectory(string path)
        {
            string[] files = Directory.GetFiles(@path);
            List<Waterkiller.ListboxItem> formattedFiles = new List<Waterkiller.ListboxItem>();
            foreach (string file in files)
            {
                Waterkiller.ListboxItem entry = new Waterkiller.ListboxItem();
                entry.Title = Path.GetFileNameWithoutExtension(file);
                entry.Path = file;
                formattedFiles.Add(entry);
            }
            listBox1.DataSource = formattedFiles;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void laadIn(object sender, EventArgs e)
        {
            Waterkiller.ListboxItem selected = (Waterkiller.ListboxItem)listBox1.SelectedItem;
            pictureBox1.ImageLocation = selected.Path;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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
