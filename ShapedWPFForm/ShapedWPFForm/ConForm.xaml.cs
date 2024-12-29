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
using System.Windows.Shapes;

namespace ShapedWPFForm
{
    /// <summary>
    /// Interaction logic for ConForm.xaml
    /// </summary>
    public partial class ConForm : Window
    {
        public ConForm()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.PName;
            textBox2.Text = Properties.Settings.Default.FullPath;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.PName = textBox1.Text;
            Properties.Settings.Default.FullPath = textBox2.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
