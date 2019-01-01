using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelSharp
{
    class Program
    {
        public static Canvas frame = new Canvas(140, 50);
        

        static void Main(string[] args)
        {
            

            Random rnd = new Random(DateTime.Now.Millisecond);

            while (false)
            {
                for (int i = 0; i < frame.valueBuffer.Length; i++)
                {
                    frame.valueBuffer[i].value = rnd.Next(0, 255);
                }
                Update();

                Console.ReadKey();
            }

            Geometry.Vector3 vecA = new Geometry.Vector3(1,0,0);
            Geometry.Vector3 rotAxis = new Geometry.Vector3(0, 1, 0);
            Geometry.Vector3 vecB = vecA.RotateWithAxis(rotAxis, 90);
            Console.WriteLine("Vector A: x:{0} y:{1} z:{2}", vecA.x, vecA.y, vecA.z);
            Console.WriteLine("Vector B: x:{0} y:{1} z:{2}", vecB.x, vecB.y, vecB.z);
            Console.ReadKey();
        }

        static public void Update()
        {
            frame.RenderFrame();
            
        }

    }


}
