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
using SoulMelody.Admin;

using SoulMelody.Usermenu;

namespace SoulMelody
{
    /// <summary>
    /// Interaction logic for BookInfo.xaml
    /// </summary>
    public partial class BookInfo : Window
    {
        
        int bookId;
        int userId;
        public BookInfo(int bookId, int userId)
        {
            InitializeComponent();
            //ad = adminMenu;
            //ud = userMenu;
            this.bookId = bookId;
            this.userId = userId;

            using(var db=new LibraryDBEntities())
            {
                var book = db.Books.Find(bookId);
                BookName.Content = book.Name;
                BookAuthor.Content = book.Author.FName + " " + book.Author.LName;
                BookGenre.Content = book.Genre.Name;
                BookTheme.Content = book.Theme.Name;                
                Description.Text = book.Description;
                Location.Content = book.Location.Name;

                var user = db.Users.Find(userId);

                if (user.RoleID == 1)
                    AddToWs.Visibility = Visibility.Collapsed;


                if (book.Id % 2 == 0)
                {                   
                    var uriSource = new Uri(@"/SoulMelody;component/Images/cover1.jpg",
                        UriKind.Relative);
                    Cover.Source = new BitmapImage(uriSource);
                }
                if (book.Id % 2 != 0)
                {
                    var uriSource = new Uri(@"/SoulMelody;component/Images/cover2.jpg",
                        UriKind.Relative);
                    Cover.Source = new BitmapImage(uriSource);
                }
                if ( book.Id % 3 == 0)
                {
                    var uriSource = new Uri(@"/SoulMelody;component/Images/cover3.jpg",
                        UriKind.Relative);
                    Cover.Source = new BitmapImage(uriSource);
                }
                //else
                //{
                //    var uriSource = new Uri(@"/SoulMelody;component/Images/cover4.jpg",
                //       UriKind.Relative);
                //    Cover.Source = new BitmapImage(uriSource);
                //}

            }
        }



        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LibraryDBEntities())
            {
                try
                {

                    var recordTest = db.Wishlists.FirstOrDefault(r => r.UserID == userId && r.BookID == bookId);
                    if (recordTest == null)
                    {
                        var ws = new Wishlist
                        {
                            UserID = userId,
                            BookID = bookId,
                            Date = DateTime.Now
                        };

                        db.Wishlists.Add(ws);
                        db.SaveChanges();
                       
                        this.DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("This book has already been added!");
                        this.DialogResult = false;

                    }                  
                    
                }
                catch (Exception ex)
                {
                    this.DialogResult = false;
                    MessageBox.Show(ex.Message);
                }
            }
           
            
        }
    }
}
