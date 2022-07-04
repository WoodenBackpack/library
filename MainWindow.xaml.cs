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
using System.Text.Json;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lib = new Library();
        }

        private ILibrary lib;

        private void addItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (addItemTitle.Text.Length > 0 && addItemAuthor.Text.Length > 0)
                {
                    string type = "";
                    if ((bool)isMovieRadio.IsChecked)
                    {
                        type = "MOV";
                    }
                    else if ((bool)isBookRadio.IsChecked)
                    {
                        type = "BOOK";
                    }
                    else if ((bool)isThesisRadio.IsChecked)
                    {
                        type = "THESIS";
                    }
                    else if ((bool)isMagazineRadio.IsChecked)
                    {
                        type = "MAG";
                    }
                    lib.AddNewItem(addItemTitle.Text,
                        addItemAuthor.Text,
                        type);
                }
            } catch (LibraryException ex)
            {
                errorLabel.Content = ex.Message;
            }
            reloadLists();
        }

        private void rentButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text.Length > 0 && surnameTextBox.Text.Length > 0 &&
                libItemsList.SelectedItem != null)
            {
                int idx = int.Parse(libItemsList.SelectedItem.ToString().Split(',')[1].Split(':')[1]);
                try {
                    lib.RentItem(idx, nameTextBox.Text, surnameTextBox.Text);
                }
                catch(LibraryException ex)
                {
                    errorLabel.Content = ex.Message;
                }
                reloadLists();
            }
        }

        private void reloadLists()
        {
            libItemsList.Items.Clear();
            List<string> libDesc = lib.GetAllDesc();
            foreach (var el in libDesc)
            {
                libItemsList.Items.Add(el);
            }
            rentalList.Items.Clear();
            List<string> rentDisc = lib.GetAllRents();
            foreach (var el in rentDisc)
            {
                rentalList.Items.Add(el);
            }
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            if (rentalList.SelectedItem != null)
            {
                int idx = int.Parse(rentalList.SelectedItem.ToString().Split(',')[0].Split(':')[1]);
                string name = rentalList.SelectedItem.ToString().Split(' ')[0];
                string surname = rentalList.SelectedItem.ToString().Split(' ')[1];
                try
                {
                    lib.ReturnItem(idx, name, surname);
                }
                catch (LibraryException ex)
                {
                    errorLabel.Content = ex.Message;
                }
                reloadLists();
            }
        }

        private void isMovieRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (ExtraLabel != null) {
                ExtraLabel.Content = "Reżyser";
            }
            
        }

        private void isMagazineRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (ExtraLabel != null)
            {
                ExtraLabel.Content = "Numer";
            }
        }

        private void isThesisRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (ExtraLabel != null)
            {
                ExtraLabel.Content = "Autorzy";
            }
        }

        private void isBookRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (ExtraLabel != null)
            {
                ExtraLabel.Content = "Autor";
            }
        }

        private void toFileButton_Click(object sender, RoutedEventArgs e) 
        {
            Microsoft.Win32.SaveFileDialog openFileDlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                MyJsonSerializer<Library> serializer = new MyJsonSerializer<Library>();
                string text = serializer.Serialize((Library)lib);
                System.IO.StreamWriter writer = new System.IO.StreamWriter(openFileDlg.FileName);
                writer.Write(text);
                writer.Close();
            }


        }

        private void fromFileButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(openFileDlg.FileName);
                MyJsonSerializer<Library> serializer = new MyJsonSerializer<Library>();
                ILibrary libToRead = serializer.Deserialize(reader.ReadToEnd());
                lib = libToRead;
                reader.Close();
            }
            reloadLists();
        }
    }
}
