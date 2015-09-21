using System;
using System.Windows;
using System.Collections.Generic;
namespace ssvep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Window> windows = new List<Window>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void makeButton_Click(object sender, RoutedEventArgs e)
        {
            int periodNum = 0;
            Int32.TryParse(txtPeriod.Text, out periodNum);
            if (periodNum >= 2 && periodNum <= 6)
            {
                var temp = new blinkingWindow(periodNum, txtColor1.Text, txtColor2.Text);
                temp.Show();
                windows.Add(temp);
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var win in windows)
            {
                win.Close();
            }
            windows.Clear();
        }
    }
}
