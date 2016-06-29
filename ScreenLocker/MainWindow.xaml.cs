using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScreenLocker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int WmSyscommand = 0x0112;
        public const int ScMonitorpower = 0xF170;
        public const int HwndBroadcast = 0xFFFF;
        public const int ShutOffDisplay = 2;
        [DllImport("user32.dll")]
        private static extern void LockWorkStation();//上鎖用

        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        private static extern int PostMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        public MainWindow()
        {
            InitializeComponent();
            init();
            turnOffScreen();
            finishSelf();
        }

        private void init()
        {
            //turn window minized
            //WindowState = WindowState.Minimized;
        }

        private void turnOffScreen() {
            PostMessage((IntPtr)HwndBroadcast, (uint)WmSyscommand, (IntPtr)ScMonitorpower, (IntPtr)ShutOffDisplay);
        }

        private void finishSelf() {
            Environment.Exit(0);
        }
    }
}
