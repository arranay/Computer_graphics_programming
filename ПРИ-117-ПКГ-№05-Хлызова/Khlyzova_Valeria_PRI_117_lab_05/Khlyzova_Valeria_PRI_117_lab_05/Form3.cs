using System;
using Tao.OpenGl;
using Tao.FreeGlut;
using System.Windows.Forms;

namespace Khlyzova_Valeria_PRI_117_lab_05
{
    public partial class Form3 : Form
    {
        double a = 1, b = 0, c = 0;

        public Form3()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            if (AnT.Width <= AnT.Height)
                Glu.gluOrtho2D(0.0, 30.0, 0.0, 30.0 * (float)AnT.Height / (float)AnT.Width);
            else
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            a = (double)trackBar1.Value / 1000.0;
            label4.Text = a.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            b = (double)trackBar2.Value / 1000.0;
            label5.Text = b.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            c = (double)trackBar3.Value / 1000.0;
            label6.Text = c.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RenderTimer.Start();
        }

        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glBegin(Gl.GL_TRIANGLES);

            Gl.glColor3d(0.0 + a, 0.0 + b, 0.0 + c);
            Gl.glVertex2d(5.0, 5.0);
            Gl.glColor3d(0.0 + c, 0.0 + a, 0.0 + b);
            Gl.glVertex2d(25.0, 5.0);
            Gl.glColor3d(0.0 + b, 0.0 + c, 0.0 + a);
            Gl.glVertex2d(5.0, 25.0);

            Gl.glEnd();
            Gl.glFlush();
            AnT.Invalidate();
        }
    }
}
