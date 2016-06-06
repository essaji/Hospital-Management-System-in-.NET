using HMS.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace HMS
{
    /// <summary>
    /// Interaction logic for Add_Room.xaml
    /// </summary>
    public partial class Add_Room : Window
    {
        List<nurse> NurseList;
        List<room> RoomList;
        DataLayer.HmsDA hms;

        public Add_Room(List<nurse> NurseList, List<room> RoomList, DataLayer.HmsDA hms)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.NurseList = NurseList;
            this.RoomList = RoomList;
            cboGovernedBy.ItemsSource = NurseList;
            this.hms = hms;
            this.DataContext = new ValidationModel();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotalBeds.Text) && !string.IsNullOrEmpty(cboGovernedBy.Text))
            {
                String beds = txtTotalBeds.Text;

                if(int.Parse(beds) <= 0)
                {
                    MessageBox.Show("No of beds should be a positive number.","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
                    return;
                }

                String strNid = cboGovernedBy.SelectedValue.ToString();

                int TotalBeds = int.Parse(beds);
                int nid = int.Parse(strNid);
                nurse n = hms.getNurseByNid(nid);
                room r = new room();
                r.totalbeds = TotalBeds;
                r.availablebeds = TotalBeds;
                r.nurse = n;
                String Nursename = cboGovernedBy.Text;

                hms.addRoom(r);
                RoomList.Add(r);
                this.Close();
            }
            else
            {
                MessageBox.Show("Make sure all fields are enered.","Reminder",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                this.DragMove();
        }
    }
}
