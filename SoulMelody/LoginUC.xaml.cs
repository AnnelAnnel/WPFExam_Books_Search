using SoulMelody.Admin;
using SoulMelody.Usermenu;
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
    /// Interaction logic for LoginUC.xaml
    /// </summary>
    public partial class LoginUC : UserControl
    {
       
        private StartWindow st;

        public LoginUC(StartWindow st)
        {
            this.st = st;
            InitializeComponent();
        }

        
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
        

            using (LibraryDBEntities db = new LibraryDBEntities())
            {

                var login = Login.Text;

                var password = Password.Password;

                var loginSearch = from user in db.Users
                                  where user.Login == login
                                  select user;

                var userResult = loginSearch.FirstOrDefault();
           


                try
                {
                    if (Login.Text != "" && Password.Password!= "")
                    {

                        if (userResult != null)
                        {
                            if (password == userResult.Password)
                            {


                              
                                

                                if (userResult.RoleID == 1)
                                {
                                    AdminMenu menu = new AdminMenu(userResult.Id);
                                    menu.Show();
                                 
                                    StartingUC startUC = new StartingUC(st);
                                    st.startGrid.Children.Clear();
                                    st.startGrid.Children.Add(startUC);
                                }
                                if (userResult.RoleID == 2)
                                {
                                    UserMenu menu = new UserMenu(userResult.Id);
                                    menu.Show();
                                    StartingUC startUC = new StartingUC(st);
                                    st.startGrid.Children.Clear();
                                    st.startGrid.Children.Add(startUC);
                                }
                                


                            }
                            else
                            {
                                MessageBox.Show("Wrong password!");
                            }

                        }

                        else
                        {
                            MessageBox.Show("Login not found!");

                        }

                    }
                    else
                    {
                        MessageBox.Show("Fill in all fields!");

                    }
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message);
                }



            }
        }

        
        //private void FaceIdBtn_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

            StartingUC startUC = new StartingUC(st);
            st.startGrid.Children.Clear();
            st.startGrid.Children.Add(startUC);
        }
        
    }
}
