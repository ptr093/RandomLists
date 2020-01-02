using MaterialDesignThemes.Wpf;
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;


namespace RandomLists
{
    /// <summary>
    /// Interaction logic for StalePrawdopodobienstwo.xaml
    /// </summary>
    public partial class StalePrawdopodobienstwo : MetroWindow
    {

        private readonly IDialogService dialogService;

        static int suma = 100;
        static int number = 0;

        static List<String> TextBoxs = new List<string>();
        static List<String> TracksName = new List<string>();
        static List<String> txtName = new List<string>();
        static List<double> tracks = new List<double>();

        static List<TextBox> texty = new List<TextBox>();

       
        static List<TextBox> texts = new List<TextBox>();

        public StalePrawdopodobienstwo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;


            var icon = new PackIcon
            {
                Kind = PackIconKind.Delete,
                Foreground = Brushes.Black,
                Background = Brushes.Transparent,
                Width = 50,
                Height = 50,
                BorderBrush = Brushes.Transparent
            };


            Button btn = CreateDeleteButton(icon);
            TextBox text = CreateTextBoxName();
            texty.Add(text);
            TextBoxs.Add(btn.Name);
            panel.Children.Add(btn);
            panel.Children.Add(text);
            btn.Click += Btn_Click;

          
            xyz.Children.Add(panel);
            number += 1;

        }

       

     

        private static TextBox CreateTextBoxName()
        {
            TextBox text = new TextBox();
            text.Margin = new Thickness(15);
            text.Opacity = 0.4;
            text.SetValue(TextBoxHelper.WatermarkProperty, "Wprowadz Imie");
            text.Width = 100;
            text.Height = 20;
            return text;
        }

        private static Button CreateDeleteButton(PackIcon icon)
        {
            Button btn = new Button();

            btn.Content = icon;
            btn.Name = "b" + number;
            btn.Height = 50;
            btn.Width = 50;
            btn.BorderBrush = Brushes.Transparent;
            return btn;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            StackPanel parent = (StackPanel)btn.Parent;
            var liczba = xyz.Children.IndexOf(parent);
            int index = TextBoxs.IndexOf(btn.Name);
            texty.RemoveAt(index);
            TextBoxs.Remove(btn.Name);
            xyz.Children.RemoveAt(liczba);

            number = number - 1;

        }

  


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var condition = true;

            for (int i = 0; i < texty.Count; i++)
            {
                if (texty[i].Text == "")
                    condition = false;
            }
        
            if(texty.Count <= 1)
            {
            
                condition = false;
            }
           
            if (condition)
            {

                Random random = new Random();

                var SelectedNumber = random.Next(0, texty.Count);
                this.ShowMessageAsync("Wygrany", "Zwyciesca Jest : " + texty[SelectedNumber].Text);
             

            }
            else
            {
                this.ShowMessageAsync("Blad", "Zadne pole nie moze pozostac puste, lub liczba osob jest mniejsza niz 2");
              
            }
        }

   
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {


        }

        private void X_MouseUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StalePrawdopodobienstwo stale = new StalePrawdopodobienstwo();
            Czyszczenie();
            stale.Show();
            this.Close();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ConstantProbability constant = new ConstantProbability();
            Czyszczenie();

            constant.Show();
            this.Close();
        }

        private static void Czyszczenie()
        {
            texty.Clear();
            TextBoxs.Clear();
        }
    }
}
