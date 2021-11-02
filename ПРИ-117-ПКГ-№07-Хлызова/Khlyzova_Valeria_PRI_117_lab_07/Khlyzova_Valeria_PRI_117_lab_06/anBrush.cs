using System.Drawing;
using System.IO;

namespace Khlyzova_Valeria_PRI_117_lab_06
{
    class anBrush
    {
        public Bitmap myBrush;
        private bool IsErase = false;

        public anBrush(int Value, bool Special)
        {
            if (!Special)
            {
                myBrush = new Bitmap(Value, Value);

                for (int ax = 0; ax < Value; ax++)
                    for (int bx = 0; bx < Value; bx++)
                        myBrush.SetPixel(0, 0, Color.Black);

                IsErase = false;
            }
            else
            {
                switch (Value)
                {
                    default:
                        {
                            myBrush = new Bitmap(5, 5);

                            for (int ax = 0; ax < 5; ax++)
                                for (int bx = 0; bx < 5; bx++)
                                    myBrush.SetPixel(ax, bx, Color.Red);

                            myBrush.SetPixel(0, 2, Color.Black);
                            myBrush.SetPixel(1, 2, Color.Black);

                            myBrush.SetPixel(2, 0, Color.Black);
                            myBrush.SetPixel(2, 1, Color.Black);
                            myBrush.SetPixel(2, 2, Color.Black);
                            myBrush.SetPixel(2, 3, Color.Black);
                            myBrush.SetPixel(2, 4, Color.Black);

                            myBrush.SetPixel(3, 2, Color.Black);
                            myBrush.SetPixel(4, 2, Color.Black);

                            IsErase = false;

                            break;
                        }
                    case 1: 
                        {
                            myBrush = new Bitmap(5, 5);

                            for (int ax = 0; ax < Value; ax++)
                                for (int bx = 0; bx < Value; bx++)
                                    myBrush.SetPixel(0, 0, Color.Black);

                            IsErase = true;
                            break;
                        }
                }
            }
        }

        public anBrush(string FromFile)
        {
            string path = Directory.GetCurrentDirectory();
            path += "\\" + FromFile;

            myBrush = new Bitmap(path);
        }

        public bool IsBrushErase()
        {
            return IsErase;
        }
    }
}
