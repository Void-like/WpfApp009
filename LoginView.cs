using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp009
{
    internal class LoginView :MainWindow
        {
            public LoginView()
            {
                InitializeComponent();
                PasswordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }

            private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
            {
                if (DataContext is LoginViewModel vm)
                    vm.Password = PasswordBox.Password;
            }
        }
    }


