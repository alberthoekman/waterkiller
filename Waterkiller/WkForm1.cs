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
    public partial class WkForm1 : Form
    {
        private LevelReader reader;
        //private ImageProcessor processor;

        public WkForm1()
        {
            reader = new LevelReader();
            InitializeComponent();
        }

        private void btScan_Click(object sender, EventArgs e)
        {
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

            label1.Text = reader.ReadLevel(selected).ToString();
        }

        
    }
}
