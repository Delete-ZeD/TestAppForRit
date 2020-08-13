namespace TestAppForRit.Model
{
    class Asset
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int Cost { get; set; }
        public override string ToString()
        {
            return $"Актив: {Name}, общая стоимость: {Cost}";
        }
    }
}