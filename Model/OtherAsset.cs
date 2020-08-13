namespace TestAppForRit.Model
{
    abstract class OtherAsset : Asset
    {
        public int InitialCost { get; set; }
        public int ResidualCost { get; set; }
        public string InventoryNumber { get; set; }
        public int Year { get; set; }
        
    }
}