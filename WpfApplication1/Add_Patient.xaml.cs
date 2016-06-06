using HMS.Models;
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
using System.Windows.Shapes;

namespace HMS
{
    /// <summary>
    /// Interaction logic for Add_Patient.xaml
    /// </summary>
    public partial class Add_Patient : Window
    {
        DataLayer.HmsDA hms;
        List<patient> PatientList;
        PatientViewModel vm = new PatientViewModel();
        public Add_Patient(List<patient> PatientList)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            hms = new DataLayer.HmsDA();
            this.PatientList = PatientList;
            this.DataContext = vm;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            comboCat.ItemsSource = hms.getCategories();
            comboCat.DisplayMemberPath = "name";
            comboCat.SelectedValuePath = "catid";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            patient p = new patient();
            long catid=0;
            try
            {
                
                String name = txtName.Text;
                DateTime dob = (DateTime) txtDob.SelectedDate;
                catid = int.Parse(comboCat.SelectedValue.ToString());

                if (!string.IsNullOrEmpty(name) && ((radioFemale.IsChecked ?? false) || (radioMale.IsChecked ?? false))
                    && dob!=null)
                {
                    String gender = "male";

                    if (!(radioMale.IsChecked ?? false))
                        gender = "female";
                    p.catid = catid;
                    p.name = name;
                    p.dob = dob;
                    p.gender = gender;
                    hms.addPatient(p);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("All fields are required.","Reminder",MessageBoxButton.OK,MessageBoxImage.Warning);
                    return;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("All fields are required.", "Reminder", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            this.PatientList.Add(p);
            this.Close();
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
