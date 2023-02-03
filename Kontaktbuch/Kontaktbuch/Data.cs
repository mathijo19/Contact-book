using System;
using System.Collections.Generic;
using System.IO;
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

namespace Kontaktbuch
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class Data
    {
        public static List<Contact> Read()
        {
            List<Contact> contactlist = new List<Contact>();
            string filename = @"C:/Users/mgemke/Desktop/data/contacts.txt"; //this is the txt file where the data is saved
            try
            {
                string line;

                StreamReader reader = new StreamReader(filename);
                while ((line = reader.ReadLine()) != null) //the data will be added to the list while every line has content
                {
                    string[] subs = line.Split(','); //data is splited and this command will split one string to 6 strings (ID, forname, surname, e-mail, phone number and path of picture)
                    contactlist.Add(new Contact(int.Parse(subs[0]), subs[1], subs[2], subs[3], subs[4], subs[5])); //each attribute is saved in one array element
                }
                reader.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message); //when txt file can't get opened there will be a error message
            }
            return contactlist;
        }

        public static void Write(List<Contact> contactlist)
        {
            for (int i = 0; i < contactlist.Count; i++) //program changes the id of the contacts automatically (first contact gets ID 0, second ID 1...)
            {
                contactlist[i].id = i;
            }
            string filename = @"C:/Users/mgemke/Desktop/data/contacts.txt"; //txt file
            StreamWriter writer = new StreamWriter(filename);

            foreach (Contact a in contactlist)
            {
                writer.WriteLine(a); //each element will be added to the txt file
            }
            writer.Close();
        }
    }
}
