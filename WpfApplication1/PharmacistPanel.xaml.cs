using HMS.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for PharmacistPanel.xaml
    /// </summary>
    public partial class PharmacistPanel : Window
    {
        Login login;
        HmsDA hms = new HmsDA();
        user owner;
        medicine selectedMed;
        List<medicine> medList;
        List<prescription> presList;

        public PharmacistPanel(user owner, Login login)
        {
            InitializeComponent();
            this.login = login;
            this.owner = owner;


            presList = hms.getPrecriptions();
            medList = hms.getMedicines();

            dataGrid_Pres.ItemsSource = presList;
            dataGrid_Medicine.ItemsSource = medList;
        }
        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Created by EESA ABID. \n Submitted to Sir Sher Afgun", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void menuLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            login.Show();
        }

        private void dataGrid_Medicine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (dataGrid_Medicine.SelectedIndex == -1 || medList.Count <= dataGrid_Medicine.SelectedIndex) return;
            selectedMed = (medicine)dataGrid_Medicine.SelectedItem;
            btnUpdate.IsEnabled = true;
            btnDeleteMed.IsEnabled = true;
            txtMedName.Text = selectedMed.name;
            txtMedPrice.Text = selectedMed.price.ToString();


        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMedPrice.Text) && !string.IsNullOrEmpty(txtMedName.Text))
            {
                String name = txtMedName.Text;
                int price = int.Parse(txtMedPrice.Text);
                selectedMed.name = name;
                selectedMed.price = price;

                hms.updateMedicine(selectedMed);
                dataGrid_Medicine.Items.Refresh();
                MessageBox.Show("Record upate success!","Success!",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
                MessageBox.Show("All fields are required.","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
        }

        private void btnAddMed_Click(object sender, RoutedEventArgs e)
        {
            new Add_Medicine(medList).ShowDialog();
            dataGrid_Medicine.Items.Refresh();
        }

        private void txtSearch_Prescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_Pres.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    prescription pre = o as prescription;
                    if (cboSearch_Prescription.SelectedValue != null)
                    {
                        String selected = cboSearch_Prescription.SelectedValue.ToString().ToLower();
                        if (selected == "medicine name")
                            return (pre.medicine.name.ToString().ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "dosage")
                            return (pre.dosage.ToString().ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "patient name")
                            return (pre.patient.name.ToString().ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "patient gender")
                            return (pre.patient.gender.ToString().ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "doctor name")
                            return (pre.doctor.employee.firstname.ToString().ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    return false;
                };
            }
        }

        private void btnDeleteMed_Click(object sender, RoutedEventArgs e)
        {
            if (selectedMed == null) return;

            MessageBoxResult result = MessageBox.Show("Do you want to delete " + selectedMed.name + "' medicine?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (!(MessageBoxResult.Yes == result)) return;
            hms.remove(selectedMed);
            medList.Remove(selectedMed);
            dataGrid_Medicine.Items.Refresh();
            btnUpdate.IsEnabled = false;
            btnDeleteMed.IsEnabled = false;
        }

        private void txtSearchMed_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_Medicine.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    medicine med = o as medicine;
                    if (cboSearchMed.SelectedValue != null)
                    {
                        String selected = cboSearchMed.SelectedValue.ToString().ToLower();
                        if (selected == "medicine name")
                            return (med.name.ToString().ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "medicine price")
                            return (med.price.ToString().ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    return false;
                };
            }
            btnUpdate.IsEnabled = false;
            btnDeleteMed.IsEnabled = false;
        }
    }
}
