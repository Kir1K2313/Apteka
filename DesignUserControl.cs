using System;
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
    public partial class DesignUserControl : UserControl
    {
        Font label_font;
        Color label_color;
        public DesignUserControl()
        {
            InitializeComponent();
        }

        private void editlabelbtn_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label_font = fontDialog1.Font;
                label_color = fontDialog1.Color;
            }
        }
    }
}
