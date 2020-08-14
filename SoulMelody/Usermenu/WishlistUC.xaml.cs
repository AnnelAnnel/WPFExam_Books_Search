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

namespace SoulMelody.Usermenu
{
    /// <summary>
    /// Interaction logic for WishlistUC.xaml
    /// </summary>
    public partial class WishlistUC : UserControl
    {
        UserMenu userMenu;
        int userId;
        public WishlistUC(UserMenu um, int userId)
        {
            InitializeComponent();
            userMenu = um;
            this.userId = userId;
            using (var db = new LibraryDBEntities())
            {

                var books = from u in db.Wishlists
                            where u.UserID==userId
                            select new
                            {
                                Id = u.Id,
                                Name = u.Book.Name,
                                Author = u.Book.Author.FName + " " + u.Book.Author.LName,
                                Genre = u.Book.Genre.Name,
                                Theme = u.Book.Theme.Name,
                                Location = u.Book.Location.Name,
                                Description = u.Book.Description

                            };


                Books.ItemsSource = books.ToList();
            }
        }

        private void ShowInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Books.SelectedItems.Count != 0)
                {
                    dynamic selectedItem = Books.SelectedItems[0];
                    if (selectedItem != null)
                    {
                        int recordId = (int)selectedItem.Id;

                        int bookId;
                        using (var db = new LibraryDBEntities())
                        {
                            var recordToShow = db.Wishlists.Find(recordId);

                            bookId = (int)recordToShow.BookID;

                        }
                        BookInfo bookInfo = new BookInfo(bookId, userId);

                        if (bookInfo.ShowDialog() == true)
                        {
                            MessageBox.Show("The book has been added to your wishlist");
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                if (Books.SelectedItems.Count != 0)
                {
                    dynamic selectedItem = Books.SelectedItems[0];
                    if (selectedItem != null)
                    {
                        int recordId = (int)selectedItem.Id;
                        using (var db = new LibraryDBEntities())
                        {
                            var recordTodelete = db.Wishlists.Find(recordId);

                            db.Wishlists.Remove(recordTodelete);

                            db.SaveChanges();

                            MessageBox.Show("Book was deleted");
                            var books = from u in db.Wishlists
                                        where u.UserID == userId
                                        select new
                                        {
                                            Id = u.Id,
                                            Name = u.Book.Name,
                                            Author = u.Book.Author.FName + " " + u.Book.Author.LName,
                                            Genre = u.Book.Genre.Name,
                                            Theme = u.Book.Theme.Name,
                                            Location = u.Book.Location.Name,
                                            Description = u.Book.Description

                                        };


                            Books.ItemsSource = books.ToList();


                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
