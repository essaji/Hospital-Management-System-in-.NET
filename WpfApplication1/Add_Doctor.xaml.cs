using HMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Windows;
using System.Windows.Input;

namespace HMS
{
    /// <summary>
    /// Interaction logic for Add_Employee.xaml
    /// </summary>
    public partial class Add_Doctor : Window
    {
        DataLayer.HmsDA hms;
        List<doctor> docList;
        public Add_Doctor(List<doctor> docList)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            hms = new DataLayer.HmsDA();
            this.docList = docList;
            cboSpecialization.ItemsSource = hms.getCategories();
            this.DataContext = new EmpViewModel();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            String firstname = txtFirstName.Text;
            String lastname = txtLastName.Text;
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            String type = "doctor";
            String phone = txtPhone.Text;
            

            DateTime dob = new DateTime();
            if (txtDob.SelectedDate!=null) dob = (DateTime) txtDob.SelectedDate;
            int salary = Convert.ToInt32(txtSalary.Text);
            String gender = "male";
            if (((radioFemale.IsChecked ?? false) || (radioMale.IsChecked ?? false)) && !string.IsNullOrEmpty(firstname)
                && !string.IsNullOrEmpty(lastname) && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password)
                && !string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(txtDob.Text) 
                && !string.IsNullOrEmpty(txtSalary.Text) && !string.IsNullOrEmpty(cboSpecialization.Text))
            {
                if (radioFemale.IsChecked ?? false)
                    gender = "female";
            }
            else
            {
                MessageBox.Show("Please make sure all attributes are completed.","Reminder",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }

            if (salary <= 999)
            {
                MessageBox.Show("Salary should be greater than 1000.","Reminder",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }


            long catid = int.Parse(cboSpecialization.SelectedValue.ToString());

            if (hms.getUser(username) != null)
            {
                MessageBox.Show("Username already exists!","Warning!",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }

            user u = new user();
            u.username = username;
            u.password = password;
            u.type = type;

            employee emp = new employee();
            emp.firstname = firstname;
            emp.lastname = lastname;
            emp.dob = dob;
            emp.salary = salary;
            emp.gender = gender;
            //emp.uid = uid;
            emp.phone = phone;
            emp.user = u;


            doctor d = new doctor();
            //d.eid = hms.getEid(uid);
            d.catid = catid;
            d.employee = emp;

            docList.Add(hms.addDoctor(d));

            //EmployeeList.Add(new DataLayer.EmployeeData() { userData = u, empData = emp, docData = d });
            //docList = hms.getDoctors();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        
    }
}
