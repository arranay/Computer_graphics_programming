using System;
using System.Drawing;
using System.Windows.Forms;

namespace Khlyzova_Valeria_PRI_117_lab_02
{
    public partial class Preview : Form
    {
        Image ToView;

        public Preview(Image view)
        {
            ToView = view;
            InitializeComponent();
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            if (ToView != null)
            {
                pictureBox1.Size = new Size(ToView.Width, ToView.Height);
                pictureBox1.Image = ToView;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
