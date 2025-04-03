using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace WpfApp009
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private readonly AuthService _authService;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand ExitCommand { get; }

        public LoginViewModel()
        {
            _authService = new AuthService();
            LoginCommand = new RelayCommand(Login);
            ExitCommand = new RelayCommand(Exit);
        }

        private void Login(object parameter)
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Введите имя пользователя и пароль", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_authService.Authenticate(Username, Password))
            {
                var mainView = new MainView();
                mainView.Show();

                if (parameter is Window window)
                    window.Close();
            }
            else
            {
                MessageBox.Show("Неверные учетные данные", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Exit(object parameter)
        {
            if (parameter is Window window)
                window.Close();
        }
    }
}
