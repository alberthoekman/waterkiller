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
            ImageProcessor processor = new ImageProcessor();
            processor.ProcessImage(Image.FromFile("Geen_Water.jpg");
        }

        private void btMapSelect_Click(object sender, EventArgs e)
        {

        }
    }
}
