using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Big_Ben
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly System.Windows.Threading.DispatcherTimer _timer = new System.Windows.Threading.DispatcherTimer();
        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg,
            int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public MainWindow()
        {
            
            InitializeComponent();
            _timer.Interval = new TimeSpan(0, 0, 0, 1);
            _timer.Tick += new EventHandler(Timer_Tick);
            _timer.Start();
            

        }

       

        public void Timer_Tick(object sender, EventArgs e)
        {
        
            //update label
            var britishTime = DateTime.Now;
            var grenadaTime = DateTime.Now;
            var londonTimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var grenadaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Venezuela Standard Time");
            britishTime = TimeZoneInfo.ConvertTime(britishTime, londonTimeZone);
            grenadaTime = TimeZoneInfo.ConvertTime(grenadaTime, grenadaTimeZone);
            LondonTimeDisplay.Content = britishTime.ToString("HH:mm:ss");
            GrenadaTimeDisplay.Content = $"Grenada: {grenadaTime:HH:mm:ss}";
        }

     
        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
           Close();
        }


        private void MainWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

  
    }
}
