using HMS.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HMS
{
    /// <summary>
    /// Interaction logic for NursePanel.xaml
    /// </summary>
    public partial class NursePanel : Window
    {
        Login login;
        nurse owner;
        HmsDA hms = new HmsDA();
        List<indoor> patientList;
        List<room> roomList;
        public NursePanel(user ownerUser, Login login)
        {
            InitializeComponent();
            this.login = login;
            owner = hms.getNurseByUid(ownerUser.uid);
            patientList = hms.getMyPatients(owner);
            roomList = hms.getMyRooms(owner);


            dataGrid_Patients.ItemsSource = patientList;
            dataGrid_Rooms.ItemsSource = roomList;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            login.Show();
        }
        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Created by EESA ABID. \n Submitted to Sir Sher Afgun", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void menuLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtSearch_Patient_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_Patients.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    indoor indo = o as indoor;
                    if (cboSearch_Patient.SelectedValue != null)
                    {
                        String selected = cboSearch_Patient.SelectedValue.ToString().ToLower();
                        if (selected == "name")
                            return (indo.patient.name.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "gender")
                            return (indo.patient.gender.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "room no")
                            return (indo.rid.ToString().ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    return false;
                };
            }
        }

        private void txtSearch_Room_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_Rooms.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    room room = o as room;
                    if (cboSearch_Rooms.SelectedValue != null)
                    {
                        String selected = cboSearch_Rooms.SelectedValue.ToString().ToLower();
                        if (selected == "room no")
                            return (room.rid.ToString().ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "total beds")
                            return (room.totalbeds.ToString().ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "no of patients")
                            return (room.totalPatients.ToString().ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "available beds")
                            return (room.availablebeds.ToString().ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    return false;
                };
            }
        }
    }
}
