﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka
{
    public partial class ClasificatsiaUserControl : UserControl
    {
        public ClasificatsiaUserControl(string id)
        {
            InitializeComponent();

            List<string> classif = SQLClass.myselect("Select id, name, pic FROM level2 WHERE id = '" + id + "'");


            string id_class = classif[0];
            meduclabel.Text = classif[1];
            try
            {
                pictureBox1.Load("../../Картинки/" + classif[2]);
            }
            catch (Exception) { }

            List<string> meduc = SQLClass.myselect("Select id, name, pic FROM level3 WHERE id_class = '" + id_class + "'");

            int x = 400;
            for (int i = 0; i < meduc.Count; i += 3)
            {
                Label lbl = new Label();
                lbl.Location = new Point(x, 60);
                lbl.Size = new Size(200, 30);
                lbl.Font = new Font("Arial", 13);
                lbl.Text = meduc[i + 1];
                lbl.Tag = meduc[i];
                lbl.Click += new EventHandler(meduclabel_Click);
                Vievpanel.Controls.Add(lbl);

                PictureBox pb = new PictureBox();
                try
                {
                    pb.Load("../../Pictures/" + classif[i + 2]);
                }
                catch (Exception) { }
                pb.Location = new Point(300, 93);
                pb.Size = new Size(344, 240);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Tag = meduc[i];
                pb.Click += new EventHandler(pictureBox1_Click);
                Vievpanel.Controls.Add(pb);

                x += 210;
            }

        }

        private void meduclabel_Click(object sender, EventArgs e)
        {
              Label lb = (Label)sender;
              MedikamenUserControl meduc = new MedikamenUserControl(lb.Tag.ToString());
              Controls.Clear();
              Controls.Add(meduc);
              meduc.Dock = DockStyle.None;    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            MedikamenUserControl meduc = new MedikamenUserControl(pb.Tag.ToString());
            Controls.Clear();
            Controls.Add(meduc);
            meduc.Dock = DockStyle.None;
        }

        private void Vievpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
