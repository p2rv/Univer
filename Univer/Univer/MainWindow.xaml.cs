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

namespace Univer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    struct Specialty
    {
        private string specialtyCode;
        public string FullName { get; set; }
        public string SpecialtyCode 
        {
            get { return specialtyCode; }
            set { specialtyCode = value; } //сюда необходимо добавить проверку на корректность значения 
        }
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
    }
}
