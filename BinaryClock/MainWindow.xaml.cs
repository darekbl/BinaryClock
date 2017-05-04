using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace BinaryClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Clock TIMER = new Clock();

            /*
             * Variables
             */
            var label = (Label)FindName("godzinaLabel");

            var h8 = (Ellipse)this.FindName("h8");
            var h4 = (Ellipse)this.FindName("h4");
            var h2 = (Ellipse)this.FindName("h2");
            var h1 = (Ellipse)this.FindName("h1");

            var m32 = (Ellipse)this.FindName("m32");
            var m16 = (Ellipse)this.FindName("m16");
            var m8 = (Ellipse)this.FindName("m8");
            var m4 = (Ellipse)this.FindName("m4");
            var m2 = (Ellipse)this.FindName("m2");
            var m1 = (Ellipse)this.FindName("m1");

            var PM = (Ellipse)this.FindName("PM");

            List<Ellipse> ellipsesHour = new List<Ellipse>
            {
                h8,h4,h2,h1
            };

            List<Ellipse> ellipsesMinutes = new List<Ellipse>
            {
                m32,m16,m8,m4,m2,m1
            };
            
            /*
             * Get the hour and minutes in binary style
             */
            bool[] binaryHour = TIMER.getBinaryHour();
            bool[] binaryMinutes = TIMER.getBinaryMinutes();
            /*
             * Set the ellipses
             */
             
            setBinaryHour(binaryHour, ellipsesHour);
            setBinaryHour(binaryMinutes, ellipsesMinutes);
            
            setPM(TIMER.isPM());

            /*
             * Set the digital clock
             */
            label.Content = "Godzina: " + DateTime.Now.ToShortTimeString();
            
        }

        private void setBinaryHour(bool[] binaryHour, List<Ellipse> list)
        {
            int i = 0;
            foreach(var ellipse in list)
            {
                if(binaryHour[i] == true)
                {
                    ellipse.Fill = Brushes.ForestGreen;
                }
                else
                {
                    ellipse.Fill = Brushes.White;
                }
                i++;
            }
        }

        private void setBinaryMinutes(bool[] binaryMinutes, List<Ellipse> list)
        {
            int i = 0;
            foreach (var ellipse in list)
            {
                if (binaryMinutes[i] == true)
                {
                    ellipse.Fill = Brushes.ForestGreen;
                }
                else
                {
                    ellipse.Fill = Brushes.White;
                }
                i++;
            }
        }

        private void setPM(Boolean isPM)
        {
            if (isPM == true)
            {
                PM.Fill = Brushes.Coral;
            }
            else
            {
                PM.Fill = Brushes.White;
            }
        }
    }
}
