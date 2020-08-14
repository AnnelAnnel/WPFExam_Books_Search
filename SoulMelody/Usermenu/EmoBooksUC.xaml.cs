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
    /// Interaction logic for EmoBooksUC.xaml
    /// </summary>
    public partial class EmoBooksUC : UserControl
    {

        UserMenu menu;
        int userId;
        int emotionId;
        public EmoBooksUC(UserMenu userMenu, int userId, int emotionId)
        {

            InitializeComponent();
            menu = userMenu;
            this.userId = userId;
            GenresList.SelectedIndex = -1;
            ThemesList.SelectedIndex = -1;
            this.emotionId = emotionId;


            using (var db = new LibraryDBEntities())
            {
               

                var gnrs = from j in db.RGEs
                           where j.EmotionID == emotionId
                           select new
                           {
                               Id = j.GenreID,
                               Name = j.Genre.Name
                           };

                var tms = from t in db.RTEs
                           where t.EmotionID == emotionId
                           select new
                           {
                               Id = t.ThemeID,
                               Name = t.Theme.Name
                           };               

                GenresList.ItemsSource = gnrs.ToList();

                ThemesList.ItemsSource = tms.ToList();        

               


            }
        }

        private void NameFilteText_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }

        private void AuthorFilterText_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void GenresList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ThemesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LibraryDBEntities())
            {


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
    }
}
