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


namespace RandomLists
{
    /// <summary>
    /// Interaction logic for ConstantProbability.xaml
    /// </summary>
    /// 

       
    public partial class ConstantProbability : Window
    {
        static int suma = 100;
        static int number = 0;

        static List <String> TextBoxs = new List<string>();
        static  List<String> TracksName = new List<string>();
        static List<String> txtName= new List<string>();
        static List<double> tracks = new List<double>();

        static List<TextBox> texty = new List<TextBox>();

        public ConstantProbability()
        {
           InitializeComponent();

        




        }
        static List<TextBox> texts = new List<TextBox>();
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

            TextBox text1 = CreateTexbBoxInputPropability();
            Slider slider = CreateSlider();

            var b = new Binding();
            b.Source = slider;
            b.Path = new PropertyPath("Value");

            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            text1.SetBinding(TextBox.TextProperty, b);
            texts.Add(text1);
            var el = CheckSumOfProbability();



            TextBoxs.Add(btn.Name);
            TracksName.Add(Name);


            panel.Children.Add(btn);
            panel.Children.Add(text);
            panel.Children.Add(slider);
            panel.Children.Add(text1);
            btn.Click += Btn_Click;






            if (el)
                xyz.Children.Add(panel);
            number += 1;

        }

        private static Slider CreateSlider()
        {
            Slider slider = new Slider();
            slider.Background = Brushes.Transparent;
            slider.Foreground = Brushes.LightCoral;
            slider.Name = "b" + number;
            slider.Margin = new Thickness { Right = 10 };
            slider.TickFrequency = 1;
            slider.Width = 100;
            slider.Height = 20;
            slider.Minimum = 1;
            slider.Maximum = 99;
            slider.IsSnapToTickEnabled = true;
          
            return slider;
        }

        private static TextBox CreateTexbBoxInputPropability()
        {
            TextBox text1 = new TextBox();
            text1.Margin = new Thickness(15);
            text1.Name = "b" + number;



            text1.Width = 40;
            text1.Height = 20;
            text1.Opacity = 0.4;
            return text1;
        }

        private static TextBox CreateTextBoxName()
        {
            TextBox text = new TextBox();
            text.Margin = new Thickness(15);
            text.Opacity = 0.4;




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
            var liczba= xyz.Children.IndexOf(parent);
                   int index = TextBoxs.IndexOf(btn.Name);
            TextBoxs.Remove(btn.Name);
           TracksName.Remove(btn.Name);
            texts.RemoveAt(index);
            texty.RemoveAt(index);
     
            //tracks.RemoveAt(index);
            
            xyz.Children.RemoveAt(liczba);
           
            number = number - 1;
       
        }

        public static bool CheckSumOfProbability()
        {
            //bool canPut = true;
            int wartosc = NewMethod();
            if (wartosc >= 100)
            {
                number = number - 1;
                texts.RemoveAt(texts.Count - 1);
                TracksName.RemoveAt(texts.Count - 1);
                texty.RemoveAt(texty.Count-1);
                Wyrownaj();

                MessageBox.Show("Nie mozesz Dodac Kolejnego Goscia poniewaz suma prawdopodobieństw Równa jest 100%");
                return false;
            }
     

            if (suma == 0)
            {


                return false;
            }

            return true;

        }

        private static int NewMethod()
        {
            int wartosc = 0;

            for (int i = 0; i < texts.Count; i++)
            {
                wartosc += Int32.Parse(texts[i].Text);
            }

            return wartosc;
        }

        private static void Wyrownaj()
        {
            int x = 0;
            for (int k = 0; k < texts.Count - 1; k++)
            {
                x += Int32.Parse(texts[k].Text);
            }
         
            int war = 100 - x;

            texts[texts.Count - 1].Text = war.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var boolik = true;
            var msg = true;

            for (int i = 0; i < texty.Count; i++)
            {
                    if(texty[i].Text == "")
                {
                    boolik = false;
                    break;
                }
            }
            if(boolik == false)
            {
                msg = false;
                MessageBox.Show("Zadne pole nie moze zostac puste");
            }
            int wartosc = NewMethod();
            if (boolik && TextBoxs.Count > 1 && wartosc  <=100)
            {
                Wyrownaj();
                Random random = new Random();
                List<int> values = new List<int>();

                List<int> randomNumbers = CreateRandomNUmbers(random);

                var SelectedNumber = random.Next(1, 100);
                
                int el = randomNumbers.IndexOf(SelectedNumber);
              
                int suma = 0;
                for (int i = 0; i < texts.Count; i++)
                {
                    suma += Int32.Parse(texts[i].Text);
                    values.Add(suma);

                }

                for (int i = 0; i < values.Count; i++)
                {
                    if (values[i] >= el)
                    {
                        el = i;
                        break;
                    }
                }
                MessageBox.Show("Zwyciesca jest :"+ texty[el].Text);
            }
            else 
            {
                if(msg)
                MessageBox.Show("Nie dodano żadnych osob, musza być przynajmniej dwie, " +
                    "lub prawdopodobieństwo przekracza 100%");
            }
            }

        private static List<int> CreateRandomNUmbers(Random random)
        {
            var randomNumbers = Enumerable.Range(1, 100).OrderBy(x => random.Next()).Take(100).ToList();
            var q = from x in randomNumbers
                    group x by x into g
                    let count = g.Count()
                    orderby count descending
                    select new { Value = g.Key, Counts = count };
            return randomNumbers;
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
            stale.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ConstantProbability constant = new ConstantProbability();
            constant.Show();
            this.Close();
        }
    }
}

