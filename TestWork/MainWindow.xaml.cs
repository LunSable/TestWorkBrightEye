using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using TestWork.DataModel;

namespace TestWork
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (NumbersContext dbOne = new NumbersContext())
            {
                dbOne.Database.ExecuteSqlCommand("TRUNCATE TABLE [SortNumbers]");
                dbOne.Database.ExecuteSqlCommand("TRUNCATE TABLE [Numbers]");

            }
        }

        private void RandomOneTable_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            using (NumbersContext dbOne = new NumbersContext())
            {
                for (int i = 0; i < 10; i++)
                {
                    Number number = new Number();
                    number.Number_Rand = rnd.Next(1, 11);
                    dbOne.Numbers.Add(number);
                }
                dbOne.SaveChanges();
                dbOne.Numbers.Load();
                DataGridOne.ItemsSource = dbOne.Numbers.Local.ToBindingList();
            }
        }

        private void SortTwoTable_Click(object sender, RoutedEventArgs e)
        {
            using (NumbersContext dbOne = new NumbersContext())
            {
                dbOne.SortTable.Load();
                var sort_tab = dbOne.Numbers.OrderBy(c => c.Number_Rand);
                Console.WriteLine(dbOne.Numbers.Count());
                for (int i = 0; i < 10; i++)
                {
                    SortNumber sort = new SortNumber();
                    Console.WriteLine(i);
                    sort.Number_Sort = sort_tab.Select(c => c.Number_Rand).AsEnumerable().ElementAtOrDefault(i);
                    dbOne.SortTable.Add(sort);
                }
                dbOne.SaveChanges();
                dbOne.SortTable.Load();
                DataGridTwo.ItemsSource = dbOne.SortTable.Local.ToBindingList();

            }
        }
    }
}
