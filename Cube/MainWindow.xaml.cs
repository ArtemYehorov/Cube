using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cube
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point oldPosition;
        UIElement elem;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Box_MouseMove(object sender, MouseEventArgs e)
        {
            elem = sender as UIElement;
            if (!elem.IsMouseCaptured) return;
            Canvas.SetLeft(elem, e.GetPosition(this).X - oldPosition.X);
            Canvas.SetTop(elem, e.GetPosition(this).Y - oldPosition.Y);
            cmdX.Text = (e.GetPosition(this).X - oldPosition.X).ToString();
            cmdY.Text = (e.GetPosition(this).Y - oldPosition.Y).ToString();
        }

        private void Box_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            elem = sender as UIElement;
            oldPosition = e.GetPosition(elem);
            elem.CaptureMouse();
        }

        private void Box_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            (sender as UIElement).ReleaseMouseCapture();
        }

        private void cmdX_TextChanged(object sender, TextChangedEventArgs e)
        {
           elem = Box;
           Canvas.SetLeft(elem, Convert.ToDouble(cmdX.Text));
        }

        private void cmdY_TextChanged(object sender, TextChangedEventArgs e)
        {
            elem = Box;
            Canvas.SetTop(elem, Convert.ToDouble(cmdY.Text));
        }
    }
}
