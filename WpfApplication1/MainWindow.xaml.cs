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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataLayer.HmsDA hms;
        public MainWindow()
        {
            InitializeComponent();
            hms = new DataLayer.HmsDA();
        }
        
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            String user = txtUsername.Text;
            String pass = txtPassword.Password;
            if (hms.isAuthenticated(user, pass)) MessageBox.Show("Good User.");
            else MessageBox.Show("I smell bullshit here.");
        }
    }
}
