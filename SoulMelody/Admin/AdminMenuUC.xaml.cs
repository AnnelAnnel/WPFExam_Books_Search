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
    /// Interaction logic for AdminMenuUC.xaml
    /// </summary>
    public partial class AdminMenuUC : UserControl
    {
        private StartWindow st;
        private int userId;
        public AdminMenuUC(StartWindow receivedWindow,  int userId)
        {
            InitializeComponent();
            st = receivedWindow;
            this.userId = userId;
            using (LibraryDBEntities db = new LibraryDBEntities())
            {
                var user = db.Users.Find(userId);

               // Greeting.Content = "Hello" + user.FName + " " + user.LName + "!";
            }
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            //UsersUC usersUc = new UsersUC(st);
            //st.startGrid.Children.Clear();
            //st.startGrid.Children.Add(usersUc);
        }
    }
}
