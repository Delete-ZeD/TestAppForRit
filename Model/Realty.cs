namespace TestAppForRit.Model
{
    class Realty : OtherAsset
    {
        public string Address { get; set; }
        public override string ToString()
        {
            string str = $"{Name}";
            if (!string.IsNullOrEmpty(Address))
            {
                str += $" по адресу:{Address}";
            }
            if (Year > 0)
            {
                str += $", год пойстройки {Year}";
            }
            str += $", начальная стоимость { InitialCost}, остаточная стоимость { ResidualCost}, оценочная стоимость {Cost}";
            if (!string.IsNullOrEmpty(InventoryNumber))
            {
                str += $", инвентарный номер {InventoryNumber}";
            }
            return str;
        }
    }
}