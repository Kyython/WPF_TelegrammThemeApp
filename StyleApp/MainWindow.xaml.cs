using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace StyleApp
{
    public partial class MainWindow : Window
    {
        private List<Dialog> _templateDialogList = new List<Dialog>();

        private Dialog _selectedItem;

        public MainWindow()
        {
            InitializeComponent();
            ThemeChange("WhiteTheme.xaml");

            List<Dialog> dialogs = new List<Dialog>
            {
                new Dialog { NamePerson = "Pikachu", ImagePerson = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/pokemon-detective-pikachu-1-1552650378.jpg?crop=0.411xw:0.988xh;0.355xw,0.00833xh&resize=480:*" },
                new Dialog { NamePerson = "Naruto" }
            };

            foreach (var person in dialogs)
            {
                personListBoxData.Items.Add(person);
            }

            foreach (var person in personListBoxData.Items)
            {
                _templateDialogList.Add(person as Dialog);
            }
        }

        private void Changed(object sender, SelectionChangedEventArgs e)
        {
            dialogListBox.Items.Clear();
            _selectedItem = personListBoxData.SelectedItem as Dialog;
            var defaultImage = "https://forwardsummit.ca/wp-content/uploads/2019/01/avatar-default.png";

            if (_selectedItem != null)
            {
                if (_selectedItem.ImagePerson != null)
                {
                    personImage.Source = new BitmapImage(new Uri(_selectedItem.ImagePerson));
                }
                else
                {
                    personImage.Source = new BitmapImage(new Uri(defaultImage));
                }

                if (_selectedItem.TextDialog != null)
                {
                    foreach (var dialog in _selectedItem.TextDialog)
                    {

                        dialogListBox.Items.Add(dialog);
                    }
                }
            }
        }

        private void SendTextButton(object sender, RoutedEventArgs e)
        {
            if (_selectedItem != null)
            {
                _selectedItem.TextDialog.Add(dialogText.Text);
                dialogListBox.Items.Add(dialogText.Text);
            }
        }

        private void SearchTextBox(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(searchTextBox.Text.Trim()))
            {
                personListBoxData.Items.Clear();

                foreach (var item in _templateDialogList)
                {
                    if (item.NamePerson.ToLower().StartsWith(searchTextBox.Text.ToLower().Trim()))
                    {
                        personListBoxData.Items.Add(item);
                    }
                }
            }

            else if (searchTextBox.Text.Trim() == string.Empty)
            {
                personListBoxData.Items.Clear();

                foreach (var item in _templateDialogList)
                {
                    personListBoxData.Items.Add(item);
                }
            }
        }

        private void DarkThemeButton(object sender, RoutedEventArgs e)
        {
            ThemeChange("DarkTheme.xaml");
        }

        private void WhiteThemeButton(object sender, RoutedEventArgs e)
        {
            ThemeChange("WhiteTheme.xaml");
        }

        private void ThemeChange(string ThemeNameFile)
        {
            var uri = new Uri(ThemeNameFile, UriKind.Relative);

            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;

            Application.Current.Resources.Clear();

            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}