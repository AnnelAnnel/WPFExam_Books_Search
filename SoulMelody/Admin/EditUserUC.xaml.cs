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
    /// Interaction logic for EditUserUC.xaml
    /// </summary>
    public partial class EditUserUC : UserControl
    {
        private AdminMenu ad;
        private int userId;
        private int adminId;
        public EditUserUC(AdminMenu ad, int id, int adminId)
        {
            InitializeComponent();
            this.ad = ad;
            userId = id;
            this.adminId = adminId;

            using (LibraryDBEntities db = new LibraryDBEntities())
            {
                var user = db.Users.Find(id);

                LName.Text = user.LName;
                FName.Text = user.FName;
                Login.Text = user.Login;
                Password.Text = user.Password;
                Email.Text = user.Email;                
            }
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (LibraryDBEntities db = new LibraryDBEntities())
                {
                    var editedDUser = db.Users.Find(userId);
                    if (Login.Text != "" && Password.Text != "" && LName.Text != "" && FName.Text != ""
                        && Email.Text != "")
                    {

                        editedDUser.LName = LName.Text;
                        editedDUser.FName = FName.Text;
                        editedDUser.Email = Email.Text;
                        editedDUser.Login = Login.Text;
                        editedDUser.Password = Password.Text;
                        if (editedDUser.Id == 1)
                        {
                            editedDUser.RoleID = editedDUser.RoleID;
                            MessageBox.Show("You cannot change your role! Leave it as Admin!");
                        }                        

                        else
                        {
                            if (RolesList.SelectedItem == null)
                            {
                                editedDUser.RoleID = editedDUser.RoleID;
                            }
                            else
                                editedDUser.RoleID = RolesList.SelectedIndex + 1;

                        }


                        db.SaveChanges();

                        UsersUC usersUC = new UsersUC(ad, adminId);

                        ad.UCgrid.Children.Clear();
                        ad.UCgrid.Children.Add(usersUC);


                    }
                    else
                    {
                        MessageBox.Show("Do not leave any field empty!");
                    }


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            UsersUC usersUC = new UsersUC(ad, adminId);

            ad.UCgrid.Children.Clear();
            ad.UCgrid.Children.Add(usersUC);
        }
    }
}
