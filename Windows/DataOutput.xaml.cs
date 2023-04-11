using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FlowersCompany
{
    /// <summary>
    /// Логика взаимодействия для DataOutput.xaml
    /// </summary>
    public partial class DataOutput : Window
    {
        FlowersEntities2 BD = new FlowersEntities2();
        int PagesNumber = 0;
        Product Product;
        public List<Product> ProductList;
        public DataOutput()
        {
            InitializeComponent();
            PagesView(0);
        }
        private void PagesView(int number)
        {
            int count = 14;
            int firstnumber = 0;
            List<Product> products = BD.Product.ToList();

            var list = (from a in products
                        join b in BD.Manufacturer on a.Manufacturer equals b.ID_Manufacturer
                        select new
                        {
                            Image = a.Image,
                            Name = a.Name_,
                            Description = a.Opisanie,
                            Manufacture = b.Manufacturer1,
                            CurrentDecimal = a.DeistSkidka,
                            Price = a.Cost,
                            BackgroundColor = a.DeistSkidka >= 15 ? "#7fff00" : "Transparent",
                            DiscountPrice = a.DeistSkidka == 0 ? "" : Math.Round(((double)a.Cost * (100 - Convert.ToDouble(a.DeistSkidka)) / 100), 3).ToString(),
                            TextDecoration = a.DeistSkidka != 0 ? "Strikethrough" : "None"
                        }).ToList();

            ListViewData.Items.Clear();
            //Работа с нумерацией страниц
            if (list.Count() - number < 15)
            {
                count = list.Count();
            }
            else
            {
                count += number;
            }

            if (list.Count() >= number)
                try
                {
                    ListViewData.Items.Clear();
                    for (int i = number; i < count; i++)
                        ListViewData.Items.Add(list[i]);
                    firstnumber = count;
                }
                catch
                {
                    number = 0;
                    count = 14;
                    for (int i = number; i < count; i++)
                        ListViewData.Items.Add(list[i]);
                    firstnumber = count;
                }
            int ListCount = BD.Product.Count();
            SecondLabel.Content = ListCount.ToString();
            if (firstnumber == ListCount)
            {
                firstnumber = ListCount;
            }
            else
            {
                firstnumber += 1;
            }
            FirstLabel.Content = firstnumber.ToString();
        }
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            PagesView(0);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            int FirstNumber = Convert.ToInt32(FirstLabel.Content);
            int SecondNumber = Convert.ToInt32(SecondLabel.Content);
            int MaxNumber = BD.Product.Count();
            if (FirstNumber != SecondNumber)
            {
                if (MaxNumber >= PagesNumber)
                {
                    PagesNumber += 15;
                    PagesView(PagesNumber);
                }
            }
            else
            {

            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (PagesNumber != 0)
            {
                PagesNumber -= 15;
                PagesView(PagesNumber);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
