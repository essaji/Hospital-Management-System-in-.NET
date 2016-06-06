using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        DataLayer.HmsDA hms = new DataLayer.HmsDA();

        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            String user = txtUsername.Text;
            String pass = txtPassword.Password;
            btnLogin.IsEnabled = false;
            user logUser;
            new Thread(() => {
            if ((logUser = hms.getUser(user, pass)) != null)
            {
                
                    if (logUser.type.Equals("admin"))
                    {
                        this.Dispatcher.Invoke(new Action(delegate {
                            new AdminPanel(logUser, this).Show();
                        }));
                    }
                    else if (logUser.type.Equals("doctor"))
                    {
                        this.Dispatcher.Invoke(new Action(delegate {
                            new DoctorPanel(logUser, this).Show();
                        }));
                    }
                    else if (logUser.type.Equals("nurse"))
                    {
                        this.Dispatcher.Invoke(new Action(delegate {
                            new NursePanel(logUser, this).Show();
                        }));
                    }
                    else if (logUser.type.Equals("pharmacist"))
                    {
                        this.Dispatcher.Invoke(new Action(delegate {
                            new PharmacistPanel(logUser, this).Show();
                        }));
                    }
                
            }
            else
            {
                this.Dispatcher.Invoke(new Action(delegate {
                    MessageBox.Show("Invalid user/pass combination.", "Invalid User", MessageBoxButton.OK, MessageBoxImage.Stop);
                    this.Show();
                }));
                    
                
            }
            }).Start();

            this.Hide();
            btnLogin.IsEnabled = true;

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUsername.SelectAll();
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.SelectAll();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
