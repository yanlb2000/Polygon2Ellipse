using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Polygon2Ellipse
{
    /// <summary>
    /// Interaction logic for frmDraw.xaml
    /// </summary>
    public partial class frmDraw : Window
    {
        public frmDraw()
        {
            InitializeComponent();
        }

        public void DrawPolygon(UnitaryPolygon pg)
        {
            double cvsWidth = grdMain.ActualWidth;
            double cvsHeight = grdMain.ActualHeight;
            cvsMain.Width = cvsWidth;
            cvsMain.Height = cvsHeight;
            System.Windows.Shapes.Polygon p = new ();
            p.Stroke = Brushes.Red;
            p.StrokeThickness = 2;
            p.Fill = Brushes.LightSkyBlue;
            p.HorizontalAlignment = HorizontalAlignment.Left;
            p.VerticalAlignment = VerticalAlignment.Bottom;
            PointCollection pc = new ();
            for (int i = 0; i<pg.VertexCount; i++)
            {
                pc.Add(new Point(pg.Vertexs[i].X * cvsWidth, pg.Vertexs[i].Y * cvsHeight));
            }
            p.Points = pc;
            cvsMain.Children.Clear();
            cvsMain.Children.Add(p);
        }
    }
}
