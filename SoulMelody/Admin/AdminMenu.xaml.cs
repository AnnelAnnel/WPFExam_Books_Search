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

namespace SoulMelody.Admin
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        private int userId;
        public AdminMenu(int id)
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
            //int firstIndex = ListViewMenu.SelectedIndex;


            if (ListViewMenu.SelectedIndex==0) {
                
                UsersUC usersUC = new UsersUC(this, userId);

                UCgrid.Children.Clear();
                UCgrid.Children.Add(usersUC);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UsersUC usersUC = new UsersUC(this, userId);

            UCgrid.Children.Clear();
            UCgrid.Children.Add(usersUC);
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewMenu.SelectedIndex == 0)
            {                
                

            }

            if (ListViewMenu.SelectedIndex == 2)
            {
               
                BooksUC booksUC = new BooksUC(this, userId);

                UCgrid.Children.Clear();
                UCgrid.Children.Add(booksUC);

            }

            if (ListViewMenu.SelectedIndex == 1)
            {
                UsersUC usersUC = new UsersUC(this, userId);

                UCgrid.Children.Clear();
                UCgrid.Children.Add(usersUC);

            }

            
            if (ListViewMenu.SelectedIndex == 3)
            {
                this.Close();
            }
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
