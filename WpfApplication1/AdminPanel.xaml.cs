using HMS.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HMS
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        Login login;
        DataLayer.HmsDA hms;
        user owner;
        List<patient> PatientList;
        List<doctor> DoctorList;
        List<nurse> NurseList;
        List<room> RoomList;
        List<indoor> IndoorList;
        int indexSelected = -1;
        patient patSelected = null;
        nurse nurseSelected = null;
        room roomSelected = null;
        doctor docSelected = null;
        indoor indoorSelected = null;
        public AdminPanel(user u, Login login)
        {
            var splash = new SplashScreen("images/splash.png");
            splash.Show(true);
            InitializeComponent();
            splash.Show(false);
            this.login = login;
            hms = new DataLayer.HmsDA();
            owner = u; 
        }

        public void LoadData(object sender, DoWorkEventArgs e)
        {
            PatientList = hms.getPatientList();
            DoctorList = hms.getDoctors();
            NurseList = hms.getNurses();
            RoomList = hms.getRooms();
            IndoorList = hms.getIndoors();
            this.Dispatcher.Invoke(new Action(delegate
            {
                Add_Employee.IsEnabled = true;
                Add_Patient.IsEnabled = true;
                btnAdd_Nurse.IsEnabled = true;
                btnAdd_Room.IsEnabled = true;

                dataGrid_Doctor.ItemsSource = DoctorList;
                dataGrid_Patient.ItemsSource = PatientList;
                dataGrid_Nurse.ItemsSource = NurseList;
                dataGrid_Room.ItemsSource = RoomList;
                dataGrid_Indoor.ItemsSource = IndoorList;

                cboGovernedBy.ItemsSource = NurseList;
                cboRoomNo.ItemsSource = RoomList;
                cboCategory.ItemsSource = hms.getCategories();
            }));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += LoadData;
            worker.RunWorkerAsync();
        }

        private void Add_Patient_Click(object sender, RoutedEventArgs e)
        {
            new Add_Patient(PatientList).ShowDialog();
            dataGrid_Patient.Items.Refresh();
        }

        private void Add_Employee_Click(object sender, RoutedEventArgs e)
        {
            new Add_Doctor(DoctorList).ShowDialog();
            dataGrid_Doctor.Items.Refresh();
        }

        private void dataGrid_Doctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.indexSelected = dataGrid_Doctor.SelectedIndex;
            if (indexSelected == -1 || DoctorList.Count <= indexSelected)
            {
                docSelected = null;
                btnDelete_Doctor.IsEnabled = false;
                btnUpdate_Doctor.IsEnabled = false;
                return;
            };

            btnDelete_Doctor.IsEnabled = true;
            btnUpdate_Doctor.IsEnabled = true;
            //docSelected = (doctor)DoctorList.ElementAt<doctor>(dataGrid_Doctor.SelectedIndex);
            docSelected = (doctor)dataGrid_Doctor.SelectedItem;

            txtFirstName.Text = docSelected.employee.firstname;
            txtLastName.Text = docSelected.employee.lastname;
            txtDob.Text = docSelected.employee.dob.ToString();
            txtUsername.Text = docSelected.employee.user.username;
            txtPassword.Text = docSelected.employee.user.password;
            txtPhone.Text = docSelected.employee.phone;
            txtSalary.Text = docSelected.employee.salary.ToString();
            cboCategory.Text = docSelected.category.name;

            if (docSelected.employee.gender.Equals("female"))
                radioFemale.IsChecked = true;
            else
                radioMale.IsChecked = true;

        }

        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Created by EESA ABID. \n Submitted to Sir Sher Afgun", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnUpdate_Doctor_Click(object sender, RoutedEventArgs e)
        {
            if (docSelected == null) return;



            String firstname = txtFirstName.Text;
            String lastname = txtLastName.Text;
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            String type = "doctor";
            int catid = int.Parse(cboCategory.SelectedValue.ToString());
            String phone = txtPhone.Text;
            DateTime dob = (DateTime)txtDob.SelectedDate;
            int salary = Convert.ToInt32(txtSalary.Text);
            String gender = "male";
            if (((radioFemale.IsChecked ?? false) || (radioMale.IsChecked ?? false)) && !string.IsNullOrEmpty(firstname)
                && !string.IsNullOrEmpty(lastname) && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password)
                && !string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(txtDob.Text)
                && !string.IsNullOrEmpty(txtSalary.Text) && !string.IsNullOrEmpty(cboCategory.Text))
            {
                if (radioFemale.IsChecked ?? false)
                    gender = "female";
            }
            else
            {
                MessageBox.Show("Please make sure all attributes are compelted.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (username != docSelected.employee.user.username && hms.getUser(username) != null)
            {
                MessageBox.Show("Username already exists!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            docSelected.employee.firstname = firstname;
            docSelected.employee.lastname = lastname;
            docSelected.employee.dob = dob;
            docSelected.employee.salary = salary;
            docSelected.employee.phone = phone;
            docSelected.employee.gender = gender;

            docSelected.employee.user.username = username;
            docSelected.employee.user.password = password;
            docSelected.employee.user.type = type;

            docSelected.catid = catid;

            hms.updateDoctor(docSelected);

            MessageBox.Show("Record updated success.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            dataGrid_Doctor.Items.Refresh();
            PatientList = hms.getPatientList();
            dataGrid_Patient.Items.Refresh();
        }
        private void btnDelete_Doctor_Click(object sender, RoutedEventArgs e)
        {
            if (docSelected == null) return;

            MessageBoxResult result = MessageBox.Show("Do you want to delete " + docSelected.employee.firstname + "'s record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (!(MessageBoxResult.Yes == result)) return;
            hms.remove(docSelected);
            DoctorList.Remove(docSelected);
            dataGrid_Doctor.Items.Refresh();
        }

        private void dataGrid_Patient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.indexSelected = dataGrid_Patient.SelectedIndex;
            if (indexSelected == -1 || PatientList.Count <= indexSelected)
            {
                patSelected = null;
                btnDelete_Patient.IsEnabled = false;
                btnUpdate_Patient.IsEnabled = false;
                return;
            };


            btnDelete_Patient.IsEnabled = true;
            btnUpdate_Patient.IsEnabled = true;
            //patSelected = (patient)PatientList.ElementAt<patient>(dataGrid_Patient.SelectedIndex);
            patSelected = (patient)dataGrid_Patient.SelectedItem;

            txtFullname.Text = patSelected.name;
            txtDob_Patient.Text = patSelected.dob.ToString();
            if (patSelected.type != null)
                cboType_Patient.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(patSelected.type);
            else
                cboType_Patient.Text = "";

            if (patSelected.gender.Equals("female"))
                radioFemale_Patient.IsChecked = true;
            else
                radioMale_Patient.IsChecked = true;
        }

        private void btnDelete_Patient_Click(object sender, RoutedEventArgs e)
        {
            if (patSelected == null) return;

            MessageBoxResult result = MessageBox.Show("Do you want to delete " + patSelected.name + "'s record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (!(MessageBoxResult.Yes == result)) return;
            hms.remove(patSelected);
            PatientList.Remove(patSelected);
            dataGrid_Patient.Items.Refresh();
            IndoorList = hms.getIndoors();
            dataGrid_Indoor.Items.Refresh();
        }

        private void btnUpdate_Patient_Click(object sender, RoutedEventArgs e)
        {
            if (patSelected == null) return;



            String fullname = txtFullname.Text;
            String type = null;
            if (!string.IsNullOrEmpty(cboType_Patient.Text)) type = cboType_Patient.Text.ToLower();
            DateTime dob = (DateTime)txtDob_Patient.SelectedDate;
            String gender = "male";
            if (((radioFemale_Patient.IsChecked ?? false) || (radioMale_Patient.IsChecked ?? false))
                && !string.IsNullOrEmpty(txtDob_Patient.Text))
            {
                if (radioFemale_Patient.IsChecked ?? false)
                    gender = "female";
            }
            else
            {
                MessageBox.Show("Please make sure all attributes are compelted.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            patSelected.name = fullname;
            patSelected.dob = dob;
            patSelected.gender = gender;
            patSelected.type = type;

            hms.updatePatient(patSelected);


            MessageBox.Show("Record updated success.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            dataGrid_Patient.Items.Refresh();
        }

        private void dataGrid_Nurse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.indexSelected = dataGrid_Nurse.SelectedIndex;
            if (indexSelected == -1 || NurseList.Count <= indexSelected)
            {
                nurseSelected = null;
                btnDelete_Nurse.IsEnabled = false;
                btnUpdate_Nurse.IsEnabled = false;
                return;
            };


            btnDelete_Nurse.IsEnabled = true;
            btnUpdate_Nurse.IsEnabled = true;
            //nurseSelected = (nurse)NurseList.ElementAt<nurse>(dataGrid_Nurse.SelectedIndex);
            nurseSelected = (nurse)dataGrid_Nurse.SelectedItem;

            txtFirstName_Nurse.Text = nurseSelected.employee.firstname;
            txtLastName_Nurse.Text = nurseSelected.employee.lastname;
            txtDob_Nurse.Text = nurseSelected.employee.dob.ToString();
            txtUsername_Nurse.Text = nurseSelected.employee.user.username;
            txtPassword_Nurse.Text = nurseSelected.employee.user.password;
            txtPhone_Nurse.Text = nurseSelected.employee.phone;
            txtSalary_Nurse.Text = nurseSelected.employee.salary.ToString();
            txtExperience.Text = nurseSelected.experience;
        }

        private void btnUpdate_Nurse_Click(object sender, RoutedEventArgs e)
        {
            if (nurseSelected == null) return;



            String firstname = txtFirstName_Nurse.Text;
            String lastname = txtLastName_Nurse.Text;
            String username = txtUsername_Nurse.Text;
            String password = txtPassword_Nurse.Text;
            String experience = txtExperience.Text;
            String phone = txtPhone_Nurse.Text;
            DateTime dob = (DateTime)txtDob_Nurse.SelectedDate;
            int salary = Convert.ToInt32(txtSalary_Nurse.Text);
            String gender = "female";
            if (!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lastname)
                && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password)
                && !string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(txtDob_Nurse.Text)
                && !string.IsNullOrEmpty(txtSalary_Nurse.Text) && !string.IsNullOrEmpty(experience))
            {

                if (username != nurseSelected.employee.user.username && hms.getUser(username) != null)
                {
                    MessageBox.Show("Username already exists!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                nurseSelected.employee.firstname = firstname;
                nurseSelected.employee.lastname = lastname;
                nurseSelected.employee.dob = dob;
                nurseSelected.employee.salary = salary;
                nurseSelected.employee.phone = phone;
                nurseSelected.employee.gender = gender;

                nurseSelected.employee.user.username = username;
                nurseSelected.employee.user.password = password;

                nurseSelected.experience = experience;

                hms.updateNurse(nurseSelected);

            }
            else
            {
                MessageBox.Show("All fields are required.", "Reminder", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MessageBox.Show("Record updated success.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            dataGrid_Nurse.Items.Refresh();
            RoomList = hms.getRooms();
            dataGrid_Room.ItemsSource = RoomList;
        }

        private void btnDelete_Nurse_Click(object sender, RoutedEventArgs e)
        {
            if (nurseSelected == null) return;

            MessageBoxResult result = MessageBox.Show("Do you want to delete " + nurseSelected.employee.firstname + "'s record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (!(MessageBoxResult.Yes == result)) return;
            hms.remove(nurseSelected);
            NurseList.Remove(nurseSelected);
            dataGrid_Nurse.Items.Refresh();
        }

        private void btnAdd_Nurse_Click(object sender, RoutedEventArgs e)
        {
            new Add_Nurse(NurseList).ShowDialog();
            dataGrid_Nurse.Items.Refresh();
        }

        private void btnDelete_Room_Click(object sender, RoutedEventArgs e)
        {
            if (roomSelected == null) return;

            MessageBoxResult result = MessageBox.Show("Do you want to delete room no " + roomSelected.rid + "'s record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (!(MessageBoxResult.Yes == result)) return;
            hms.remove(roomSelected);
            RoomList.Remove(roomSelected);
            dataGrid_Room.Items.Refresh();
        }

        private void btnUpdate_Room_Click(object sender, RoutedEventArgs e)
        {
            if (roomSelected == null) return;



            String TotalBeds = txtTotalBeds.Text;
            String strNid;
            if (!string.IsNullOrEmpty(TotalBeds) && !string.IsNullOrEmpty(cboGovernedBy.Text))
            {
                strNid = cboGovernedBy.SelectedValue.ToString();

                try
                {

                    int newBeds = int.Parse(TotalBeds);
                    int nid = int.Parse(strNid);
                    long? prevBeds = roomSelected.totalbeds;
                    long? diffBeds = newBeds - prevBeds;
                    roomSelected.totalbeds = newBeds;
                    roomSelected.availablebeds += diffBeds;
                    roomSelected.nid = nid;
                    hms.updateRoom(roomSelected);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was some error.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBox.Show("Record updated success.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                dataGrid_Room.Items.Refresh();

            }
        }

        private void dataGrid_Room_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.indexSelected = dataGrid_Room.SelectedIndex;
            if (indexSelected == -1 || RoomList.Count <= indexSelected)
            {
                roomSelected = null;
                btnDelete_Room.IsEnabled = false;
                btnUpdate_Room.IsEnabled = false;
                return;
            };


            btnDelete_Room.IsEnabled = true;
            btnUpdate_Room.IsEnabled = true;
            //roomSelected = (room)RoomList.ElementAt<room>(dataGrid_Room.SelectedIndex);
            roomSelected = (room)dataGrid_Room.SelectedItem;

            txtTotalBeds.Text = roomSelected.totalbeds.ToString();
            cboGovernedBy.Text = roomSelected.nurse.employee.firstname;
        }

        private void btnAdd_Room_Click(object sender, RoutedEventArgs e)
        {
            new Add_Room(NurseList, RoomList, hms).ShowDialog();
            dataGrid_Room.Items.Refresh();
        }

        private void menuLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menuAddNurse_Click(object sender, RoutedEventArgs e)
        {
            new Add_Nurse(NurseList).ShowDialog();
            dataGrid_Nurse.Items.Refresh();
        }

        private void menuAddRoom_Click(object sender, RoutedEventArgs e)
        {
            new Add_Room(NurseList, RoomList, hms).ShowDialog();
            dataGrid_Room.Items.Refresh();
        }

        private void dataGrid_Indoor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.indexSelected = dataGrid_Indoor.SelectedIndex;
            if (indexSelected == -1 || IndoorList.Count <= indexSelected)
            {
                indoorSelected = null;
                btnAssignRoom.IsEnabled = false;
                return;
            };

            btnAssignRoom.IsEnabled = true;
            //indoorSelected = (indoor)IndoorList.ElementAt<indoor>(dataGrid_Indoor.SelectedIndex);
            indoorSelected = (indoor)dataGrid_Indoor.SelectedItem;
        }

        private void btnAssignRoom_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(cboRoomNo.Text))
            {
                MessageBox.Show("Please select a room no.", "Reminder", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            indoor indo = (indoor)dataGrid_Indoor.SelectedItem;


            if(indo.status == "discharged")
            {
                MessageBox.Show("Cannot assign room to discharged patient.","Reminder",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }


            if(indo.rid != null && indo.status == "admitted")
            {
                room currentRoom = hms.getRoom(indo.rid);
                currentRoom.availablebeds++;
                hms.updateRoom(currentRoom);
            }


            indo.rid = int.Parse(cboRoomNo.Text);
            
            room newRoom = hms.getRoom(indo.rid);

            if(newRoom.availablebeds == 0)
            {
                MessageBox.Show("Beds not available in this room. Please select any other room.","Reminder",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }

            newRoom.availablebeds--;

            hms.updateIndoor(indo);
            hms.updateRoom(newRoom);

            MessageBox.Show("Room Assigned successfully!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            dataGrid_Indoor.Items.Refresh();
            RoomList = hms.getRooms();
            dataGrid_Room.Items.Refresh();

        }

        private void main_window_Closing(object sender, CancelEventArgs e)
        {
            login.Show();
        }

        private void txtSearch_Doctor_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_Doctor.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    doctor d = o as doctor;
                    if (cboSearch_Doctor.SelectedValue != null)
                    {
                        String selected = cboSearch_Doctor.SelectedValue.ToString().ToLower();
                        if (selected == "first name")
                            return (d.employee.firstname.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "last name")
                            return (d.employee.lastname.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "gender")
                            return (d.employee.gender.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "username")
                            return (d.employee.user.username.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "phone")
                            return (d.employee.phone.ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    else
                        return false;
                };
            }
            btnUpdate_Doctor.IsEnabled = false;
            btnDelete_Doctor.IsEnabled = false;
        }

        private void txtSearch_Nurse_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_Nurse.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    nurse n = o as nurse;
                    if (cboSearch_Nurse.SelectedValue != null)
                    {
                        String selected = cboSearch_Nurse.SelectedValue.ToString().ToLower();
                        if (selected == "first name")
                            return (n.employee.firstname.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "last name")
                            return (n.employee.lastname.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "experience")
                            return (n.experience.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "username")
                            return (n.employee.user.username.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "phone")
                            return (n.employee.phone.ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                        return false;
                };
            }
            btnUpdate_Nurse.IsEnabled = false;
            btnDelete_Nurse.IsEnabled = false;
        }

        private void txtSearch_Patient_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_Patient.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    patient pat = o as patient;
                    if (cboSearch_Nurse.SelectedValue != null)
                    {
                        String selected = cboSearch_Patient.SelectedValue.ToString().ToLower();
                        if (selected == "name")
                            return (pat.name.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "gender")
                            return (pat.gender.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "type")
                            return (pat.type.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "doctor name")
                            return (pat.doctor.employee.firstname.ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    return false;
                };
            }
            btnUpdate_Patient.IsEnabled = false;
            btnDelete_Patient.IsEnabled = false;
        }

        private void txtSearch_Room_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_Room.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    room r = o as room;
                    if (cboSearch_Room.SelectedValue != null)
                    {
                        String selected = cboSearch_Room.SelectedValue.ToString().ToLower();
                        if (selected == "room no")
                            return (r.rid.ToString().ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "total beds")
                            return (r.totalbeds.ToString().ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "nurse name")
                            return (r.nurse.employee.firstname.ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    return false;
                };
            }
            btnUpdate_Room.IsEnabled = false;
            btnDelete_Room.IsEnabled = false;
        }

        private void txtSearch_Indoor_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_Indoor.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    indoor indo = o as indoor;
                    if (cboSearch_Indoor.SelectedValue != null)
                    {
                        String selected = cboSearch_Indoor.SelectedValue.ToString().ToLower();
                        if (selected == "patient name")
                            return (indo.patient.name.ToString().ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "gender")
                            return (indo.patient.gender.ToString().ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "category")
                            return (indo.patient.category.name.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "disease")
                            return (indo.disease.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "room no")
                            return (indo.rid.ToString().ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    return false;
                };
            }
            btnAssignRoom.IsEnabled = false;
        }
    }
}