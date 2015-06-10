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
                Regex reg =  new Regex(@"[^0-9.]+");
                if(!reg.IsMatch(value))
                    specialtyCode = value; 
                else
                     throw new FormatException();
            } 
        }
    }
    class Group:Specialty
    {
        private int year;
        private byte number;
        public Group(byte number,int year)
        {
            this.number = number;
            if (year > 2000 && year < 2100)
                this.year = year;
            else
                throw new FormatException();
        }
        public override string Name
        {
            get { return base.Name + "-" + year.ToString() + "-" + number.ToString(); }
        }
        public int Year 
        {
            get { return year; }
            set
            {
                if (year > 2000 && year < 2100)
                    year = value;
                else
                    throw new FormatException();
            } 
        }
    }
    class PersonalData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateofBirth { get; set; }

    }
    class Student:PersonalData
    {
        private int studentIDNumber;
        private Group group;
        private byte courseNumber;
        private bool starosta;
        public int StudentIDNumber { get { return studentIDNumber; } }
    }
    class Teacher:PersonalData
    {
       
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Group spec = new Group(1, 2015);
            spec.Name = tBox1.Text;
            spec.FullName = tBox2.Text;
            spec.SpecialtyCode = tBox3.Text;
        }
    }
}
