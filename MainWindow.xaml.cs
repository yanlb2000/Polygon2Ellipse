using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Polygon2Ellipse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UnitaryPolygon pg;
        frmDraw frmD1;
        private static System.Timers.Timer aTimer;
        int StepsCount = 0;

        public MainWindow()
        {
            InitializeComponent();
            //SetTimer();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            if (frmD1 != null)
            {
                frmD1.Close();
                frmD1 = null;
            }

            int Count = Convert.ToInt32(txtVertexCount.Text);

            pg = new UnitaryPolygon(Count);

            StepsCount = 0;
            frmD1 = new frmDraw();
            frmD1.Show();
            frmD1.DrawPolygon(pg);
            lblStepCount.Content = String.Format("Steps count: {0}", StepsCount);
        }

        private void btnStep_Click(object sender, RoutedEventArgs e)
        {
            Steps();
        }

        private void TimerEvent(Object source, ElapsedEventArgs e)
        {
            if (btnStep.IsPressed) 
            {
                Steps();
            }
        }
        private void Steps()
        {
            if (pg.VertexCount == 0)
                return;
            if (frmD1 == null)
                return;
            int ThisSteps = Convert.ToInt32(txtSteps.Text);
            for (int i = 0; i < ThisSteps; i++)
            {
                pg.OneStep();
            }
            frmD1.DrawPolygon(pg);
            StepsCount += ThisSteps;
            lblStepCount.Content = String.Format("Steps count: {0}", StepsCount);
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += TimerEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (frmD1 != null)
            {
                frmD1.Close();
            }
        }
    }
}