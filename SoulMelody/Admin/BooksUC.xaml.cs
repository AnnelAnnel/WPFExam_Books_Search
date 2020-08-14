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
    /// Interaction logic for BooksUC.xaml
    /// </summary>
    public partial class BooksUC : UserControl
    {
        AdminMenu ad;
        int adminId;
        List<IQueryable> books2;


        public BooksUC(AdminMenu adminMenu, int id)
        {
            InitializeComponent();
            ad = adminMenu;
            adminId = id;
            //books2 = new List<IQueryable>();
            GenresList.SelectedIndex = -1;
            ThemesList.SelectedIndex = -1;

            using (var db = new LibraryDBEntities())
            {


                var books = from u in db.Books
                            select new
                            {
                                Id = u.Id,
                                Name = u.Name,
                                Author = u.Author.FName + " " + u.Author.LName,
                                Genre = u.Genre.Name,
                                Theme = u.Theme.Name,
                                Location = u.Location.Name,
                                Description = u.Description

                            };

                //books2 = books as List<IQueryable>;
                //string type = books.GetType().ToString();

                //MessageBox.Show(type);
                Books.ItemsSource = books.ToList();
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Books.ItemsSource);
                //Sview.Filter = BookFilter;

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


            }
        }

        //private bool BookFilter(object obj)
        //{
        //    if (String.IsNullOrEmpty(NameFilteText.Text))
        //        return true;
        //    else
        //    {
        //        return false;
        //        //return (obj.IndexOf(NameFilteText.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        //    }
          
        //}


        private void GenresList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddBookUC addBookUC = new AddBookUC(ad, adminId);
            ad.UCgrid.Children.Clear();
            ad.UCgrid.Children.Add(addBookUC);
        }

        //private void EditBtn_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void NameFilteText_TextChanged(object sender, TextChangedEventArgs e)
        //{
            
        //}

        //private void AuthorFilterText_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    CollectionViewSource.GetDefaultView(Books.ItemsSource).Refresh();
        //}

        private void GenresList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //CollectionViewSource.GetDefaultView(Books.ItemsSource).Refresh();
        }

        private void ThemesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //CollectionViewSource.GetDefaultView(Books.ItemsSource).Refresh();
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LibraryDBEntities())
            {
                //var filteredBooks = Books.ItemsSource;

                if (NameFilteText.Text != "" && AuthorFilterText.Text != "" &&
                     GenresList.SelectedIndex != -1 && ThemesList.SelectedIndex != -1)
                {
                    var filteredBooks = from u in db.Books
                                        where u.Name.Contains(NameFilteText.Text)
                                        where u.Author.LName.Contains(AuthorFilterText.Text)
                                        where u.Genre.Name == GenresList.Text
                                        where u.Theme.Name == ThemesList.Text
                                        select new
                                        {
                                            Id = u.Id,
                                            Name = u.Name,
                                            Author = u.Author.FName + " " + u.Author.LName,
                                            Genre = u.Genre.Name,
                                            Theme = u.Theme.Name,
                                            Location = u.Location.Name,
                                            Description = u.Description

                                        };


                    Books.ItemsSource = filteredBooks.ToList();
                    //CollectionViewSource.GetDefaultView(Books.ItemsSource).Refresh();
                }

                if (NameFilteText.Text != "")
                {
                    var filteredBooks = from u in db.Books
                                       
                                        where u.Name.Contains(NameFilteText.Text)
                                        select new
                                        {
                                            Id = u.Id,
                                            Name = u.Name,
                                            Author = u.Author.FName + " " + u.Author.LName,
                                            Genre = u.Genre.Name,
                                            Theme = u.Theme.Name,
                                            Location = u.Location.Name,
                                            Description = u.Description

                                        };


                    Books.ItemsSource = filteredBooks.ToList();
                    //CollectionViewSource.GetDefaultView(Books.ItemsSource).Refresh();
                }

                if (AuthorFilterText.Text != "")
                {
                    var filteredBooks = from u in db.Books
                                        where u.Author.LName.Contains(AuthorFilterText.Text)

                                        select new
                                        {
                                            Id = u.Id,
                                            Name = u.Name,
                                            Author = u.Author.FName + " " + u.Author.LName,
                                            Genre = u.Genre.Name,
                                            Theme = u.Theme.Name,
                                            Location = u.Location.Name,
                                            Description = u.Description

                                        };


                    Books.ItemsSource = filteredBooks.ToList();
                    //CollectionViewSource.GetDefaultView(Books.ItemsSource).Refresh();
                }
                if (GenresList.SelectedIndex != -1 && ThemesList.SelectedIndex != -1)

                {
                    var filteredBooks = from u in db.Books
                                        where u.Name.Contains(NameFilteText.Text)
                                        where u.Author.LName.Contains(AuthorFilterText.Text)
                                        where u.Genre.Name == GenresList.Text
                                        where u.Theme.Name == ThemesList.Text
                                        select new
                                        {
                                            Id = u.Id,
                                            Name = u.Name,
                                            Author = u.Author.FName + " " + u.Author.LName,
                                            Genre = u.Genre.Name,
                                            Theme = u.Theme.Name,
                                            Location = u.Location.Name,
                                            Description = u.Description

                                        };


                    Books.ItemsSource = filteredBooks.ToList();
                    //CollectionViewSource.GetDefaultView(Books.ItemsSource).Refresh();
                }

                if (GenresList.SelectedIndex == -1 && ThemesList.SelectedIndex != -1)

                {
                    var filteredBooks = from u in db.Books
                                        where u.Name.Contains(NameFilteText.Text)
                                        where u.Author.LName.Contains(AuthorFilterText.Text)                                                                    

                                        where u.Theme.Name == ThemesList.Text
                                        select new
                                        {
                                            Id = u.Id,
                                            Name = u.Name,
                                            Author = u.Author.FName + " " + u.Author.LName,
                                            Genre = u.Genre.Name,
                                            Theme = u.Theme.Name,
                                            Location = u.Location.Name,
                                            Description = u.Description

                                        };


                    Books.ItemsSource = filteredBooks.ToList();
                    //CollectionViewSource.GetDefaultView(Books.ItemsSource).Refresh();
                }

                if (GenresList.SelectedIndex != -1 && ThemesList.SelectedIndex == -1)

                {
                    var filteredBooks = from u in db.Books
                                        where u.Name.Contains(NameFilteText.Text)
                                        where u.Author.LName.Contains(AuthorFilterText.Text)
                                        where u.Genre.Name == GenresList.Text
                                  
                                        select new
                                        {
                                            Id = u.Id,
                                            Name = u.Name,
                                            Author = u.Author.FName + " " + u.Author.LName,
                                            Genre = u.Genre.Name,
                                            Theme = u.Theme.Name,
                                            Location = u.Location.Name,
                                            Description = u.Description

                                        };


                    Books.ItemsSource = filteredBooks.ToList();
                    //CollectionViewSource.GetDefaultView(Books.ItemsSource).Refresh();
                }
            }
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LibraryDBEntities())
            {


                var books = from u in db.Books
                            select new
                            {
                                Id = u.Id,
                                Name = u.Name,
                                Author = u.Author.FName + " " + u.Author.LName,
                                Genre = u.Genre.Name,
                                Theme = u.Theme.Name,
                                Location = u.Location.Name,
                                Description = u.Description

                            };
                                
                Books.ItemsSource = books.ToList();
                NameFilteText.Text = "";
                AuthorFilterText.Text = "";
                GenresList.SelectedIndex = -1;
                GenresList.Text = "";

                ThemesList.SelectedIndex = -1;
                ThemesList.Text = "";



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
                        int bookId = (int)selectedItem.Id;
                        BookInfo bookInfo = new BookInfo(bookId, adminId);

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
    }
}

