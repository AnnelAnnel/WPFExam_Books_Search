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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoulMelody
{
    /// <summary>
    /// Interaction logic for StartingUC.xaml
    /// </summary>
    public partial class StartingUC : UserControl
    {
        StartWindow st;
        public StartingUC(StartWindow receivedSt)
        {
            InitializeComponent();
            st = receivedSt;
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginUC loginUC = new LoginUC(st);
            st.startGrid.Children.Clear();
            st.startGrid.Children.Add(loginUC);

        }

        //private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        //{

        //    RegisterUC registerUC = new RegisterUC(st);
        //    st.startGrid.Children.Clear();
        //    st.startGrid.Children.Add(registerUC);

        //}



        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            st.Close();
        }
    }
}
