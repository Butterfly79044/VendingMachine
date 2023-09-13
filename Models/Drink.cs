namespace VendingMachine.Models
{
    public class Drink
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int Qty { get; set; }
        public ushort Price { get; set; }
    }
}
