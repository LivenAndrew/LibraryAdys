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
using System.IO;


namespace RegistrationApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> Users = new List<Person>();
  
        string pathFle = @"C:\Users\WSR\Desktop\gitHub\RegistrationApp\database.txt";

        public MainWindow()
        {
            InitializeComponent();
            Captcha();

            if (File.Exists(pathFle))
            {
                StreamReader rd = new StreamReader(pathFle);
                TBLogin.Text = rd.ReadLine();
                PBPassword.Password = rd.ReadLine();
            }
            for (int i = 0; i < 5; i++)
            {
                Users.Add(new Person 
                {
                    ID = $"admin{i}",
                    Name = $"admin{i}",
                    Login = $"admin{i}",
                    password = $"admin{i}",
                    
                });
            }

        }
        public void Captcha()
        {
            string arraySymbols = "a b c d e f g h i j k l m n o p q r" +
                                  "s t u v w x w z A B C D E F G H I J " +
                                  "K L M N O P Q R S T U V W Z X W 0 1" +
                                  " 2 3 4 5 6 7 8 9 ";

            String[] symbols = arraySymbols.Split(' ');
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                CaptchaTextBlock.Text += symbols[random.Next(1, 61)];
            }
        }
        public void WriteIntoDataBase()
        {
            if (RememberMe.IsChecked == true)
            {

                using (StreamWriter sw = new StreamWriter(pathFle))
                {
                    sw.WriteLine(TBLogin.Text);
                    sw.WriteLine(PBPassword.Password);
                    sw.WriteLine("true");
                    sw.Close();
                }

            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            if (TBLogin.Text != "admin" || PBPassword.Password != "123")
            {
                BorderCaptcha.Visibility = Visibility.Visible;
                CaptchaTextBlock.Visibility = Visibility.Visible;
                CaptchaEnter.Visibility = Visibility.Visible;
            }
            else if (TBLogin.Text != "admin" || PBPassword.Password != "123" || CaptchaEnter.Text != CaptchaTextBlock.Text )
            {
                CaptchaTextBlock.Text ="";
                Captcha();

            }
            else if (TBLogin.Text == "admin" && PBPassword.Password == "123" && CaptchaEnter.Text == CaptchaTextBlock.Text)
            {
                Window1 window1 = new Window1("Hello " + TBLogin.Text);
                window1.ShowDialog();
                WriteIntoDataBase();
               

            }

            else if (TBLogin.Text == "admin" && PBPassword.Password == "123" && CaptchaEnter.Visibility == Visibility.Hidden)
            {
                Window1 window1 = new Window1(TBLogin.Text);
                window1.ShowDialog();
                WriteIntoDataBase();
            }
        }
    }

}