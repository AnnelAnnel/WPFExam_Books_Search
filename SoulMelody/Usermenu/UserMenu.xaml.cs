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

namespace SoulMelody.Usermenu
{
    /// <summary>
    /// Interaction logic for UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Window
    {
        private int userId;
        public UserMenu(int id)
        {
            InitializeComponent();
            userId = id;

            var uriSource = new Uri(@"/SoulMelody;component/studyWhiteLogo.png",
                   UriKind.Relative);
            Logo.Source = new BitmapImage(uriSource);

            using (LibraryDBEntities db = new LibraryDBEntities())
            {
                var user = db.Users.Find(userId);

                Greeting.Content = "Hello, " + user.FName + " " + user.LName + "!";
            }
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {


            if (ListViewMenu.SelectedIndex == 0)
            {
                
                //UsersUC usersUC = new UsersUC(this, userId);

                //UCgrid.Children.Clear();
                //UCgrid.Children.Add(usersUC);
            }
        }

      

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewMenu.SelectedIndex == 1)
            {

                BooksUserUC booksUC = new BooksUserUC(this, userId);

                UCgrid.Children.Clear();
                UCgrid.Children.Add(booksUC);
            }

            if (ListViewMenu.SelectedIndex == 2)
            {
                //MessageBox.Show("Books were pressed");
                //BooksUC booksUC = new BooksUC(this, userId);

                
                EmoSearchUC emoSearchUC = new EmoSearchUC(this, userId);
                UCgrid.Children.Clear();
                UCgrid.Children.Add(emoSearchUC);

            }

            if (ListViewMenu.SelectedIndex == 3)
            {
                WishlistUC wishlistUC = new WishlistUC(this, userId);
                UCgrid.Children.Clear();
                UCgrid.Children.Add(wishlistUC);

            }


            
            if (ListViewMenu.SelectedIndex == 4)
            {
                this.Close();
            }
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
