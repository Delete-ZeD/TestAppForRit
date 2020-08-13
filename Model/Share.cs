namespace TestAppForRit.Model
{
    class Share : Asset
    {
        public int TotalCost { get { return Cost * Count; } }

        public override string ToString()
        {
            return $"Акции: {Name}, количество: {Count}, стоимость за 1шт: {Cost}, общая стоимость: {Count}x{Cost}={TotalCost}";
        }
    }
}