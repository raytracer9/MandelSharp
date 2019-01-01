using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelSharp 
{
    class Canvas
    {

        public int xSize;
        public int ySize;

        public Pixel[] valueBuffer;
        public char[] frameBuffer;

        public Canvas()
        {
            xSize = 120;
            ySize = 80;
            frameBuffer = new char[xSize * ySize];
            valueBuffer = new Pixel[xSize * ySize];
        }
        public Canvas(int xSize, int ySize)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            this.frameBuffer = new char[xSize * ySize];
            this.valueBuffer = new Pixel[xSize * ySize];
            Console.SetWindowSize(xSize+1, ySize+1);
        }


        public void RenderFrame()
        {
            UpdateFrameBuffer();
            string outputString = "";
            for (int i = 0; i < frameBuffer.Length ; i++)
            {
                if (i % xSize == 0) { outputString += ("\n"); }
                outputString += (frameBuffer[i]);                
            }
            Console.Clear();
            Console.Write(outputString);

        }
        public void UpdateFrameBuffer()
        {
            string gradient = " \u2591\u2592\u2593\u2588";

            for (int i = 0; i < valueBuffer.Length; i++)
            {
                frameBuffer[i] = gradient[(int)Math.Floor((double)valueBuffer[i].value / 255f * (double)gradient.Length)];
            }
        }


        public struct Pixel
        {
            public int value;
            public Pixel(int value = 0)
            {
                if (value > 255)
                {
                    this.value = 255;
                }
                else {
                    this.value = value;
                }
            }
        }


    }
}
