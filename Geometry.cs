using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelSharp
{
    public class Geometry
    {
        public struct Vector3
        {
            public double x;
            public double y;
            public double z;
            public Vector3 (double x, double y, double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public Vector2 Project2D (Camera CameraPlane)
            {
                // TODO Project to Cameraplane
                return new Vector2(0,0);
            }

            public Vector3 Add ( Vector3 vectorToAdd)
            {
                return new Vector3(
                    this.x + vectorToAdd.x,
                    this.y + vectorToAdd.y,
                    this.z + vectorToAdd.z );
            }
            public Vector3 Substract(Vector3 vectorToSubstract)
            {
                return new Vector3(
                    this.x - vectorToSubstract.x,
                    this.y - vectorToSubstract.y,
                    this.z - vectorToSubstract.z);
            }
            public Vector3 MultiplyFactor(double multiplicationFactor)
            {
                return new Vector3(
                    this.x * multiplicationFactor,
                    this.y * multiplicationFactor,
                    this.z * multiplicationFactor );
            }
            public Vector3 RotateWithAxis(Vector3 rotAxis, double rotDeg)
            {
                double[] rotMat = new double[9];

                rotMat[0] = ( Math.Pow(rotAxis.x, 2) * (1f - Math.Cos(rotDeg)) ) +  Math.Cos(rotDeg);
                rotMat[1] = ( rotAxis.x * rotAxis.y   * (1f - Math.Cos(rotDeg)) ) - (rotAxis.z * Math.Sin(rotDeg));
                rotMat[2] = ( rotAxis.x * rotAxis.z   * (1f - Math.Cos(rotDeg)) ) + (rotAxis.y * Math.Sin(rotDeg));
                            
                rotMat[3] = ( rotAxis.y * rotAxis.x   * (1f - Math.Cos(rotDeg)) ) + (rotAxis.z * Math.Sin(rotDeg));
                rotMat[4] = ( Math.Pow(rotAxis.y, 2) * (1f - Math.Cos(rotDeg)) ) +  Math.Cos(rotDeg);
                rotMat[5] = ( rotAxis.y * rotAxis.z   * (1f - Math.Cos(rotDeg)) ) - (rotAxis.x * Math.Sin(rotDeg));
                      
                rotMat[6] = ( rotAxis.z * rotAxis.x   * (1f - Math.Cos(rotDeg)) ) - (rotAxis.y * Math.Sin(rotDeg));
                rotMat[7] = ( rotAxis.z * rotAxis.y   * (1f - Math.Cos(rotDeg)) ) + (rotAxis.x * Math.Sin(rotDeg));
                rotMat[8] = ( Math.Pow(rotAxis.z, 2) * (1f - Math.Cos(rotDeg)) ) +  Math.Cos(rotDeg);

                double newX = (double)(rotMat[0] * x) + (rotMat[1] * y) + (rotMat[2] * z);
                double newY = (double)(rotMat[3] * x) + (rotMat[4] * y) + (rotMat[5] * z);
                double newZ = (double)(rotMat[6] * x) + (rotMat[7] * y) + (rotMat[8] * z);

                return new Vector3(newX, newY, newZ);

                //return new Vector3(rotMat[0], rotMat[3], rotMat[6]).MultiplyFactor(x).Add( // x 
                //       new Vector3(rotMat[1], rotMat[4], rotMat[7]).MultiplyFactor(y).Add(   // y
                //       new Vector3(rotMat[2], rotMat[5], rotMat[8]).MultiplyFactor(z)));     // z

            }

        }
        public struct Vector2 
        {
            public double x;
            public double y;
            public Vector2(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public struct Triangle2
        {
            public Vector3[] vertices;
        }

        public struct Plane
        {
            public Vector3 basePoint;
            public Vector3 xUnit;
            public Vector3 yUnit;
            
            //public Plane(Vector3 basePoint, Vector3 xAxis, Vector3 point3)
            //{
            //    this.basePoint = basePoint;
            //}
        }

        public struct Camera
        {
            public Vector3 cameraPosition;
            public Vector3 targetPoint;
            public float fieldOfView;
            public Plane cameraPlane;

            //public Camera (Vector3 cameraPosition, Vector3 targetPoint, float fieldOfView)
            //{
            //    this.cameraPosition = cameraPosition;
            //    this.targetPoint = targetPoint;
            //    this.fieldOfView = fieldOfView;

            //}
        }


    }
}
