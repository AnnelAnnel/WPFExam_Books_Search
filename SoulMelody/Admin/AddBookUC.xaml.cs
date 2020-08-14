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
    /// Interaction logic for AddBookUC.xaml
    /// </summary>
    public partial class AddBookUC : UserControl
    {
        AdminMenu ad;
        int adminId;

        public AddBookUC(AdminMenu adminMenu, int id)
        {
            InitializeComponent();
            ad = adminMenu;
            adminId = id;

            using (var db = new LibraryDBEntities())
            {
                
                var genres = from g in db.Genres
                             select new
                             {
                                 Id=g.Id,
                                 Name = g.Name
                             };

                GenresList.ItemsSource = genres.ToList();

                var themes = from g in db.Themes
                             select new
                             {
                                 Id = g.Id,
                                 Name = g.Name
                             };

                ThemesList.ItemsSource = themes.ToList();

                var locations = from g in db.Locations
                             select new
                             {
                                 Id = g.Id,
                                 Name = g.Name
                             };

                LocationList.ItemsSource = locations.ToList();


            }
        }

        private int AuthorCheck(string FName, string LName)
        {
            using (var db = new LibraryDBEntities())
            {

                var authorTest = db.Authors.FirstOrDefault(l => l.FName == FName && l.LName == LName);
                if (authorTest == null)
                {
                    var newAuthor = new Author
                    {
                        LName = LName,
                        FName = FName
                    };
                    db.Authors.Add(newAuthor);
                    db.SaveChanges();
                    return newAuthor.Id;
                }

                else
                {
                    return authorTest.Id;
                }

            }
        }      



        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LibraryDBEntities())
            {
                int genreID;
                int themeID;
                int locationID;

              
                try
                {

                    if (BName.Text != "" && AuthorFName.Text != "" && AuthorLName.Text != "" && Description.Text != "")
                    {


                        if (GenresList.SelectedItem == null)
                        {
                            genreID = 1;
                        }

                        else
                        {
                            var g = (int)GenresList.SelectedValue;
                            genreID = g;


                        }
                        if (ThemesList.SelectedItem == null)
                        {
                            themeID = 1;
                        }

                        else
                        {
                            var g = (int)ThemesList.SelectedValue;
                            themeID = g;


                        }
                        if (LocationList.SelectedItem == null)
                        {
                            locationID = 1;
                        }

                        else
                        {
                            var g = (int)LocationList.SelectedValue;
                            locationID = g;


                        }
                        var bookTest = db.Books.FirstOrDefault(l => l.Name == BName.Text && l.Author.LName == AuthorLName.Text);
                        if (bookTest == null)
                        {
                            int authorID = AuthorCheck(AuthorFName.Text, AuthorLName.Text);
                            var newBook = new Book
                            {
                                Name = BName.Text,
                                AuthorID = authorID,
                                Description = Description.Text,
                                LocationID = locationID,
                                GenreID = genreID,
                                ThemeID = themeID

                            };
                            db.Books.Add(newBook);
                            db.SaveChanges();

                            BooksUC booksUC = new BooksUC(ad, adminId);

                            ad.UCgrid.Children.Clear();
                            ad.UCgrid.Children.Add(booksUC);
                        }
                        else
                        {
                            MessageBox.Show("The same book already exists!");
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
            BooksUC booksUC = new BooksUC(ad, adminId);

            ad.UCgrid.Children.Clear();
            ad.UCgrid.Children.Add(booksUC);
        }
    }
}
