using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SoulMelody
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            StartingUC startUC = new StartingUC(this);
          
            this.startGrid.Children.Add(startUC);
            
  
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginUC loginUC = new LoginUC(this);
            this.startGrid.Children.Clear();
            this.startGrid.Children.Add(loginUC);
            
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            
            RegisterUC registerUC = new RegisterUC(this);
            this.startGrid.Children.Clear();
            this.startGrid.Children.Add(registerUC);

        }

       

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
