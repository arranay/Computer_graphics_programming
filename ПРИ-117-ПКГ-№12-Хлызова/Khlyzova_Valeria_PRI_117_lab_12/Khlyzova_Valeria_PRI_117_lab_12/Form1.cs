using System;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Khlyzova_Valeria_PRI_117_lab_12
{
    public partial class Form1 : Form
    {
        double a = 0, b = 0, c = -5, d = 0, zoom = 1;

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            a = (double)trackBar5.Value / 1000.0;
            label3.Text = a.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            b = (double)trackBar4.Value / 1000.0;
            label4.Text = b.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            c = (double)trackBar1.Value / 1000.0;
            label5.Text = c.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            d = (double)trackBar2.Value;
            label6.Text = d.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            zoom = (double)trackBar3.Value / 1000.0;
            label7.Text = zoom.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Wire = checkBox1.Checked;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {

                        os_x = 1;
                        os_y = 0;
                        os_z = 0;
                        break;

                    }
                case 1:
                    {

                        os_x = 0;
                        os_y = 1;
                        os_z = 0;
                        break;

                    }
                case 2:
                    {

                        os_x = 0;
                        os_y = 0;
                        os_z = 1;
                        break;

                    }
            }
        }

        int os_x = 1, os_y = 0, os_z = 0;
        bool Wire = false;

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
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
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            RenderTimer.Start();
        }

        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            Gl.glTranslated(a, b, c);
            Gl.glRotated(d, os_x, os_y, os_z);
            Gl.glScaled(zoom, zoom, zoom);

            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    {
                        drawCircle(Wire);
                        break;
                    }
                case 1:
                    {

                        drawCylinder(Wire);
                        break;

                    }
                case 2:
                    {
                        drawCube(Wire);
                        break;

                    }
                case 3:
                    {
                        drawCone(Wire);
                        break;

                    }
                case 4:
                    {
                        drawTorus(Wire);
                        break;

                    }
            }

            Gl.glPopMatrix();
            Gl.glFlush();
            AnT.Invalidate();
        }

        // методы для отрисовки фигур. Вариант 15 - число объектов 6, вид объектов - Solid и Wire чередуются
        private void drawTorus(bool wire)
        {
            if (wire)
            {
                Gl.glTranslated(a, b, c);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidTorus(0.2, 0.6, 32, 32);

                Gl.glTranslated(a - 2, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireTorus(0.2, 0.6, 32, 32);

                Gl.glTranslated(a + 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireTorus(0.2, 0.6, 32, 32);

                Gl.glTranslated(a, b - 2, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidTorus(0.2, 0.6, 32, 32);

                Gl.glTranslated(a - 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidTorus(0.2, 0.6, 32, 32);

                Gl.glTranslated(a + 2, b + 4, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireTorus(0.2, 0.6, 32, 32);
            } else
            {
                Gl.glTranslated(a, b, c);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireTorus(0.2, 0.6, 32, 32);

                Gl.glTranslated(a - 2, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidTorus(0.2, 0.6, 32, 32);

                Gl.glTranslated(a + 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidTorus(0.2, 0.6, 32, 32);

                Gl.glTranslated(a, b - 2, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireTorus(0.2, 0.6, 32, 32);

                Gl.glTranslated(a - 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireTorus(0.2, 0.6, 32, 32);

                Gl.glTranslated(a + 2, b + 4, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidTorus(0.2, 0.6, 32, 32);
            }  
        }

        private void drawCone(bool wire)
        {
            if (wire)
            {
                Gl.glTranslated(a, b, c);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCone(0.5, 1, 32, 32);

                Gl.glTranslated(a - 2, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCone(0.5, 1, 32, 32);

                Gl.glTranslated(a + 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCone(0.5, 1, 32, 32);

                Gl.glTranslated(a, b - 2, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCone(0.5, 1, 32, 32);

                Gl.glTranslated(a - 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCone(0.5, 1, 32, 32);

                Gl.glTranslated(a + 2, b + 4, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCone(0.5, 1, 32, 32);

            } else
            {
                Gl.glTranslated(a, b, c);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCone(0.5, 1, 32, 32);

                Gl.glTranslated(a - 2, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCone(0.5, 1, 32, 32);

                Gl.glTranslated(a + 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCone(0.5, 1, 32, 32);

                Gl.glTranslated(a, b - 2, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCone(0.5, 1, 32, 32);

                Gl.glTranslated(a - 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCone(0.5, 1, 32, 32);

                Gl.glTranslated(a + 2, b + 4, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCone(0.5, 1, 32, 32);
            }    
        }

        private void drawCube(bool wire)
        {
            if (wire)
            {
                Gl.glTranslated(a, b, c);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCube(1);

                Gl.glTranslated(a - 2, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCube(1);

                Gl.glTranslated(a + 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCube(1);

                Gl.glTranslated(a, b - 2, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCube(1);

                Gl.glTranslated(a - 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCube(1);

                Gl.glTranslated(a + 2, b + 4, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCube(1);
            } else
            {
                Gl.glTranslated(a, b, c);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCube(1);

                Gl.glTranslated(a - 2, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCube(1);

                Gl.glTranslated(a + 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCube(1);

                Gl.glTranslated(a, b - 2, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCube(1);

                Gl.glTranslated(a - 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCube(1);

                Gl.glTranslated(a + 2, b + 4, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCube(1);
            }   
        }

        private void drawCylinder(bool wire)
        {
            if (wire)
            {
                Gl.glTranslated(a, b, c);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCylinder(0.5, 1, 32, 32);

                Gl.glTranslated(a - 2, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCylinder(0.5, 1, 32, 32);

                Gl.glTranslated(a + 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCylinder(0.5, 1, 32, 32);

                Gl.glTranslated(a, b - 2, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCylinder(0.5, 1, 32, 32);

                Gl.glTranslated(a - 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCylinder(0.5, 1, 32, 32);

                Gl.glTranslated(a + 2, b + 4, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCylinder(0.5, 1, 32, 32);

            }
            else
            {
                Gl.glTranslated(a, b, c);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCylinder(0.5, 1, 32, 32);

                Gl.glTranslated(a - 2, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCylinder(0.5, 1, 32, 32);

                Gl.glTranslated(a + 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCylinder(0.5, 1, 32, 32);

                Gl.glTranslated(a, b - 2, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCylinder(0.5, 1, 32, 32);

                Gl.glTranslated(a - 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireCylinder(0.5, 1, 32, 32);

                Gl.glTranslated(a + 2, b + 4, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidCylinder(0.5, 1, 32, 32);
            }
        }

        private void drawCircle(bool wire)
        {
            if (wire)
            {
                Gl.glTranslated(a, b, c);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidSphere(0.5, 16, 16);

                Gl.glTranslated(a - 2, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireSphere(0.5, 16, 16);

                Gl.glTranslated(a + 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireSphere(0.5, 16, 16);

                Gl.glTranslated(a, b - 2, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidSphere(0.5, 16, 16);

                Gl.glTranslated(a - 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidSphere(0.5, 16, 16);

                Gl.glTranslated(a + 2, b + 4, c + 5); 
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireSphere(0.5, 16, 16);
            }
            else
            {
                Gl.glTranslated(a, b, c);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireSphere(0.5, 16, 16);

                Gl.glTranslated(a - 2, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidSphere(0.5, 16, 16);

                Gl.glTranslated(a + 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidSphere(0.5, 16, 16);

                Gl.glTranslated(a, b - 2, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireSphere(0.5, 16, 16);

                Gl.glTranslated(a - 4, b, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutWireSphere(0.5, 16, 16);

                Gl.glTranslated(a + 2, b + 4, c + 5);
                Gl.glRotated(d, os_x, os_y, os_z);
                Gl.glScaled(zoom, zoom, zoom);
                Glut.glutSolidSphere(0.5, 16, 16);
            }
        }

    }
}
