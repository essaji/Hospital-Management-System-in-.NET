using HMS.DataLayer;
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
    /// Interaction logic for Add_Medicine.xaml
    /// </summary>
    public partial class Add_Medicine : Window
    {
        HmsDA hms = new HmsDA();
        List<medicine> medList;
        public Add_Medicine(List<medicine> medList)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.medList = medList;
            this.DataContext = new ValidationModel();
        }

        private void btnAddMed_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMedName.Text) && !string.IsNullOrEmpty(txtMedPrice.Text))
            {

                if(int.Parse(txtMedPrice.Text) <= 0)
                {
                    MessageBox.Show("Price must a positive number.","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
                    return;
                }

                String name = txtMedName.Text;
                int price = int.Parse(txtMedPrice.Text);

                medicine med = new medicine();
                med.name = name;
                med.price = price;
                hms.addMedicine(med);
                medList.Add(med);
                this.Close();
            }
            else
                MessageBox.Show("All fields are required.","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
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
