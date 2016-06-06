using HMS;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Windows;
namespace HMS
{
    /// <summary>
    /// Interaction logic for Add_Nurse.xaml
    /// </summary>
    public partial class Add_Nurse : Window
    {
        DataLayer.HmsDA hms = new DataLayer.HmsDA();
        List<nurse> NurseList;
        public Add_Nurse(List<nurse> NurseList)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.NurseList = NurseList;
            this.DataContext = new EmpViewModel();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            String firstname = txtFirstName.Text;
            String lastname = txtLastName.Text;
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            String type = "nurse";
            String phone = txtPhone.Text;
            String experience = txtExperience.Text;

            DateTime dob = new DateTime();
            if (txtDob.SelectedDate != null) dob = (DateTime)txtDob.SelectedDate;
            int salary = Convert.ToInt32(txtSalary.Text);
            String gender = "female";
            if (!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lastname) && !string.IsNullOrEmpty(username)
                && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(phone)
                && !string.IsNullOrEmpty(txtDob.Text) && !string.IsNullOrEmpty(txtSalary.Text)
                && !string.IsNullOrEmpty(experience))
            {


                if (hms.getUser(username) != null)
                {
                    MessageBox.Show("Username already exists!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                emp.phone = phone;
                emp.user = u;

                nurse n = new nurse();
                n.experience = experience;
                n.employee = emp;


                hms.addNurse(n);
                NurseList.Add(n);


                this.Close();
            }
            else
                MessageBox.Show("All fields are required.", "Reminder", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                this.DragMove();
        }
    }
}
