using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestAppForRit.Model;

namespace TestAppForRit
{
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();

            HideAllViews();

            if (Data.Object == null)
                return;

            if (Data.Object.GetType().ToString() == "TestAppForRit.Model.Asset")
            {
                var asset = (Asset)Data.Object;
                comboBox.SelectedIndex = 0;
                nameTextBox.Text = asset.Name;
                costTextBox.Text = asset.Cost.ToString();
            }
            else if (Data.Object.GetType().ToString() == "TestAppForRit.Model.Share")
            {
                var share = (Share)Data.Object;
                comboBox.SelectedIndex = 1;
                nameTextBox.Text = share.Name;
                countTextBox.Text = share.Count.ToString();
                costTextBox.Text = share.Cost.ToString();
            }
            else if (Data.Object.GetType().ToString() == "TestAppForRit.Model.Product")
            {
                var product = (Product)Data.Object;
                comboBox.SelectedIndex = 2;
                nameTextBox.Text = product.Name;
                costTextBox.Text = product.Cost.ToString();
                initialCostTextBox.Text = product.InitialCost.ToString();
                residualCostTextBox.Text = product.ResidualCost.ToString();
                yearTextBox.Text = product.Year.ToString();
                inventoryNumberTextBox.Text = product.InventoryNumber;
            }
            else if (Data.Object.GetType().ToString() == "TestAppForRit.Model.Realty")
            {
                var realty = (Realty)Data.Object;
                comboBox.SelectedIndex = 3;
                nameTextBox.Text = realty.Name;
                costTextBox.Text = realty.Cost.ToString();
                initialCostTextBox.Text = realty.InitialCost.ToString();
                residualCostTextBox.Text = realty.ResidualCost.ToString();
                yearTextBox.Text = realty.Year.ToString();
                addressTextBox.Text = realty.Address;
                inventoryNumberTextBox.Text = realty.InventoryNumber;
            }
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            string iName = nameTextBox.Text;
            int iCost;
            int.TryParse(costTextBox.Text, out iCost);
            int iCount;
            int.TryParse(countTextBox.Text, out iCount);
            int iInitialCost;
            int.TryParse(initialCostTextBox.Text, out iInitialCost);
            int iResidualCost;
            int.TryParse(residualCostTextBox.Text, out iResidualCost);
            string iInventoryNumber = inventoryNumberTextBox.Text;
            int iYear;
            int.TryParse(yearTextBox.Text, out iYear);
            string iAddress = addressTextBox.Text;

            object obj;
            if (comboBox.SelectedIndex == 0)
            {
                obj = new Asset { Name = iName, Cost = iCost };
            }
            else if (comboBox.SelectedIndex == 1)
            {
                obj = new Share { Name = iName, Cost = iCost, Count = iCount };
            }
            else if (comboBox.SelectedIndex == 2)
            {
                obj = new Product { Name = iName, Cost = iCost, InitialCost = iInitialCost, ResidualCost = iResidualCost, Year = iYear, InventoryNumber = iInventoryNumber };
            }
            else if (comboBox.SelectedIndex == 3)
            {
                obj = new Realty { Name = iName, Cost = iCost, InitialCost = iInitialCost, ResidualCost = iResidualCost, Year = iYear, InventoryNumber = iInventoryNumber, Address = iAddress };
            }
            else
            {
                return;
            }

            Data.Object = obj;
            this.DialogResult = true;
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    {
                        ShowAsset();
                        break;
                    }
                case 1:
                    {
                        ShowShare();
                        break;
                    }
                case 2:
                    {
                        ShowProduct();
                        break;
                    }
                case 3:
                    {
                        ShowRealty();
                        break;
                    }
                default:
                    break;
            }
        }

        private void HideAllViews()
        {
            nameTextBox.IsEnabled = false;
            countTextBox.IsEnabled = false;
            costTextBox.IsEnabled = false;
            initialCostTextBox.IsEnabled = false;
            residualCostTextBox.IsEnabled = false;
            yearTextBox.IsEnabled = false;
            addressTextBox.IsEnabled = false;
            inventoryNumberTextBox.IsEnabled = false;
        }
        private void ShowAsset()
        {
            HideAllViews();
            nameTextBox.IsEnabled = true;
            costTextBox.IsEnabled = true;
            costLabel.Content = "Номинал";
        }
        private void ShowShare()
        {
            HideAllViews();
            nameTextBox.IsEnabled = true;
            costTextBox.IsEnabled = true;
            countTextBox.IsEnabled = true;
            costLabel.Content = "Цена за 1шт";
        }
        private void ShowProduct()
        {
            HideAllViews();
            nameTextBox.IsEnabled = true;
            initialCostTextBox.IsEnabled = true;
            residualCostTextBox.IsEnabled = true;
            yearTextBox.IsEnabled = true;
            inventoryNumberTextBox.IsEnabled = true;
            costTextBox.IsEnabled = true;
            costLabel.Content = "Рыночная стоимость ";
            yearLabel.Content = "Год производства";
        }
        private void ShowRealty()
        {
            HideAllViews();
            nameTextBox.IsEnabled = true;
            initialCostTextBox.IsEnabled = true;
            residualCostTextBox.IsEnabled = true;
            yearTextBox.IsEnabled = true;
            addressTextBox.IsEnabled = true;
            inventoryNumberTextBox.IsEnabled = true;
            costTextBox.IsEnabled = true;
            costLabel.Content = "Оценочная стоимость ";
            yearLabel.Content = "Год постройки";
        }
        private void DisigCheckTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
