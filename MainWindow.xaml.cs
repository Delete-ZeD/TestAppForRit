using System.Collections.Generic;
using System.Windows;
using TestAppForRit.Model;

namespace TestAppForRit
{
    public partial class MainWindow : Window
    {
        List<Form> assetList = new List<Form>();
        int listСounter = 0;
        public MainWindow()
        {
            InitializeComponent();

            TestAssets();
        }
        private void grid_Loader(object sender, RoutedEventArgs e)
        {
            dataGridView.ItemsSource = assetList;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var asset = new Form { Number = ++listСounter };
            assetList.Add(asset);

            dataGridView.Items.Refresh();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridView.SelectedItem == null)
                return;

            assetList.Remove((Form)dataGridView.SelectedItem);

            dataGridView.Items.Refresh();
        }
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridView.SelectedItem == null)
                return;

            Data.Index = ((Form)dataGridView.SelectedItem).Number;
            Data.Object = ((Form)dataGridView.SelectedItem).Obj;
            
            EditWindow editWindow = new EditWindow();
            if (editWindow.ShowDialog()==true)
            {
                EditAsset(Data.Index, Data.Object);

                dataGridView.Items.Refresh();
            }
        }
        public void EditAsset(int index, object obj)
        {
            var form = assetList.Find(x => x.Number == index);
            form.Obj = obj;
        }

        private void TestAssets()
        {
            var asset = new Asset { Name = "ЕвроВорБанк Счёт №5", Cost = 1000 };
            var form = new Form { Number = ++listСounter, Obj = asset };
            assetList.Add(form);

            asset = new Asset { Name = "Внешторгабк Счёт №3", Cost = 5 };
            form = new Form { Number = ++listСounter, Obj = asset };
            assetList.Add(form);

            asset = new Asset { Name = "На кассе", Cost = 500 };
            form = new Form { Number = ++listСounter, Obj = asset };
            assetList.Add(form);

            var share = new Share { Name = "Газпром", Cost = 50, Count = 80 };
            form = new Form { Number = ++listСounter, Obj = share };
            assetList.Add(form);

            var product = new Product { Name = "100 килограммов гвоздей", Cost = 2000, InitialCost = 1000, ResidualCost = 100, Year = 2000 };
            form = new Form { Number = ++listСounter, Obj = product };
            assetList.Add(form);

            var realty = new Realty { Name = "торговое здание ", Address = "Бассейная-6", Year = 1970, Cost = 1000000, InitialCost = 30000, ResidualCost = 5000, InventoryNumber = "7" };
            form = new Form { Number = ++listСounter, Obj = realty };
            assetList.Add(form);
        }
    }
}