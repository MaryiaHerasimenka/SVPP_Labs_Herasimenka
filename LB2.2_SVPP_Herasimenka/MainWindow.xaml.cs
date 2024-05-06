using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LB2._2_SVPP_Herasimenka
{   
    public class Person : INotifyPropertyChanged

    { 

        private string name;
        private int age;
        private double salary;
        private string position;
        private string city;
        private string street;
        private int houseNumber;
            public string Name
            {
                get { return name; }
                set
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
            public int Age
            {
                get { return age; }
                set
                {
                if (value <18|| value>60)
                    throw new ArgumentException("Некорректное значение возраста.");
                else
                    age = value;
                OnPropertyChanged("Age");
                }
            }
            public double Salary
            {
                get { return salary; }
                set
                {
                if (value <=0)
                    throw new ArgumentException("Значение не может быть отрицательным или нулём.");
                else
                    salary = value;
                OnPropertyChanged("Salary");
                }
            }
            public string Position
            {
                get { return position; }
                set
                {
                    position = value;
                    OnPropertyChanged("Position");
                }
            }
            public string City
            {
                get { return city; }
                set
                {
                    city = value;
                    OnPropertyChanged("City");
                }
            }

            public string Street
            {
                get { return street; }
                set
                {
                    street = value;
                    OnPropertyChanged("Street");
                }
            }
            public int HouseNumber
            {
                get { return houseNumber; }
                set { 
                if (value <=0)
                throw new ArgumentException("Значение не может быть отрицательным или нулём.");
                else
                houseNumber = value;
                OnPropertyChanged("HouseNumber");
                }
            }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }

}

public partial class MainWindow : Window
    {
        Person person;
        ObservableCollection<string> persons;
        public MainWindow()
        {
            InitializeComponent();
            Person person = new Person();
            grid.DataContext = person;
            persons = new ObservableCollection<string>();
            outListWorkersLB.DataContext = persons;
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лабораторная работа #2. Герасименко М.Е. группа ПВ2-22ПО.");
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            persons.Add("Имя: "+nameTB.Text+"; "+ "Возраст: " + ageTB.Text + "; "+ "Зарплата: " + salaryTB.Text + "; "+ "Должность: " + positionCB.Text + "; "+ "Город: " + cityCB.Text + "; "+ "Улица " + streetCB.Text + "; "+ "Номер дома " + houseNumberTB.Text + "; ");

        }
        private void Clear_Fields_Click(object sender, RoutedEventArgs e)
        {
            Button buttonClear = (Button)sender;
            nameTB.Clear();
            ageTB.Clear();
            salaryTB.Clear();
            positionCB.Text = string.Empty;
            cityCB.Text= string.Empty;
            streetCB.Text=string.Empty;
            houseNumberTB.Clear();
        }
        private void Clear_List_Field_Click(object sender, RoutedEventArgs e)
        {
            Button buttonClear = (Button)sender;
            persons.Clear();
        }
        private void Save_To_File_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                StreamWriter str = new StreamWriter("Persons.txt");
                for (int i = 0; i < persons.Count; i++)
                {
                    str.WriteLine(persons[i].ToString());
                }
                str.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Load_From_File_Click(object sender, RoutedEventArgs e)
        {
                String line;
                try
                {
                    StreamReader str = new StreamReader("Persons.txt");
                    line = str.ReadLine();
                    while (line != null)
                    {
                        persons.Add(line);
                        line = str.ReadLine();
                    }
                    str.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        }
    }
