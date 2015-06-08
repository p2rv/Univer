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

namespace Univer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    class Specialty
    {
        private string specialtyCode;
        public string FullName { get; set; }
        public virtual string Name { get; set; }
        public string SpecialtyCode 
        {
            get { return specialtyCode; }
            set 
            {
                Regex reg = new Regex(@"[^0-9]|\S"); //Здесь что то не работает
                if(reg.IsMatch(value))
                    specialtyCode = value; 
                else
                     throw new FormatException();
            } 
        }
    }
    class Group:Specialty
    {
        private DateTime year;
        private byte index;
        public override string Name
        {
            get { return base.Name + "-" + year.Year.ToString() + "-" + index.ToString(); }
        }
       // public Specialty 
    }
    struct Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    struct Student
    {
        private Person person;
        public string FirstName
        {
            get { return person.FirstName; }
            set { person.FirstName = value; }
        }
        public string LastName
        {
            get { return person.LastName; }
            set { person.LastName = value; }
        }
    }
    struct Teacher
    {
        private Person person;
        public string FirstName
        {
            get { return person.FirstName; }
            set { person.FirstName = value; }
        }
        public string LastName
        {
            get { return person.LastName; }
            set { person.LastName = value; }
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Specialty spec = new Specialty();
            spec.Name = tBox1.Text;
            spec.FullName = tBox2.Text;
            spec.SpecialtyCode = tBox3.Text;
        }
    }
}
