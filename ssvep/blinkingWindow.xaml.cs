using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace ssvep
{
    /// <summary>
    /// Interaction logic for blinkingWindow.xaml
    /// </summary>
    public partial class blinkingWindow : Window
    {
        private int cntr = 0;
        private int length = 2;
        private Brush color;
        DispatcherTimer timer = new DispatcherTimer();
        public blinkingWindow(int num, string hexColor)
        {
            InitializeComponent();
            this.length = num;
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString(hexColor);
            this.color = brush;
            this.Background = brush;
            this.Title = num.ToString() + ", " + hexColor;
            Loaded += new RoutedEventHandler(blinkingWindow_Loaded);
            Closed += new EventHandler(blinkingWindow_Closed);
        }

        void blinkingWindow_Closed(object sender, EventArgs e)
        {
            timer.Stop();
        }

        void blinkingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            timer.Interval = new TimeSpan(0, 0, 0, 0, 17);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.txtCntr.Content = (cntr % length).ToString();
            if (cntr % length >= length/2)
            {                
                this.Background = Brushes.White;
                this.txtCntr.Foreground = Brushes.Black;
            }
            else
            {
                this.Background = color;
                this.txtCntr.Foreground = Brushes.White;
            }
            
            cntr++;
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            //List<string> data = new List<string>();
            //data.Add("2");
            //data.Add("3");
            //data.Add("4");
            //data.Add("5");
            //data.Add("6");

            //var combo = sender as ComboBox;
            //combo.ItemsSource = data;
            //combo.SelectedIndex = 0;            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var comboBox = sender as ComboBox;

            //// ... Set SelectedItem as Window Title.
            //string value = comboBox.SelectedItem as string;
            //this.length = Int32.Parse(value);
            //cntr = 0;
        }
    }
}
