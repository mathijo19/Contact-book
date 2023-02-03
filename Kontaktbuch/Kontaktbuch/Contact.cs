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

namespace Kontaktbuch
{
    public partial class Contact
    {
        public int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string forname; // field

        public string Forname   // property
        {
            get { return forname; }   // get method
            set { forname = value; }  // set method
        }
        public string name; // field

        public string Name   // property
        {
            get { return name; }   // get method
            set { name = value; }  // set method
        }

        public string email; // field

        public string Email   // property
        {
            get { return email; }   // get method
            set { email = value; }  // set method
        }
        public string phonenum; // field

        public string Phonenum   // property
        {
            get { return phonenum; }   // get method
            set { phonenum = value; }  // set method
        }

        public string pathpic;

        public string Pathpic
        {
            get { return pathpic; }
            set { pathpic = value; }
        }

        public Contact(int id, string forname, string name, string email, string phonenum, string pathpic) //constructor 
        {
            Id = id;
            Forname = forname;
            Name = name;
            Email = email;
            Phonenum = phonenum;
            Pathpic = pathpic;
        }
        public override string ToString()
        {
            return id + "," + forname + "," + name + "," + email + "," + phonenum + "," + pathpic;
        }
    }
}
