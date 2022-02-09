using System;
using System.Threading;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Khlyzova_Valeria_PRI_117_lab_10
{
    public partial class Form1 : Form
    {
        static private double[,] mode_ = new double[5, 2];
        ParamsForThread[] threadInputParams = new ParamsForThread[8];
        delegate void RenderDLG();
        static private byte[,,] PixelsArray = new byte[600, 600, 3];

        Thread th_1 = null;
        Thread th_2 = null;
        Thread th_3 = null;
        Thread th_4 = null;
        Thread th_5 = null;
        Thread th_6 = null;
        Thread th_7 = null;
        Thread th_8 = null;

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            threadInputParams[0] = new ParamsForThread(0, 75, 600);
            threadInputParams[1] = new ParamsForThread(75, 150, 600);
            threadInputParams[2] = new ParamsForThread(150, 225, 600);
            threadInputParams[3] = new ParamsForThread(225, 300, 600);
            threadInputParams[4] = new ParamsForThread(300, 375, 600);
            threadInputParams[5] = new ParamsForThread(375, 450, 600);
            threadInputParams[6] = new ParamsForThread(450, 525, 600);
            threadInputParams[7] = new ParamsForThread(525, 600, 600);

            threadInputParams[0]._pointerToDraw = new ParamsForThread._RenderDLG(Draw);
            threadInputParams[1]._pointerToDraw = new ParamsForThread._RenderDLG(Draw);
            threadInputParams[2]._pointerToDraw = new ParamsForThread._RenderDLG(Draw);
            threadInputParams[3]._pointerToDraw = new ParamsForThread._RenderDLG(Draw);
            threadInputParams[4]._pointerToDraw = new ParamsForThread._RenderDLG(Draw);
            threadInputParams[5]._pointerToDraw = new ParamsForThread._RenderDLG(Draw);
            threadInputParams[6]._pointerToDraw = new ParamsForThread._RenderDLG(Draw);
            threadInputParams[7]._pointerToDraw = new ParamsForThread._RenderDLG(Draw);

            threadInputParams[0].code_mode = comboBox1.SelectedIndex;
            threadInputParams[1].code_mode = comboBox1.SelectedIndex;
            threadInputParams[2].code_mode = comboBox1.SelectedIndex;
            threadInputParams[3].code_mode = comboBox1.SelectedIndex;
            threadInputParams[4].code_mode = comboBox1.SelectedIndex;
            threadInputParams[5].code_mode = comboBox1.SelectedIndex;
            threadInputParams[6].code_mode = comboBox1.SelectedIndex;
            threadInputParams[7].code_mode = comboBox1.SelectedIndex;

            th_1 = new Thread(CalculateImage);
            th_2 = new Thread(CalculateImage);
            th_3 = new Thread(CalculateImage);
            th_4 = new Thread(CalculateImage);
            th_5 = new Thread(CalculateImage);
            th_6 = new Thread(CalculateImage);
            th_7 = new Thread(CalculateImage);
            th_8 = new Thread(CalculateImage);

            th_1.Priority = ThreadPriority.Lowest;
        

            RenderTimer.Start();

            th_1.Start(threadInputParams[0]);
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            for (int ax = 0; ax < 600; ax++)
            {
                for (int bx = 0; bx < 600; bx++)
                {
                    PixelsArray[ax, bx, 0] = 0;
                    PixelsArray[ax, bx, 1] = 0;
                    PixelsArray[ax, bx, 2] = 0;
                }
            }

            comboBox1.SelectedIndex = 0;

            mode_[1, 0] = 0.34;
            mode_[1, 1] = 0.05;

            // значения выбранны в соответствии с вариантом
            mode_[2, 0] = 0.32;
            mode_[2, 1] = 0.04;

            // значения подобраны для наглядного представления множество Жюлиа
            mode_[3, 0] = -0.70176;
            mode_[3, 1] = -0.3842;

        }

        private void Draw()
        {
            Gl.glRasterPos2i(-1, -1);
            Gl.glDrawPixels(600, 600, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, PixelsArray);
            Gl.glFlush();
            AnT.Invalidate();
        }
        // отклик таймера
        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Gl.glRasterPos2i(-1, -1);
            Gl.glDrawPixels(600, 600, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, PixelsArray);
            Gl.glFlush();

            AnT.Invalidate();
        }

        static void CalculateImage(object Settings)
        {
            ParamsForThread thisThreadSettings = (ParamsForThread)Settings;

            // значения выбранны в соответствии с вариантом
            double xmin = -1.5;
            double ymin = -1.2;
            double xmax = 1.5;
            double ymax = 1.5;

            int W = 600;
            int H = 600;

            double dx = (xmax - xmin) / (double)(W - 1);
            double dy = (ymax - ymin) / (double)(H - 1);

            double x, y, X, Y, Cx, Cy;

            for (int ax = thisThreadSettings._FromImageH; ax < thisThreadSettings._ToImageH; ax++)
            {
                for (int bx = 0; bx < thisThreadSettings._ImageW; bx++)
                {
                    x = xmin + ax * dx;
                    y = ymin + bx * dy;

                    Cx = x;
                    Cy = y;
                    X = x;
                    Y = y;

                    double ix = 0, iy = 0, n = 0;

                    while ((ix * ix + iy * iy < 4) && (n < 64))
                    {
                        switch(thisThreadSettings.code_mode)
                        {
                            case 0:
                                ix = X * X - Y * Y + Cx;
                                iy = 2 * X * Y + Cy;
                                break;
                            case 1:
                                ix = X * X - Y * Y + mode_[thisThreadSettings.code_mode, 0];
                                iy = 2 * X * Y + mode_[thisThreadSettings.code_mode, 1];
                                break;
                            case 2:
                                // изменение параметров в соответствии с вариантом
                                ix = X * X - Y * Y + Math.Pow(mode_[thisThreadSettings.code_mode, 0], 2);
                                iy = 2 * X * Y + Math.Pow(mode_[thisThreadSettings.code_mode, 1], 2);
                                break;
                            case 3:
                                // множество Жюлиа
                                ix = X * X - Y * Y + mode_[thisThreadSettings.code_mode, 0];
                                iy = 2 * X * Y + mode_[thisThreadSettings.code_mode, 1];
                                break;
                        }

                        n++;
                        X = ix;
                        Y = iy;
                    }

                    PixelsArray[bx, ax, 0] = (byte)(255 - n * 4);
                    PixelsArray[bx, ax, 1] = (byte)(255 - n * 4);
                    PixelsArray[bx, ax, 2] = (byte)(255 - n * 4);

                    thisThreadSettings._pointerToDraw();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
