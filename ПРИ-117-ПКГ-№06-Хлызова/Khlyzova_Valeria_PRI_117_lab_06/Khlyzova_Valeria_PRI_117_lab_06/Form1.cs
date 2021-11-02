using System;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using System.Drawing;

namespace Khlyzova_Valeria_PRI_117_lab_06
{
    public partial class Form1 : Form
    {
        private anEngine ProgrammDrawingEngine;
        private int ActiveLayer = 0;
        private int LayersCount = 1;
        private int AllLayrsCount = 1;

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LayersControl.Items.Add("Главный слой", true);

            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluOrtho2D(0.0, AnT.Width, 0.0, AnT.Height);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);
            RenderTimer.Start();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Drawing();
        }

        private void Drawing()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glColor3f(0, 0, 0);

            ProgrammDrawingEngine.SwapImage();

            Gl.glFlush();
            AnT.Invalidate();
        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ProgrammDrawingEngine.Drawing(e.X, AnT.Height - e.Y);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ProgrammDrawingEngine.SetStandartBrush(4);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ProgrammDrawingEngine.SetSpecialBrush(0);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ProgrammDrawingEngine.SetBrushFromFile("brush-1.bmp");
        }

        private void color1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Color tmp = color1.BackColor;

            color1.BackColor = color2.BackColor;
            color2.BackColor = tmp;

            ProgrammDrawingEngine.SetColor(color1.BackColor);
        }

        private void color1_MouseClick(object sender, MouseEventArgs e)
        {
            if (changeColor.ShowDialog() == DialogResult.OK)
            {
                color1.BackColor = changeColor.Color;
                ProgrammDrawingEngine.SetColor(color1.BackColor);
            }
        }

        private void добавитьСлойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayersCount++;
            ProgrammDrawingEngine.AddLayer();

            int AddingLayerNom = LayersControl.Items.Add("Слой" + LayersCount.ToString(), false);

            LayersControl.SelectedIndex = AddingLayerNom;

            ActiveLayer = AddingLayerNom;
        }

        private void удалитьСлойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Будет удален текущий активный слой, действительно продолжить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); // если пользователь нажал кнопку "ДА" в окне подтверждения
            if (res == DialogResult.Yes)
            {
                if (ActiveLayer == 0)
                {
                    MessageBox.Show("Вы не можете удалить нулевой слой.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    LayersCount--;
                    int LayerNomForDel = LayersControl.SelectedIndex;
                    LayersControl.Items.RemoveAt(LayerNomForDel);
                    LayersControl.SelectedIndex = 0;
                    ActiveLayer = 0;
                    LayersControl.SetItemCheckState(0, CheckState.Checked);
                    ProgrammDrawingEngine.RemoveLayer(LayerNomForDel);
                }
            }
        }

        private void LayersControl_SelectedValueChanged(object sender, EventArgs e)
        {
            if (LayersControl.SelectedIndex != ActiveLayer)
            {
                if (LayersControl.SelectedIndex != -1 && ActiveLayer < LayersControl.Items.Count)
                {
                    LayersControl.SetItemCheckState(ActiveLayer, CheckState.Unchecked);
                    ActiveLayer = LayersControl.SelectedIndex;
                    LayersControl.SetItemCheckState(LayersControl.SelectedIndex, CheckState.Checked);
                    ProgrammDrawingEngine.SetActiveLayerNom(ActiveLayer);
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            добавитьСлойToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            удалитьСлойToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ProgrammDrawingEngine.SetSpecialBrush(1);
        }

        private void карандашToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void кистьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }

        private void стерашкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton6_Click(sender, e);
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult reslt = MessageBox.Show("В данный момент проект уже начат, сохранить изменения перед закрытием проекта?", "Внимание!", MessageBoxButtons.YesNoCancel);

            switch (reslt)
            {
                case DialogResult.No:
                    {
                        ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);
                        LayersControl.Items.Clear();
                        ActiveLayer = 0;
                        LayersCount = 1;
                        AllLayrsCount = 1;
                        LayersControl.Items.Add("Главный слой", true);

                        break;
                    }

                case DialogResult.Cancel:
                    {
                        return;
                    }

                case DialogResult.Yes:
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            Bitmap ToSave = ProgrammDrawingEngine.GetFinalImage();

                            ToSave.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                            ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);

                            LayersControl.Items.Clear();

                            ActiveLayer = 0;
                            LayersCount = 1;
                            AllLayrsCount = 1;
                            LayersControl.Items.Add("Главный слой", true);
                        }
                        else
                        {
                            return;
                        }

                        break;
                    }
            }
        }

        private void изФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult reslt = MessageBox.Show("В данный момент проект уже начат, сохранить изменения перед закрытием проекта?", "Внимание!", MessageBoxButtons.YesNoCancel);

            switch (reslt)
            {
                case DialogResult.No:
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (System.IO.File.Exists(openFileDialog.FileName))
                            {
                                Bitmap ToLoad = new Bitmap(openFileDialog.FileName);

                                if (ToLoad.Width > AnT.Width || ToLoad.Height > AnT.Height)
                                {
                                    MessageBox.Show("Извините, но размер изображения превышает размеры области рисования", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }

                                ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);
                                ProgrammDrawingEngine.SetImageToMainLayer(ToLoad);
                                LayersControl.Items.Clear();

                                ActiveLayer = 0;
                                LayersCount = 1;
                                AllLayrsCount = 1;

                                LayersControl.Items.Add("Главный слой", true);
                            }
                        }
                        break;
                    }

                case DialogResult.Cancel:
                    {
                        return;
                    }

                case DialogResult.Yes:
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            Bitmap ToSave = ProgrammDrawingEngine.GetFinalImage();
                            ToSave.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                if (System.IO.File.Exists(openFileDialog.FileName))
                                {
                                    Bitmap ToLoad = new Bitmap(openFileDialog.FileName);

                                    if (ToLoad.Width > AnT.Width || ToLoad.Height > AnT.Height)
                                    {
                                        MessageBox.Show("Извините, но размер изображения превышает размеры области рисования", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        return;
                                    }

                                    ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);
                                    ProgrammDrawingEngine.SetImageToMainLayer(ToLoad);
                                    LayersControl.Items.Clear();

                                    ActiveLayer = 0;
                                    LayersCount = 1;
                                    AllLayrsCount = 1;
                                    LayersControl.Items.Add("Главный слой", true);

                                }
                            }
                            break;

                        }
                        else
                        {
                            return;
                        }
                    }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap ToSave = ProgrammDrawingEngine.GetFinalImage();
                ToSave.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            ProgrammDrawingEngine.SetBrushFromFile("hv-1.bmp");
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            ProgrammDrawingEngine.SetBrushFromFile("pri-1.bmp");
        }
    }
}