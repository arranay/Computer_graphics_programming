using System;
using System.Drawing;
using System.Windows.Forms;

namespace Khlyzova_Valeria_PRI_117_lab_02
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        Point tmp_location;
        int _w = SystemInformation.PrimaryMonitorSize.Width;
        int _h = SystemInformation.PrimaryMonitorSize.Height;
        Image MemForImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label3.Text = e.X.ToString();
            label4.Text = e.Y.ToString();

            if (e.X > 61 && e.X < 213 && e.Y > 94 && e.Y < 140)
            {
                tmp_location = this.Location;
                tmp_location.X += rnd.Next(-100, 100);
                tmp_location.Y += rnd.Next(-100, 100);

                if (tmp_location.X < 0 || tmp_location.X > (_w - this.Width / 2) || tmp_location.Y < 0 || tmp_location.Y > (_h - this.Height / 2))
                {
                    tmp_location.X = _w / 2;
                    tmp_location.Y = _h / 2;
                }
                this.Location = tmp_location;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы усердны!!!!!!!!!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Мы не сомневались в вешем безразличии -_-", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rsl = MessageBox.Show("Вы действительно хотите выйти из приложения?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rsl == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void LoadImage(bool jpg)
        {
            openFileDialog1.InitialDirectory = "c:\\";

            if (jpg)
            {
                openFileDialog1.Filter = "image (JPEG) files (*.jpg)|*.jpg|All files (*.*)|*.*";
            }
            else
            {
                openFileDialog1.Filter = "image (PNG) files (*.png)|*.png|All files (*.*)|*.*";
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    MemForImage = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = MemForImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить файл: " + ex.Message);
                }
            }
        }

        private void вФорматеJPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImage(true);
        }

        private void вФорматеPNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImage(false);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LoadImage(true);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LoadImage(false);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form PreView = new Preview(MemForImage);
            PreView.ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form AboutView = new AboutProgramm();
            AboutView.ShowDialog();
        }
    }
}
