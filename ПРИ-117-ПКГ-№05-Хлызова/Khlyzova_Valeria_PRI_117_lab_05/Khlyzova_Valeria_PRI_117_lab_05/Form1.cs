using System;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace Khlyzova_Valeria_PRI_117_lab_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            if ((float)AnT.Width <= (float)AnT.Height)
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Height / (float)AnT.Width, 0.0, 30.0);
            }
            else
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0);
            }

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();
            Gl.glColor3f(255, 0, 0);

            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(8, 7);
            Gl.glVertex2d(15, 27);
            Gl.glVertex2d(17, 27);
            Gl.glVertex2d(23, 7);
            Gl.glVertex2d(21, 7);
            Gl.glVertex2d(19, 14);
            Gl.glVertex2d(12.5, 14);
            Gl.glVertex2d(10, 7);

            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(18.5, 16);
            Gl.glVertex2d(16, 25);
            Gl.glVertex2d(13.2, 16);

            Gl.glEnd();
            Gl.glFlush();
            AnT.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();

            Gl.glLineWidth(2);

            // X
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(1, 13);
            Gl.glVertex2d(3, 19);
            Gl.glVertex2d(1, 25);
            Gl.glVertex2d(3, 25);
            Gl.glVertex2d(5, 20);
            Gl.glVertex2d(7, 25);
            Gl.glVertex2d(9, 25);
            Gl.glVertex2d(7, 19);
            Gl.glVertex2d(9, 13);
            Gl.glVertex2d(7, 13);
            Gl.glVertex2d(5, 18);
            Gl.glVertex2d(3, 13);
            Gl.glEnd();

            // Л
            Gl.glColor3f(0, 255, 0);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(7, 13);
            Gl.glVertex2d(11, 25);
            Gl.glVertex2d(13, 25);
            Gl.glVertex2d(17, 13);
            Gl.glVertex2d(15, 13);
            Gl.glVertex2d(12, 23);
            Gl.glVertex2d(9, 13);
            Gl.glEnd();

            // Ы
            Gl.glColor3f(255, 0, 0);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(15, 13);
            Gl.glVertex2d(23, 13);
            Gl.glVertex2d(23, 19);
            Gl.glVertex2d(17, 19);
            Gl.glVertex2d(17, 25);
            Gl.glVertex2d(15, 25);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(17, 15);
            Gl.glVertex2d(21, 15);
            Gl.glVertex2d(21, 17);
            Gl.glVertex2d(17, 17);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(24, 13);
            Gl.glVertex2d(26, 13);
            Gl.glVertex2d(26, 25);
            Gl.glVertex2d(24, 25);
            Gl.glEnd();

            // З
            Gl.glColor3f(255, 255, 0);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(25, 13);
            Gl.glVertex2d(33, 13);
            Gl.glVertex2d(33, 25);
            Gl.glVertex2d(25, 25);
            Gl.glVertex2d(25, 23);
            Gl.glVertex2d(31, 23);
            Gl.glVertex2d(31, 20);
            Gl.glVertex2d(27, 20);
            Gl.glVertex2d(27, 18);
            Gl.glVertex2d(31, 18);
            Gl.glVertex2d(31, 15);
            Gl.glVertex2d(25, 15);
            Gl.glEnd();

            // О
            Gl.glColor3f(255, 0, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(32, 13);
            Gl.glVertex2d(41, 13);
            Gl.glVertex2d(41, 25);
            Gl.glVertex2d(32, 25);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(34, 15);
            Gl.glVertex2d(39, 15);
            Gl.glVertex2d(39, 23);
            Gl.glVertex2d(34, 23);
            Gl.glEnd();

            // В
            Gl.glColor3f(0, 255, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(40, 13);
            Gl.glVertex2d(40, 25);
            Gl.glVertex2d(45, 25);
            Gl.glVertex2d(45, 20);
            Gl.glVertex2d(50, 20);
            Gl.glVertex2d(50, 13);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(41, 15);
            Gl.glVertex2d(41, 18);
            Gl.glVertex2d(48, 18);
            Gl.glVertex2d(48, 15);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(41, 23);
            Gl.glVertex2d(41, 21);
            Gl.glVertex2d(44, 21);
            Gl.glVertex2d(44, 23);
            Gl.glEnd();

            // А
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(49, 13);
            Gl.glVertex2d(53, 25);
            Gl.glVertex2d(55, 25);
            Gl.glVertex2d(59, 13);
            Gl.glVertex2d(57, 13);
            Gl.glVertex2d(56, 17);
            Gl.glVertex2d(52, 17);
            Gl.glVertex2d(51, 13);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(55, 19);
            Gl.glVertex2d(53, 19);
            Gl.glVertex2d(54, 23);
            Gl.glEnd();

            // В - Имя Валерия
            Gl.glColor3f(255, 0, 0);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(40, 0);
            Gl.glVertex2d(40, 12);
            Gl.glVertex2d(45, 12);
            Gl.glVertex2d(45, 7);
            Gl.glVertex2d(50, 7);
            Gl.glVertex2d(50, 0);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(41, 2);
            Gl.glVertex2d(41, 5);
            Gl.glVertex2d(48, 5);
            Gl.glVertex2d(48, 2);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(41, 10);
            Gl.glVertex2d(41, 8);
            Gl.glVertex2d(44, 8);
            Gl.glVertex2d(44, 10);
            Gl.glEnd();
            Gl.glFlush();

            // Г - Отчество Григорьевна
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(49, 0);
            Gl.glVertex2d(49, 12);
            Gl.glVertex2d(57, 12);
            Gl.glVertex2d(57, 10);
            Gl.glVertex2d(51, 10);
            Gl.glVertex2d(51, 0);
            Gl.glEnd();
            Gl.glFlush();

            AnT.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
