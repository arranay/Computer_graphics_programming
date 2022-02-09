using System;
using System.Windows.Forms;
using Tao.DevIl;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Khlyzova_Valeria_PRI_117_lab_15
{
    public partial class Form1 : Form
    {
        float global_time = 0;
        private float[,] camera_date = new float[5, 7];
        private Explosion BOOOOM_1 = new Explosion(1, 10, 1, 300, 500);
        Random rnd = new Random();

        double a = 0, b = 0, c = -5, d = 0, zoom = 1;
        int os_x = 1, os_y = 0, os_z = 0;

        anModelLoader Model = null;

        private void selectAFileForDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Model = new anModelLoader();
                Model.LoadModel(openFileDialog1.FileName);
                RenderTimer.Start();
            }
        }

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Il.ilInit();

            Il.ilEnable(Il.IL_CONV_PAL);

            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();


            Glu.gluPerspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 200);


            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 0;

            camera_date[0, 0] = -3;
            camera_date[0, 1] = 0;
            camera_date[0, 2] = -20;
            camera_date[0, 3] = 0;
            camera_date[0, 4] = 1;
            camera_date[0, 5] = 0;
            camera_date[0, 6] = 0;

            camera_date[1, 0] = -3;
            camera_date[2, 1] = 2;
            camera_date[1, 2] = -20;
            camera_date[1, 3] = 30;
            camera_date[1, 4] = 1;
            camera_date[1, 5] = 0;
            camera_date[1, 6] = 0;

            camera_date[2, 0] = -3;
            camera_date[2, 1] = 2;
            camera_date[2, 2] = -20;
            camera_date[2, 3] = 30;
            camera_date[2, 4] = 1;
            camera_date[2, 5] = 1;
            camera_date[2, 6] = 0;

            camera_date[3, 0] = -3;
            camera_date[3, 1] = -3;
            camera_date[3, 2] = -20;
            camera_date[3, 3] = 70;
            camera_date[3, 4] = 0;
            camera_date[3, 5] = 1;
            camera_date[3, 6] = 0;

            camera_date[4, 0] = 3;
            camera_date[4, 1] = 2;
            camera_date[4, 2] = -30;
            camera_date[4, 3] = 1;
            camera_date[4, 4] = 1;
            camera_date[4, 5] = 1;
            camera_date[4, 6] = 1;

            RenderTimer.Start();
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            global_time += (float)RenderTimer.Interval / 1000;
            Draw();
        }

        private void Draw()
        {
            if (comboBox2.SelectedIndex == 0)
            {
                Gl.glClearColor(255, 255, 255, 1);
            }
            else
            {
                Gl.glClearColor(0, 0, 0, 1);
            }
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();

            if (comboBox2.SelectedIndex == 0)
            {
                Gl.glColor3d(255, 255, 255);
            }
            else
            {
                Gl.glColor3d(255, 255, 255);
            }

            Gl.glPushMatrix();

            int camera = comboBox1.SelectedIndex;

            Gl.glTranslated(camera_date[camera, 0], camera_date[camera, 1], camera_date[camera, 2]);
            Gl.glRotated(camera_date[camera, 3], camera_date[camera, 4], camera_date[camera, 5], camera_date[camera, 6]);

            Gl.glPushMatrix();
            Gl.glTranslated(a, b, c);
            Gl.glRotated(d, os_x, os_y, os_z);
            Gl.glScaled(zoom, zoom, zoom);

            DrawMatrix(30);

            //BOOOOM_1.Calculate(global_time);

            if (Model != null)
                Model.DrawModel();

            Gl.glPopMatrix();

            Gl.glPopMatrix();

            Gl.glFlush();

            AnT.Invalidate();
        }

        private void DrawMatrix(int x)
        {
            float quad_size = 1;

            Gl.glBegin(Gl.GL_LINES);

            for (int ax = -10; ax < x + 1; ax++)
            {
                Gl.glVertex3d(quad_size * ax, -5, 0);
                Gl.glVertex3d(quad_size * ax, -5, quad_size * x);
            }

            Glut.glutSolidSphere(0.02, 6, 6);
            for (int bx = 0; bx < x + 1; bx++)
            {
                Gl.glVertex3d(-10, -5, quad_size * bx);
                Gl.glVertex3d(quad_size * x, -5, quad_size * bx);
            }

            Gl.glEnd();
        }
          
        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            BOOOOM_1.SetNewPosition(5, 5, 5);
            BOOOOM_1.SetNewPower(rnd.Next(20));
            BOOOOM_1.Boooom(global_time);
        }
    }
}
