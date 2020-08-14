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
    /// Interaction logic for UsersUC.xaml
    /// </summary>
    public partial class UsersUC : UserControl
    {
        //StartWindow st;
        AdminMenu ad;
        int adminId;
        //private List<User> users;
        public UsersUC(AdminMenu adminMenu, int id)
        {
            InitializeComponent();
            ad = adminMenu;
            adminId = id;
            // st = receivedWindow;
            //users = new List<User>();
           using(var db=new LibraryDBEntities())
            {

                //users = db.Users.ToList();
                var users = from u in db.Users
                            select new
                            {
                                Id = u.Id,
                                FName = u.FName,
                                LName = u.LName,
                                Login = u.Login,
                                Password = u.Password,
                                Email = u.Email,
                                Role = u.Role.Name

                            };
                Users.ItemsSource = users.ToList();

            }
        }

        

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUseUC addUserUC = new AddUseUC(ad, adminId);


            //UsersUC usersUC = new UsersUC(ad);

            ad.UCgrid.Children.Clear();
            ad.UCgrid.Children.Add(addUserUC);
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            //User editedUser = (User)Users.SelectedItem;

            //// var id = Convert.ToInt32(Users.SelectedItem.Cells["Id"].Value)
            //var item = Users.SelectedItem;

            try
            {
                
                
                if (Users.SelectedItems != null)
                {
                    dynamic selectedItem = Users.SelectedItems[0];
                    int d = (int)selectedItem.Id;

                    EditUserUC editUserUC = new EditUserUC(ad, d, adminId);

                    ad.UCgrid.Children.Clear();
                    ad.UCgrid.Children.Add(editUserUC);
                }

                else
                {
                    MessageBox.Show("Select a user!");
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Select a user!");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LibraryDBEntities())
            {

                try
                {
                    if (db.Users.Any())
                    {
                        dynamic selectedItem = Users.SelectedItems[0];
                        if (selectedItem != null)
                        {
                            int id = (int)selectedItem.Id;
                            var userToDelete = db.Users.Find(id);
                            if (id != adminId)
                            {
                                if (userToDelete.Id != 1)
                                {

                                    db.Users.Remove(userToDelete);

                                    db.SaveChanges();
                                    MessageBox.Show("User info about " + userToDelete.FName + " " + userToDelete.LName + " was deleted");
                                    UsersUC usersUC = new UsersUC(ad, adminId);

                                    ad.UCgrid.Children.Clear();
                                    ad.UCgrid.Children.Add(usersUC);
                                }
                                else
                                {
                                    MessageBox.Show("You cannot destroy your Creator!!!!!");
                                }

                            }
                            else
                            {
                                MessageBox.Show("You cannot delete yourself!");
                            }
                        }



                    }
                    else
                    {
                        MessageBox.Show("No users existed!");
                    }

                }
                catch (Exception)
                {

                    MessageBox.Show("Select a user!");
                }

            }
        }

      
    }
}
