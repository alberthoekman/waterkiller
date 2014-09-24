using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ContourAnalysisNS;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Waterkiller
{
    public class LevelReader
    {
        public ImageProcessor Process;
        public LevelReader()
        {
            Process = new ImageProcessor();
            ApplySettings();
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

        public int ReadLevel(ListboxItem item)
        {
            Process.ProcessImage(new Image<Bgr, byte>((Bitmap)Bitmap.FromFile(item.Path)));
            var foundTemplates = Process.foundTemplates;


            int lowestNumbro = 0;
            int lowestNumbroBottomPosition = 0;

            bool orientation;
            // Store all them niggas
            List<int> bottomPositions = new List<int>();
            List<String> names = new List<string>();

            foreach (var found in foundTemplates)
            {
                string text = found.template.name;

                Rectangle foundRect = found.sample.contour.SourceBoundingRect;

                bottomPositions.Add(foundRect.Bottom);                  // Store the bottom position and name of every found object
                names.Add(text);

                if (IsDigitsOnly(text))
                {
                    int number = int.Parse(text);
                    if ((number > 0 && number < lowestNumbro) || lowestNumbro == 0)  // Look for the lowest found number that is not 0
                    {
                        lowestNumbro = number;                          // Set the lowest number
                        lowestNumbroBottomPosition = foundRect.Bottom;  // Set the bottom position of the lowest number
                    }
                }
            }


            if (lowestNumbro != 0)      // If a lowest number has been found, check how many balkjes are visible beneath it
            {
                lowestNumbro *= 10;     // Make it a multiple of 10

                for (int i = 0; i < bottomPositions.Count; i++)     // Now count how many balkjes are visible beneath it
                {

                    if ((names[i].Contains("balkje") || names[i].Contains("streepje")) && bottomPositions[i] > lowestNumbroBottomPosition)
                    {
                        lowestNumbro -= 2;
                    }




                }
                return lowestNumbro;
            }
            return 000000;
        }
        private void ApplySettings()
        {
            try
            {
                Process.equalizeHist = false;
                Process.finder.maxRotateAngle = 45;
                Process.minContourArea = 100;
                Process.minContourLength = 100;
                Process.finder.maxACFDescriptorDeviation = 5;
                Process.finder.minACF = 0.85;
                Process.finder.minICF = 0.96;
                Process.blur = true;
                Process.noiseFilter = true;
                Process.cannyThreshold = 50;
                Process.adaptiveThresholdBlockSize = 5;
                Process.adaptiveThresholdParameter = 1.5;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}