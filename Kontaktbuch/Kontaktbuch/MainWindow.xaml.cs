using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


namespace Kontaktbuch
{   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); //builds the window
            List<Contact> contacts = Data.Read();  //the data is saved in a txt file and will be loaded to the list
            if (Globals.addedContact != null)
            {
                contacts.Add(Globals.addedContact);
            }
            datagridcontacts.ItemsSource= contacts; //data will be loaded to datagrid
            Globals.listcontact = contacts;
            Data.Write(Globals.listcontact);
            datagridcontacts.CanUserSortColumns = true; //user is allowed to Sort the contacts
            datagridcontacts.CanUserResizeColumns = true; //user is allowed to change the size of the columns
            
        }
        private void deletecontact(object sender, RoutedEventArgs e)
        {
            if (datagridcontacts.SelectedIndex >= 0) //user has to select a contact to delete a contact
            {
                Globals.listcontact.RemoveAt(datagridcontacts.SelectedIndex); //the selected contact is removed from the list
                Data.Write(Globals.listcontact); //new data is written to the txt file
                List<Contact> contacts = Data.Read();
                datagridcontacts.ItemsSource = contacts; //new data is added to the datagrid
                Globals.listcontact = contacts;
            }
            else
            {
                displayforname.Text = "Kontakt auswählen!"; //if user doesn't select a contact there will be a error message
            }
        }

        private void savechanges(object sender, RoutedEventArgs e)
        {
            bool state = true;
            if (string.IsNullOrEmpty(displayforname.Text) || displayforname.Text == "Vorname")
            {
                state = false;
                errorforname.Content = "Ungültiger Vorname!";
            }
            else
            {
                errorforname.Content = "";
            }

            if (string.IsNullOrEmpty(displaysurname.Text) || displaysurname.Text == "Nachname")
            {
                state = false;
                errorsurname.Content = "Ungültiger Vorname!";
            }
            else
            {
                errorsurname.Content = "";
            }

            if (string.IsNullOrEmpty(displayemail.Text) || displayemail.Text == "e-mail" || !Regex.IsMatch(displayemail.Text, @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{2,3})$"))
            {
                state = false;
                erroremail.Content = "Ungültige E-Mail!";
            }
            else
            {
                erroremail.Content = "";
            }

            if (string.IsNullOrEmpty(displaynum.Text) || displaynum.Text == "Telefonnummer")
            {
                state = false;
                errornum.Content = "Ungültige Telefonnummer!";
            }
            else
            {
                errornum.Content = "";
            }
            if (state == true && datagridcontacts.SelectedIndex >= 0)  //in each field has to be a valid entry
            {
                errorforname.Content = "";
                errorsurname.Content = "";
                erroremail.Content = "";
                errornum.Content = "";
                Contact newkontakt = new Contact(datagridcontacts.SelectedIndex, displayforname.Text, displaysurname.Text, displayemail.Text, displaynum.Text, Globals.listcontact[datagridcontacts.SelectedIndex].pathpic); //creates new contact
                Globals.listcontact[datagridcontacts.SelectedIndex] = newkontakt; //old contact gets overwrited from the new contact
                Data.Write(Globals.listcontact); //adds data to txt file
                List<Contact> contacts = Data.Read();
                datagridcontacts.ItemsSource = contacts; //adds data to datagrid
                Globals.listcontact = contacts;
                displayforname.Text = "Vorname";
                displaysurname.Text = "Nachname";
                displayemail.Text = "e-mail";
                displaynum.Text = "Telefonnummer";
            }
            else
            {
                errorforname.Content = "Kontakt auswählen!";
            }
        }

        private void Buttonchangepicture(object sender, RoutedEventArgs e)
        {
            if(datagridcontacts.SelectedIndex >= 0) //user has to select a contact
            {
                OpenFileDialog openDialog = new OpenFileDialog(); 
                openDialog.Filter = "Image files<|*.bmp;*.jpg;*.png;*.jfif";
                openDialog.FilterIndex = 1; 
                if (openDialog.ShowDialog() == true) //if file explorer is opened
                {
                    imagePicture.Source = new BitmapImage(new Uri(openDialog.FileName));
                    Globals.listcontact[datagridcontacts.SelectedIndex].pathpic = openDialog.FileName; //save the path of picture in the list
                }
                Data.Write(Globals.listcontact); //add data to txt file
                List<Contact> contacts = Data.Read();
                datagridcontacts.ItemsSource = contacts; //adds data to datagrid
                Globals.listcontact = contacts;
            }            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagridcontacts.SelectedIndex >= 0) //user has to select a contact
            {
                displayforname.Text = Globals.listcontact[datagridcontacts.SelectedIndex].forname; //displays the forname
                displaysurname.Text = Globals.listcontact[datagridcontacts.SelectedIndex].name; //displays the surname
                displayemail.Text = Globals.listcontact[datagridcontacts.SelectedIndex].email; //displays the e-mail
                displaynum.Text = Globals.listcontact[datagridcontacts.SelectedIndex].phonenum; //displays the phone number

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(Globals.listcontact[datagridcontacts.SelectedIndex].pathpic); //makes path of picture to a bitmap
                bitmap.EndInit();
                imagePicture.Source = bitmap; //this 5 lines show the picture 
            }
        }

        private void openwindow(object sender, RoutedEventArgs e)
        {
            Window1 objWindow1 = new Window1();
            objWindow1.Show();
            Close();
        }
    }
}
