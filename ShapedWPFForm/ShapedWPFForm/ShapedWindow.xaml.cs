using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Media.Animation;

namespace ShapedWPFForm
{
    /// <summary>
    /// Interaction logic for ShapedWindow.xaml
    /// </summary>
    public partial class ShapedWindow : Window
    {
       
        public ShapedWindow()
        {
            InitializeComponent();
            this.Topmost = true;
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 4);
            dispatcherTimer.Start();


         
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string s = @""+Properties.Settings.Default.FullPath;
            System.Diagnostics.Process.Start(s);
            this.btnLogin.Visibility = Visibility.Hidden;
            this.button2.Visibility = Visibility.Hidden;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            //base.OnMouseLeftButtonDown(e);
            //DragMove();
        }

   
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            foreach (Process Proc in Process.GetProcesses())
                if (Proc.ProcessName.Equals(Properties.Settings.Default.PName))  //Process Excel?
                    Proc.Kill();

            System.Windows.Application.Current.Shutdown();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ConForm c = new ConForm();
            c.Show();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ColorAnimation ca = new ColorAnimation();
            ca.From = (Color)ColorConverter.ConvertFromString("#0066FF");
            ca.To = (Color)ColorConverter.ConvertFromString("#FF0000");
            ca.Duration = TimeSpan.FromSeconds(3);
            this.border.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, ca);
            this.Focus();
            this.Topmost = true;
        }
        private void _canExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
            e.Handled = true;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
            this.Topmost = true;
            foreach (Process Proc in Process.GetProcesses())
                if (Proc.ProcessName.Equals("ChatiApp"))  //Process Excel?
                    Proc.Kill();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Alt && e.SystemKey == Key.F4 ||
               Keyboard.Modifiers == ModifierKeys.Control && e.SystemKey == Key.Escape ||
                Keyboard.Modifiers == ModifierKeys.Windows && e.SystemKey == Key.D)
            {
                e.Handled = false;
            }
            else
            {
                base.OnPreviewKeyDown(e);
            }

        }
        
    }
}