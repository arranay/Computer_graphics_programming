using System.Drawing;
using System.Collections;

namespace Khlyzova_Valeria_PRI_117_lab_06
{
    class anEngine
    {
        private int picture_size_x, picture_size_y;
        private int scroll_x, scroll_y;
        private int screen_width, screen_height;
        private int ActiveLayerNom;
        private ArrayList Layers = new ArrayList();
        private anBrush standartBrush;
        private Color LastColorInUse;

        public anEngine(int size_x, int size_y, int screen_w, int screen_h)
        {
            standartBrush = new anBrush(3, false);

            picture_size_x = size_x;
            picture_size_y = size_y;

            screen_width = screen_w;
            screen_height = screen_h;

            scroll_x = 0;
            scroll_y = 0;

            Layers.Add(new anLayer(picture_size_x, picture_size_y));

            ActiveLayerNom = 0;

            standartBrush = new anBrush(1, false);
        }

        public void SetActiveLayerNom(int nom)
        {
            ((anLayer)Layers[ActiveLayerNom]).CreateNewList();
            ((anLayer)Layers[nom]).SetColor(((anLayer)Layers[ActiveLayerNom]).GetColor());

            ActiveLayerNom = nom;
        }

        public void SetWisibilityLayerNom(int nom, bool visible)
        {
        }

        public void Drawing(int x, int y)
        {
            ((anLayer)Layers[ActiveLayerNom]).Draw(standartBrush, x, y);
        }

        public void SwapImage()
        {
            for (int ax = 0; ax < Layers.Count; ax++)
            {
                if (ax == ActiveLayerNom)
                {
                    ((anLayer)Layers[ax]).RenderImage(false);
                }
                else
                {
                    ((anLayer)Layers[ax]).RenderImage(true);
                }
            }
        }

        public void SetStandartBrush(int SizeB)
        {
            standartBrush = new anBrush(SizeB, false);
        }

        public void SetSpecialBrush(int Nom)
        {
            standartBrush = new anBrush(Nom, true);
        }

        public void SetBrushFromFile(string FileName)
        {
            standartBrush = new anBrush(FileName);
        }

        public void SetColor(Color NewColor)
        {
            ((anLayer)Layers[ActiveLayerNom]).SetColor(NewColor);
            LastColorInUse = NewColor;
        }

        public void AddLayer()
        {
            int AddingLayer = Layers.Add(new anLayer(picture_size_x, picture_size_y));
            SetActiveLayerNom(AddingLayer);
        }

        public void RemoveLayer(int nom)
        {
            if (nom < Layers.Count && nom >= 0)
            {
                Layers.RemoveAt(nom);
                SetActiveLayerNom(0);
            }
        }

        public Bitmap GetFinalImage()
        {
            Bitmap resaultBitmap = new Bitmap(picture_size_x, picture_size_y);

            for (int ax = 0; ax < Layers.Count; ax++)
            {
                int[,,] tmp_layer_data = ((anLayer)Layers[ax]).GetDrawingPlace();
                for (int a = 0; a < picture_size_x; a++)
                {
                    for (int b = 0; b < picture_size_y; b++)
                    {
                        if (tmp_layer_data[a, b, 3] != 1)
                        {
                            resaultBitmap.SetPixel(a, b, Color.FromArgb(tmp_layer_data[a, b, 0], tmp_layer_data[a, b, 1], tmp_layer_data[a, b, 2]));
                        }
                        else
                        {
                            if (ax == 0)
                            {
                                resaultBitmap.SetPixel(a, b, Color.FromArgb(255, 255, 255));
                            }
                        }
                    }
                }

            }
            resaultBitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            return resaultBitmap;
        }

        public void SetImageToMainLayer(Bitmap layer)
        {
            layer.RotateFlip(RotateFlipType.Rotate180FlipX);

            for (int ax = 0; ax < layer.Width; ax++)
            {
                for (int bx = 0; bx < layer.Height; bx++)
                {
                    SetColor(layer.GetPixel(ax, bx));
                    Drawing(ax, bx);
                }
            }
        }

        public void Filter_0()
        {
            ((anLayer)Layers[ActiveLayerNom]).Invers();
        }

        public void Filter_1()
        {
            float[] mat = new float[9]; mat[0] = -0.1f;
            mat[1] = -0.1f;
            mat[2] = -0.1f;
            mat[3] = -0.1f;
            mat[4] = 1.8f;
            mat[5] = -0.1f;
            mat[6] = -0.1f;
            mat[7] = -0.1f;
            mat[8] = -0.1f;

            ((anLayer)Layers[ActiveLayerNom]).PixelTransformation(mat, 0, 1, false);
        }


        public void Filter_2()
        {
            float[] mat = new float[9];

            mat[0] = 0.05f;
            mat[1] = 0.05f;
            mat[2] = 0.05f;
            mat[3] = 0.05f;
            mat[4] = 0.6f;
            mat[5] = 0.05f;
            mat[6] = 0.05f;
            mat[7] = 0.05f;
            mat[8] = 0.05f;

            ((anLayer)Layers[ActiveLayerNom]).PixelTransformation(mat, 0, 1, false);
        }

        public void Filter_3()
        {
            float[] mat = new float[9];

            mat[0] = -1.0f;
            mat[1] = -1.0f;
            mat[2] = -1.0f;
            mat[3] = -1.0f;
            mat[4] = 8.0f;
            mat[5] = -1.0f;
            mat[6] = -1.0f;
            mat[7] = -1.0f;
            mat[8] = -1.0f;

            ((anLayer)Layers[ActiveLayerNom]).PixelTransformation(mat, 0, 2, true);
        }

        public void Filter_4()
        {
            float[] mat = new float[9];

            mat[0] = 0.50f;
            mat[1] = 1.0f;
            mat[2] = 0.50f;
            mat[3] = 1.0f;
            mat[4] = 2.0f;
            mat[5] = 1.0f;
            mat[6] = 0.50f;
            mat[7] = 1.0f;
            mat[8] = 0.50f;

            ((anLayer)Layers[ActiveLayerNom]).PixelTransformation(mat, 0, 2, true);

            mat[0] = -0.5f;
            mat[1] = -0.5f;
            mat[2] = -0.5f;
            mat[3] = -0.5f;
            mat[4] = 6.0f;
            mat[5] = -0.5f;
            mat[6] = -0.5f;
            mat[7] = -0.5f;
            mat[8] = -0.5f;

            ((anLayer)Layers[ActiveLayerNom]).PixelTransformation(mat, 0, 1, false);
        }
    }
}
