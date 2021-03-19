using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WPF_BasicLoginApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button Button_Login;
        TextBox TextBox_Name;
        TextBox TextBox_Password;
        Label Label_Name;
        Label Label_Password;

        public MainWindow()
        {
            InitializeComponent();
            GenerateControls();
        }

        private void LoginClicked(object sender, RoutedEventArgs e)
        {
            if (TextBox_Name.Text.Length > 0)
            {
                if (isValidPassword(TextBox_Password.Text))
                {
                    MessageBox.Show("Welcome back, " + TextBox_Name.Text);
                }
                else
                {
                    MessageBox.Show("Invalid password");
                }
            }
            else
            {
                MessageBox.Show("Invalid name");
            }
        }

        bool isValidPassword(string input)
        {
            bool result = false;
            Regex PasswordRegex = new Regex(@"^(?=.*\d).{6,}$");
            if (PasswordRegex.IsMatch(input))
            {
                result = true;
            }
            return result;
        }

        private void GenerateControls()
        {
            Button_Login = new Button();
            TextBox_Name = new TextBox();
            TextBox_Password = new TextBox();
            Label_Name = new Label();
            Label_Password = new Label();

            Button_Login.Content = "Login";
            Button_Login.Width = 60;
            Button_Login.Height = 30;
            Button_Login.Margin = new Thickness(0,100,0,0);
            Button_Login.Click += new RoutedEventHandler(LoginClicked);

            TextBox_Name.Width = 130;
            TextBox_Name.Height = 25;
            TextBox_Name.Margin = new Thickness(40,-100, 0, 0);

            TextBox_Password.Width = 130;
            TextBox_Password.Height = 25;
            TextBox_Password.Margin = new Thickness(40, -40, 0, 0);

            Label_Name.Content = "Name";
            Label_Name.Width = 80;
            Label_Name.Height = 25;
            Label_Name.Margin = new Thickness(-130, -100, 0, 0);

            Label_Password.Content = "Password";
            Label_Password.Width = 80;
            Label_Password.Height = 25;
            Label_Password.Margin = new Thickness(-130, -40, 0, 0);

            RootGrid.Children.Add(Button_Login);
            RootGrid.Children.Add(TextBox_Name);
            RootGrid.Children.Add(TextBox_Password);
            RootGrid.Children.Add(Label_Name);
            RootGrid.Children.Add(Label_Password);
        }
    }
}
