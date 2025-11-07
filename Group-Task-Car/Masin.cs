namespace CarManagementSystem
{
    public class Masin
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Il { get; set; }
        public double Qiymet { get; set; }
        public bool Icarede { get; set; }

        public Masin(int id, string marka, string model, int il, double qiymet)
        {
            Id = id;
            Marka = marka;
            Model = model;
            Il = il;
            Qiymet = qiymet;
            Icarede = false;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id} | {Marka} {Model} | İl: {Il} | Qiymət: {Qiymet} AZN | {(Icarede ? "İcarədə" : "Boş")}");
        }
    }

}
