namespace Khlyzova_Valeria_PRI_117_lab_10
{
    class ParamsForThread
    {
        public ParamsForThread(int startH, int endH, int Width)
        {
            _FromImageH = startH;
            _ToImageH = endH;
            _ImageW = Width;
        }

        public int code_mode;

        public delegate void _RenderDLG();
        public _RenderDLG _pointerToDraw = null;

        public int _FromImageH;
        public int _ToImageH;
        public int _ImageW;
    }
}
