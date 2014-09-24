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
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
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


            label1.Text = "Running";
            ImageProcessor processor = new ImageProcessor();
            processor.ProcessImage(new Image<Bgr, byte>((Bitmap)Bitmap.FromFile(selected.Path)));
            var foundTemplates = processor.foundTemplates;


            int lowestNumbro = 0;
            int lowestNumbroBottomPosition = 0;

            // Store all them niggas
            List<int> bottomPositions = new List<int>();
            List<String> names = new List<string>();

            foreach (var found in foundTemplates)
            {
                string text = found.template.name;

                Rectangle foundRect = found.sample.contour.SourceBoundingRect;
                // Store the bottom position and of every found object
                bottomPositions.Add(foundRect.Bottom);
                names.Add(text);

                if (IsDigitsOnly(text))
                {
                    int number = int.Parse(text);

                    // Look for the lowest found number that is not 0
                    if ((number > 0 && number < lowestNumbro) || lowestNumbro == 0)
                    {
                        // Set the lowest number
                        lowestNumbro = number;

                        // Set the bottom position of the lowest number
                        lowestNumbroBottomPosition = foundRect.Bottom;
                    }
                }
            }

            // If a lowest number has been found, check how many balkjes are visible beneath it
            if (lowestNumbro != 0)
            {
                // Make it a multiple of 10
                lowestNumbro *= 10;

                bool correctionOfOne = false;

                // Now count how many balkjes are visible beneath it
                for (int i = 0; i < bottomPositions.Count; i++)
                {
                    if ((names[i].Contains("balkje") || names[i].Contains("streepje")) && bottomPositions[i] > lowestNumbroBottomPosition)
                    {
                        if (correctionOfOne)
                            lowestNumbro -= 2;

                        correctionOfOne = true;
                    }
                }

                label1.Text = lowestNumbro.ToString();
            }

            else
            {
                label1.Text = "AAAAAAAAAHHHHHHHHHHHHHHHHHHHHHHH";
            }
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
