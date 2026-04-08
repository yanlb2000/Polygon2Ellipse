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
        private double Margin;
        private double MaxWidth;
        public UnitaryPolygon(int n) 
        {
            VertexCount = n;
            Margin = 0.05;
            MaxWidth = 1 - Margin*2;
            VA = new Point[VertexCount];
            VB = new Point[VertexCount];
            Random rand = new ();

            for (int i = 0; i < VertexCount; i++)
            {
                VA[i] = new Point(Margin + MaxWidth * rand.NextDouble(), Margin + MaxWidth * rand.NextDouble());
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
            double maxX = Vertexs.Max(v=>v.X);
            double maxY = Vertexs.Max(v=>v.Y);
            double minX = Vertexs.Min(v=>v.X);
            double minY = Vertexs.Min(v=>v.Y);
            double LenX = maxX - minX;
            double LenY = maxY - minY;           

            for (int i = 0; i < VertexCount; i++)
            {
                Vertexs[i].X = Margin + MaxWidth * (Vertexs[i].X - minX) / LenX;
                Vertexs[i].Y = Margin + MaxWidth * (Vertexs[i].Y - minY) / LenY;
            }
        } //Unitary


        } // class Polygon
}
