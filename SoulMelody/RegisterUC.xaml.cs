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
    /// Interaction logic for RegisterUC.xaml
    /// </summary>
    public partial class RegisterUC : UserControl
    {
        StartWindow st;
        
        public RegisterUC(StartWindow recievedWindow)
        {
            InitializeComponent();
            st = recievedWindow;           

        }
    
        
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            //go to database and create user then return to start uc
            StartingUC startUC = new StartingUC(st);
            st.startGrid.Children.Clear();
            st.startGrid.Children.Add(startUC);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
           
            StartingUC startUC = new StartingUC(st);
            st.startGrid.Children.Clear();
            st.startGrid.Children.Add(startUC);
           
        }

        private void MakeFaceIdBtn_Click(object sender, RoutedEventArgs e)
        {
            //WebCamCatch webCamCatch = new WebCamCatch();
            //webCamCatch.Show();

            //EmotionGetterUC emoGet = new EmotionGetterUC(st);
            //st.startGrid.Children.Clear();
            //st.startGrid.Children.Add(emoGet);
        }
    }
}
