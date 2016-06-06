using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HMS
{
    /// <summary>
    /// Interaction logic for DoctorPanel.xaml
    /// </summary>
    public partial class DoctorPanel : Window
    {
        Login login;
        DataLayer.HmsDA hms = new DataLayer.HmsDA();
        user owner;
        doctor docOwner;
        int indexSelected = -1;
        patient patSelected=null;
        indoor oldPatSelected = null;
        prescription presSelected = null;
        List<patient> NewPatientList;
        List<indoor> OldPatientList;
        List<medicine> medicineList;
        List<prescription> presList;

        public DoctorPanel(user u, Login login)
        {
            InitializeComponent();
            this.login = login;
            owner = u;
            docOwner = hms.getDoctorByUid(owner.uid);
            NewPatientList = hms.getMyPatients(docOwner);
            OldPatientList = hms.getMyOldPatients(docOwner);
            medicineList = hms.getMedicines();
            presList = hms.getMyPrescriptions(docOwner);

            cboMed1.ItemsSource = medicineList;
            cboMed2.ItemsSource = medicineList;
            cboMed3.ItemsSource = medicineList;
            cboMed_Pres.ItemsSource = medicineList;
            cboMedName.ItemsSource = medicineList;

            cboMed1.SelectedValuePath = "mid";
            cboMed1.DisplayMemberPath = "name";
            cboMed2.SelectedValuePath = "mid";
            cboMed2.DisplayMemberPath = "name";
            cboMed3.SelectedValuePath = "mid";
            cboMed3.DisplayMemberPath = "name";
            cboMed_Pres.DisplayMemberPath = "name";
            cboMed_Pres.SelectedValuePath = "mid";

            cboMedName.SelectedValuePath = "mid";
            cboMedName.DisplayMemberPath = "name";

            dataGrid_NewPatient.ItemsSource = NewPatientList;
            dataGrid_Pres.ItemsSource = presList;
            dataGrid_MyOldPatients.ItemsSource = OldPatientList;
        }

        private void dataGrid_NewPatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.indexSelected = dataGrid_NewPatient.SelectedIndex;
            if (indexSelected == -1 || NewPatientList.Count <= indexSelected)
            {
                patSelected = null;
                btnSubmitPre.IsEnabled = false;
                return;
            };


            btnSubmitPre.IsEnabled = true;
            //patSelected = (patient)patientList.ElementAt<patient>(dataGrid_NewPatient.SelectedIndex);
            patSelected = (patient)dataGrid_NewPatient.SelectedItem;

            if (patSelected.type != null)
                cboPatientType.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(patSelected.type);
            
        }

        private void cboMed1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboMed2.IsEnabled = true;
            txtDosage2.IsEnabled = true;
        }

        private void cboMed2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboMed3.IsEnabled = true;
            txtDosage3.IsEnabled = true;
        }

        private void btnSubmitPre_Click(object sender, RoutedEventArgs e)
        {
            if (patSelected == null) return;

            if (string.IsNullOrEmpty(cboPatientType.Text))
            {
                MessageBox.Show("Please select patient type.","Reminder",MessageBoxButton.OK,MessageBoxImage.Information);
                return;
            }


            if (cboPatientType.Text.Equals("Indoor"))
            {
                if (string.IsNullOrEmpty(txtDisease.Text))
                {
                    MessageBox.Show("Please enter a diease", "Reminder", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }


                indoor patIndoor = new indoor();
                patIndoor.disease = txtDisease.Text;
                patIndoor.patient = patSelected;
                patIndoor.status = "admitted";
                hms.addIndoor(patIndoor);
                patSelected.type = "indoor";
            }
            else
            {
                patSelected.type = "outdoor";
            }


            if (!string.IsNullOrEmpty(cboMed1.Text))
            {

                int mid1 = int.Parse(cboMed1.SelectedValue.ToString());

                string dosage1 = txtDosage1.Text;

                prescription p1 = new prescription();
                p1.mid = mid1;
                p1.dosage = dosage1;
                p1.pid = patSelected.pid;
                p1.did = docOwner.did;
                hms.addPrescription(p1);
                presList.Add(p1);

                
                if (!string.IsNullOrEmpty(cboMed2.Text))
                {
                    prescription p2 = new prescription();
                    p2.mid = int.Parse(cboMed2.SelectedValue.ToString());
                    p2.dosage = txtDosage2.Text;
                    p2.pid = patSelected.pid;
                    p2.did = docOwner.did;
                    hms.addPrescription(p2);
                    presList.Add(p2);
                }

                if (!string.IsNullOrEmpty(cboMed3.Text.ToString()))
                {
                    prescription p3 = new prescription();
                    p3.mid = int.Parse(cboMed3.SelectedValue.ToString());
                    p3.dosage = txtDosage3.Text;
                    p3.pid = patSelected.pid;
                    p3.did = docOwner.did;
                    hms.addPrescription(p3);
                    presList.Add(p3);
                }

                patSelected.did = docOwner.did;
                hms.updatePatient(patSelected);
                NewPatientList.Remove(patSelected);
                dataGrid_NewPatient.Items.Refresh();
                dataGrid_Pres.Items.Refresh();
                MessageBox.Show("Prescription submisson success.","Success!",MessageBoxButton.OK,MessageBoxImage.Information);
                dataGrid_MyOldPatients.ItemsSource = hms.getMyOldPatients(docOwner);
                dataGrid_MyOldPatients.Items.Refresh();
                
            }
            else
            {
                MessageBox.Show("At least one medicine is required for prescription","Reminder",MessageBoxButton.OK,MessageBoxImage.Information);
                return;
            }
        }

        private void cboPatientType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboPatientType.SelectedValue.ToString().Equals("Indoor"))
                txtDisease.IsEnabled = true;
            else
                txtDisease.IsEnabled = false;
        }

        private void dataGrid_Pres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.indexSelected = dataGrid_Pres.SelectedIndex;
            if (indexSelected == -1 || presList.Count <= indexSelected)
            {
                presSelected = null;
                btnUpdatePres.IsEnabled = false;
                return;
            };


            btnUpdatePres.IsEnabled = true;
            //presSelected = (prescription)presList.ElementAt<prescription>(dataGrid_Pres.SelectedIndex);
            presSelected = (prescription)dataGrid_Pres.SelectedItem;

            if (presSelected.patient.type!=null)
                cboPatientType_Pres.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(presSelected.patient.type);
            if (presSelected.patient.type.Equals("outdoor"))
                txtDisease_Pres.IsEnabled = false;
            else if(presSelected.patient.type.Equals("indoor"))
            {
                indoor indo = hms.getIndoorByPid(presSelected.pid);
                txtDisease_Pres.IsEnabled = true;
                txtDisease_Pres.Text = indo.disease;
            }

            cboMed_Pres.Text = presSelected.medicine.name;
            txtDosage_Pres.Text = presSelected.dosage;

        }

        private void btnUpdatePres_Click(object sender, RoutedEventArgs e)
        {
            if (presSelected == null) return;



            String patType = cboPatientType_Pres.Text;
            int mid = int.Parse(cboMed_Pres.SelectedValue.ToString());
            String Dosage = txtDosage_Pres.Text;
            String disease = null;

            if (string.IsNullOrEmpty(patType) || string.IsNullOrEmpty(Dosage))
            {
                MessageBox.Show("Please make sure all attributes are compelted.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            string prevType = presSelected.patient.type;
            presSelected.patient.type = patType.ToLower();
            presSelected.mid = mid;
            presSelected.dosage = Dosage;

            

            disease = txtDisease_Pres.Text;

            indoor indo = hms.getIndoorByPid(presSelected.pid);
            if (patType.ToLower().Equals("indoor") && prevType.Equals("outdoor"))
            {
                if (!String.IsNullOrEmpty(disease))
                {

                    indoor i = new indoor();
                    i.disease = disease;
                    i.pid = presSelected.pid;
                    i.status = "admitted";
                    hms.addIndoor(i);
                }
                else
                {
                    MessageBox.Show("Please enter a diesease.");
                    return;
                }
            }
            else if(patType.ToLower().Equals("outdoor"))
            {
                
                if (indo!=null)
                    hms.remove(indo);
            }
            else
            {
                indo.disease = disease;
                hms.updateIndoor(indo);
            }



            hms.updatePrescription(presSelected);


            MessageBox.Show("Record updated success.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            dataGrid_Pres.Items.Refresh();
            NewPatientList = hms.getPatientList();
            dataGrid_NewPatient.Items.Refresh();
        }

        private void cboPatientType_Pres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboPatientType_Pres.SelectedValue.ToString().Equals("Indoor"))
                txtDisease_Pres.IsEnabled = true;
            else
                txtDisease_Pres.IsEnabled = false;
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

        private void btnAddPres_Click(object sender, RoutedEventArgs e)
        {

            String MedName = cboMedName.Text;
            String Dosage = txtDosage.Text;

            if (!string.IsNullOrEmpty(MedName) && !string.IsNullOrEmpty(Dosage))
            {
                prescription p = new prescription();
                p.mid = int.Parse(cboMedName.SelectedValue.ToString());
                p.dosage = Dosage;
                p.pid = oldPatSelected.pid;
                p.did = docOwner.did;
                hms.addPrescription(p);
                presList.Add(p);
            }
            else
            {
                MessageBox.Show("All fields are required.","Warning!",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }
            MessageBox.Show("Prescription added successfully!","Success!",MessageBoxButton.OK,MessageBoxImage.Information);
            dataGrid_Pres.Items.Refresh();
        }

        private void dataGrid_MyOldPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            oldPatSelected = (indoor)dataGrid_MyOldPatients.SelectedItem;
            btnAddPres.IsEnabled = true;
            btnChangeStatus.IsEnabled = true;
        }

        private void btnChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            if (oldPatSelected.status.ToLower().Equals("admitted"))
            {
                oldPatSelected.status = "discharged";
                room r = oldPatSelected.room;
                r.availablebeds++;
                hms.updateRoom(r);
                MessageBox.Show("Patient status changed to discharged!","Operation Success!",MessageBoxButton.OK,MessageBoxImage.Information);
            }

            else
            {
                oldPatSelected.status = "admitted";
                room r = oldPatSelected.room;
                if (r.availablebeds == 0)
                {
                    MessageBox.Show("No bed available in the current room.","Reminder",MessageBoxButton.OK,MessageBoxImage.Warning);
                    return;
                }
                r.availablebeds--;
                hms.updateRoom(r);
                MessageBox.Show("Patient status changed to admitted!", "Operation Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
                

            hms.updateIndoor(oldPatSelected);
            dataGrid_MyOldPatients.Items.Refresh();

        }
    }
}
