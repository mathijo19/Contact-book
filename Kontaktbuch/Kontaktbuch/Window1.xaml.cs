using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace Kontaktbuch
{
    public partial class Window1 : Window
    {

        public Window1 ()
        {
            InitializeComponent();
            fieldforname.Text = "Vorname";
            fieldsurname.Text = "Nachname";
            fieldemail.Text = "e-mail";
            fieldnum.Text = "Telefonnummer";
        }
        private void button_click (object sender, RoutedEventArgs e)
        {
            bool state = true;
            if (string.IsNullOrEmpty(fieldforname.Text) || fieldforname.Text == "Vorname") {
                state = false;
                errorforname.Content = "Ungültiger Vorname!";
            }
            else
            {
                errorforname.Content = "";
            }

            if (string.IsNullOrEmpty(fieldsurname.Text) || fieldsurname.Text == "Nachname") {
                state = false;
                errorsurname.Content = "Ungültiger Vorname!";
            }
            else
            {
                errorsurname.Content = "";
            }

            if (string.IsNullOrEmpty(fieldemail.Text) || fieldemail.Text == "e-mail" || !Regex.IsMatch(fieldemail.Text, @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{2,3})$")) {
                state = false;
                erroremail.Content = "Ungültige E-Mail!";
            }
            else
            {
                erroremail.Content = "";
            }

            if (string.IsNullOrEmpty(fieldnum.Text) || fieldnum.Text == "Telefonnummer")
            {
                state = false;
                errornum.Content = "Ungültige Telefonnummer!";
            }
            else
            {
                errornum.Content = "";
            }
            if (state == true )  //in each field has to be a valid entry
            {
                errorforname.Content = "";
                errorsurname.Content = "";
                erroremail.Content = "";
                errornum.Content = "";
                addContact(fieldforname.Text, fieldsurname.Text, fieldemail.Text, fieldnum.Text, @"C:\\Users\\mgemke\\Desktop\\data\\bilder\\standard.jfif");
                fieldforname.Text = "Vorname";
                fieldsurname.Text = "Nachname";
                fieldemail.Text = "e-mail";
                fieldnum.Text = "Telefonnummer";
            }
        }
        private void addContact (string forname, string surname, string email, string tele, string picture)
        {
            Contact newcontact = new Contact(Globals.listcontact.Count, forname, surname, email, tele, picture);
            Globals.addedContact = newcontact;
            MainWindow mainwindow = new MainWindow();
            mainwindow.BeginInit();
            mainwindow.Show();
            this.Close();
        }
    }
}