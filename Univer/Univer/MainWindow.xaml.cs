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
    enum CourceNumber { First,Second,Third,Fourth,Fifth,Finished}
    enum Week { Monday_up, Tuesday_up, Widnesday_up, Thursday_up, Friday_up, Saturday_up, Monday_down, Tuesday_down, Widnesday_down, Thursday_down, Friday_down, Saturday_down }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    class University
    {
        string name;
        List<Facultet> facultetList;
    }
    class Facultet
    {
        private List<DisciplinePlan> planList;
        private List<Group> groupList;
        private List<Specialty> specList;
        private List<Teacher> teacherList;

        public string FacultetName { get; set; }

    }
    class DisciplinePlan
    {
        private const int MAXhourceNumberOfMonth = 300; //данная цифра взята методом научного тыка и возможно не является достоверной
        private Discipline discipline;
        private Specialty spec;
        private int hourceNumber;
        public DisciplinePlan(Discipline discipline,Specialty spec,int hourceNumber)
        {
            Disp = discipline;
            Spec = spec;
            HourceNumber = hourceNumber;
        }
        public DisciplinePlan(DisciplinePlan dispPlan)
        {
            if(dispPlan!=null)
            {
                Disp = dispPlan.DisciplineName;
                Spec = dispPlan.SpecialtyName;
                HourceNumber = dispPlan.HourceNumber;
            }
        }
        private Discipline Disp
        {
            set
            {
                if (value != null)
                    discipline = value;
                else
                    throw new ArgumentNullException("Mistake param discipline is null");
            }
        }
        private Specialty Spec
        {
            set
            {
                if (value != null)
                    spec = value;
                else
                    throw new ArgumentNullException("Mistake param in Specialty is null");
            }
        }
        public Discipline DisciplineName { get { return discipline; } }
        public Specialty SpecialtyName { get { return spec; } }
        public int HourceNumber
        {
            get { return hourceNumber; }
            set
            {
                if (hourceNumber > 0 && hourceNumber <= MAXhourceNumberOfMonth)
                    hourceNumber = value;
                else
                    throw new FormatException("Mistake param HourceNumber");
            } 
        }
    }
    class Discipline
   {
       public string DisciplineName { get; set; }
       public string Description { get; set; }
   }
    class Raspisanie
    {
        Week weekDay;
        byte paraNumber;
        Discipline discipline;
        string cabinetNumber;
        Teacher teacher;
    }
    class Specialty
    {
        private string specialtyCode;
        public string FullName { get; set; }
        public string Name { get; set; }
        public string SpecialtyCode 
        {
            get { return specialtyCode; }
            set 
            {
                Regex reg =  new Regex(@"[^0-9.]+");
                if(!reg.IsMatch(value))
                    specialtyCode = value; 
                else
                    throw new FormatException("Mistake param SpecialtyCode");
            } 
        }
    }
    class Group
    {
        private Specialty spec;
        private int startYear;
        private byte groupNumber;
        private CourceNumber cource;
        private List<Student> studentList;
        public Group(Specialty specialty, byte groupNumber, int startYear, CourceNumber courceNumber = CourceNumber.First)
        {
            if (specialty!=null)
                spec=specialty;
            this.groupNumber = groupNumber;
            Year = startYear;
            cource = courceNumber;
            studentList = new List<Student>();
        }
        public string Name
        {
            get { return spec.Name + "-" + startYear.ToString() + "-" + groupNumber.ToString(); }
        }
        public int Year 
        {
            get { return startYear; }
            set
            {
                if (startYear > 2000 && startYear < 2100)
                    startYear = value;
                else
                    throw new FormatException("Mistake param startYear in construct Group");
            } 
        }
        public void AddStudent(Student student)
        {
            if (student != null)
            {
                //student.StudentGroup.RemoveStudent(student);
                studentList.Add(student.ChangeGroup(this));
            }
            else
                throw new ArgumentNullException("function AddStudent(student) error. student is null");
        }
        public void ExpelledStudent(Student student) 
        {
            if (student != null)
                student.ExpelledStudent();
        }
        public CourceNumber Cource
        {
            get { return cource; }
            set { cource = value;}
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
        private bool statusIsActiv;
        private int studentIDNumber;
        private Group group;
        private CourceNumber course;
        private bool starosta;
        public Student(Group group, int studentIDNumber,  bool starosta = false)
        {
            if (group != null)
                this.group=group;
            else
                throw new ArgumentNullException("Error in Student constructor. Group is null");
            course = group.Cource;
            this.studentIDNumber = studentIDNumber;
            this.starosta = starosta;
            statusIsActiv = true;
        }
        private Student(Student student,Group newGroup)
        {
            group = newGroup;
            studentIDNumber = student.StudentIDNumber;
            course = student.Cource;
            starosta = false;
            statusIsActiv = true;
        }
        public CourceNumber Cource { get { return course; } }
        public int StudentIDNumber { get { return studentIDNumber; } }
        public Group StudentGroup { get { return group; } }
        public Student ChangeGroup(Group newGroup)
        {
            if (newGroup != group)
            {
                statusIsActiv = false;
                Student student = new Student(this,newGroup);
                return student;
            }
            else
                return this;
        }
        public bool Starosta
        {
            get { return starosta; }
            set { starosta = value; }
        }
        public bool StatusIsActive { get { return statusIsActiv; } }
        public void ExpelledStudent()
        {
            statusIsActiv = false;
        }
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
