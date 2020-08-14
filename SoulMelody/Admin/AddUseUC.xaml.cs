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

namespace SoulMelody.Admin
{
    /// <summary>
    /// Interaction logic for AddUseUC.xaml
    /// </summary>
    public partial class AddUseUC : UserControl
    {
        AdminMenu ad;
        private int adminId;
        public AddUseUC(AdminMenu adminmenu, int id)
        {
            InitializeComponent();
            ad = adminmenu;
            adminId = id;
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LibraryDBEntities())
            {                
                try
                {
                    
                    int roleId;
                    if (Login.Text != "" && Password.Text != "" && LName.Text != "" && FName.Text != ""&&
                            Email.Text != "")
                    {
                       
                        if (RolesList.SelectedItem == null)
                        {
                            roleId = 2;
                        }

                        else
                        {
                            roleId = RolesList.SelectedIndex + 1;

                        
                        }
                        var loginTest = db.Users.FirstOrDefault(l => l.Login == Login.Text);
                        if (loginTest == null)
                        {
                        var newUser = new User
                        {
                            Login = Login.Text,
                            Password = Password.Text,
                            LName = LName.Text,
                            FName = FName.Text,
                            Email = Email.Text,
                            RoleID = roleId
                                
                            };
                            db.Users.Add(newUser);
                            db.SaveChanges();

                            UsersUC usersUC = new UsersUC(ad, adminId);

                            ad.UCgrid.Children.Clear();
                            ad.UCgrid.Children.Add(usersUC);
                        }
                        else
                        {
                            MessageBox.Show("A user with the same Login already exists!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Fill in all fields!");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            UsersUC usersUC = new UsersUC(ad,adminId);

            ad.UCgrid.Children.Clear();
            ad.UCgrid.Children.Add(usersUC);
        }
    }
}
