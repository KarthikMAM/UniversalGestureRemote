using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace UniversalGestureRemote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Operation.Items.Add("Presentation");
            Operation.Items.Add("Browsers");
            Operation.Items.Add("Players");
            Operation.Items.Add("Volume");
            Operation.Items.Add("Editors");
            Operation.SelectedIndex = 0;
        }

        int prevprevGesture = -1;
        int prevGesture = -1;
        void sampler_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            try
            {
                if (Operation.SelectedIndex > 0 && Start.Content.ToString() == "Stop")
                {
                    switch (e.ProgressPercentage)
                    {
                        case 1:
                            Process.Start(Operation.SelectedItem.ToString() + "_Left.exe");
                            break;
                        case 2:
                            Process.Start(Operation.SelectedItem.ToString() + "_Right.exe");
                            break;
                    }
                }
                if (Operation.SelectedIndex == 0 && Start.Content.ToString() == "Stop")
                {
                    if (prevprevGesture == 1 && prevGesture == 0 && e.ProgressPercentage == 1) { Process.Start(Operation.SelectedItem.ToString() + "_Right.exe"); }
                    else if (prevprevGesture == 2 && prevGesture == 0 && e.ProgressPercentage == 1) { Process.Start(Operation.SelectedItem.ToString() + "_Left.exe"); }
                    prevprevGesture = prevGesture;
                    prevGesture = e.ProgressPercentage;
                }
            }
            catch
            {
                MessageBox.Show("Connection Lost", "Error in connection");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = 2;
            this.Top = System.Windows.SystemParameters.PrimaryScreenHeight - 145;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            Image buttonImage = sender as Image;
            string buttonSource = buttonImage.Source.ToString();
            buttonSource = buttonSource.Substring(0, buttonSource.Length - 5) + "P" + ".png";
            buttonImage.Source = new BitmapImage(new Uri(buttonSource));
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image buttonImage = sender as Image;
            string buttonSource = buttonImage.Source.ToString();
            buttonSource = buttonSource.Substring(0, buttonSource.Length - 5) + "H" + ".png";
            buttonImage.Source = new BitmapImage(new Uri(buttonSource));
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch((sender as Image).Name)
            {
                case "Quit":
                    this.Close();
                    break;
                case "Hide":
                    this.WindowState = WindowState.Minimized;
                    break;
                case "More":
                    if (COMPort.Opacity == 0) 
                    {
                        Ok.Opacity = 1;
                        COMPort.Opacity = 1;
                    }
                    else 
                    {
                        COMPort.Opacity = 0;
                        Ok.Opacity = 0;
                    }
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString() == "Start") { (sender as Button).Content = "Stop"; }
            else { (sender as Button).Content = "Start"; }
        }

        private void Ok_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GestureRecognition gestureRecognition = new GestureRecognition(Thread.CurrentThread, COMPort.Text);
                gestureRecognition.sampler.ProgressChanged += sampler_ProgressChanged;
                Ok.Opacity = 0;
                COMPort.Opacity = 0.1;
                COMPort.Width = 0;
            }
            catch
            {
                MessageBox.Show("Failed to create a connection", "Unable to create a connection");
            }
        }
    }
}
