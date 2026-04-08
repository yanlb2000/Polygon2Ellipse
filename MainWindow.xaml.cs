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
using System.Windows.Threading;



namespace Polygon2Ellipse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UnitaryPolygon pg;
        frmDraw frmD1;
        private DispatcherTimer aTimer;
        int StepsCount = 0;

        public MainWindow()
        {
            InitializeComponent();
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

        private void TimerEvent(object? sender, EventArgs e)
        {
            aTimer.Interval = TimeSpan.FromMilliseconds(Convert.ToInt32(txtAutoRunInterval.Text));
            Steps();
        }
        private void Steps()
        {
            if (pg == null)
                return;
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
            aTimer = new ();
            aTimer.Interval = TimeSpan.FromSeconds(1);
            aTimer.Tick += TimerEvent;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (frmD1 != null)
            {
                frmD1.Close();
            }
        }

        private void chkAutoRun_Click(object sender, RoutedEventArgs e)
        {
            if (chkAutoRun.IsChecked == true)
            {
                aTimer.Start();
            }
            else
            {
                aTimer.Stop();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetTimer();
        }
    }
}