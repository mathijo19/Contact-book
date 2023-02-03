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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kontaktbuch
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class Globals
    {
        public static List<Contact> listcontact = new List<Contact>(); //All the contacts are saved in this list
        public static Contact addedContact;

        public static bool IsValidEmail(string email)
        {
            if (!Regex.IsMatch(email, @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{2,3})$")) //the e-mail has to have an "@", it can have a "." in the local part, the domain part has to end with 2 or 3 characters, in the domain part aren't any special characters allowd
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
