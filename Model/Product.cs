namespace TestAppForRit.Model
{
    class Product : OtherAsset
    {
        public override string ToString()
        {
            string str = $"{Name}";
            if (Year > 0)
            {
                str += $", {Year} года изготовления";
            }
            str += $", начальная стоимость {InitialCost}, остаточная стоимость {ResidualCost}, рыночная стоимость {Cost}";
            if (!string.IsNullOrEmpty(InventoryNumber))
            {
                str += $", инвентарный номер {InventoryNumber}";
            }
            return str;
        }
    }
}