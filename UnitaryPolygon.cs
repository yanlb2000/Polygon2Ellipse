using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Polygon2Ellipse
{ 
    public class UnitaryPolygon
    {
        public int VertexCount;
        private Point[] VA;
        private Point[] VB;
        public Point[] Vertexs {  get; private set; }
        private bool bUseA = true;
        public UnitaryPolygon(int n) 
        {
            VertexCount = n;
            VA = new Point[VertexCount];
            VB = new Point[VertexCount];
            Random rand = new ();

            for (int i = 0; i < VertexCount; i++)
            {
                VA[i] = new Point(0.05 + 0.9 * rand.NextDouble(), 0.05 + 0.9 * rand.NextDouble());
                VB[i] = new Point(0, 0);
            }
            Vertexs = VA;
            bUseA = true;
        }

        public void OneStep()
        {
            Vertexs = bUseA? VA: VB;
            Point[] V2 = bUseA ? VB : VA;
            for (int i = 0; i < VertexCount - 1; i++)
            {
                V2[i].X = (Vertexs[i].X + Vertexs[i + 1].X) / 2.0;
                V2[i].Y = (Vertexs[i].Y + Vertexs[i + 1].Y) / 2.0;
            }
            V2[VertexCount - 1].X = (Vertexs[VertexCount - 1].X + Vertexs[0].X) / 2.0;
            V2[VertexCount - 1].Y = (Vertexs[VertexCount - 1].Y + Vertexs[0].Y) / 2.0;
            Vertexs = bUseA ? VB : VA;
            Unitary();
            bUseA = !bUseA;
        } // OneStep

        public void Unitary()
        {
            Vertexs = bUseA ? VA : VB;
            double maxX = 0;
            double maxY = 0;
            double minX = 1;
            double minY = 1;

            for (int i = 0; i < VertexCount;i++)
            {
                if (Vertexs[i].X > maxX)
                    maxX = Vertexs[i].X;
                if (Vertexs[i].Y > maxY)
                    maxY = Vertexs[i].Y;
                if (Vertexs[i].X < minX)
                    minX = Vertexs[i].X;
                if (Vertexs[i].Y < minY)
                    minY = Vertexs[i].Y;
            }

            for (int i = 0; i < VertexCount; i++)
            {
                Vertexs[i].X = 0.05 + 0.9 * (Vertexs[i].X - minX) / (maxX - minX);
                Vertexs[i].Y = 0.05 + 0.9 * (Vertexs[i].Y - minY) / (maxY - minY);
            }
        } //Unitary


        } // class Polygon
}
