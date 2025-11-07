using System.Xml.Linq;
using CarManagementSystem;

namespace CarSales
{
    public class CarSaleApp
    {
        private List<Masin> masinlar = new List<Masin>();
        private BankApp bank;

        public CarSaleApp(BankApp bankApp)
        {
            bank = bankApp;
        }

        public void MasinElaveEt()
        {
            Console.Write("ID: "); int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Marka: "); string marka = Console.ReadLine()!;
            Console.Write("Model: "); string model = Console.ReadLine()!;
            Console.Write("İl: "); int il = Convert.ToInt32(Console.ReadLine());
            Console.Write("Qiymət: "); double qiymet = double.Parse(Console.ReadLine()!);

            Masin masin = new Masin(id, marka, model, il, qiymet);
            masinlar.Add(masin);
            Console.WriteLine($"{marka} {model} satış siyahısına əlavə olundu.");
        }

        public void MasinSil()
        {
            Console.Write("Silinəcək maşının ID-si: ");
            int id = int.Parse(Console.ReadLine()!);

            Masin? masin = masinlar.FirstOrDefault(x => x.Id == id);
            if (masin != null)
            {
                masinlar.Remove(masin);
                Console.WriteLine($"{masin.Marka} {masin.Model} silindi.");
            }
            else Console.WriteLine("Maşın tapılmadı.");
        }

        public void ButunMasinlariGoster()
        {
            if (masinlar.Count == 0)
            {
                Console.WriteLine("Hazırda sistemdə maşın yoxdur.");
                return;
            }

            Console.WriteLine("\n--- SATIŞDA OLAN MAŞINLAR ---");
            foreach (var m in masinlar)
                m.DisplayInfo();
        }

        public void MasinSat()
        {
            Console.Write("Satılacaq maşının ID-si: ");
            int id = int.Parse(Console.ReadLine()!);

            Masin? masin = masinlar.FirstOrDefault(x => x.Id == id);
            if (masin == null)
            {
                Console.WriteLine("Maşın tapılmadı.");
                return;
            }

            masinlar.Remove(masin);
            bank.PulYatir(masin.Qiymet);
            Console.WriteLine($"{masin.Marka} {masin.Model} {masin.Qiymet} AZN-ə satıldı. Pul banka köçürüldü.");
        }

        public void Menyu()
        {
            while (true)
            {
                Console.WriteLine("\n----------------------------- CAR SALE -------------------------------------");
                Console.WriteLine("1. Maşın əlavə et");
                Console.WriteLine("2. Maşın sil");
                Console.WriteLine("3. Bütün maşınları göstər");
                Console.WriteLine("4. Maşını sat");
                Console.WriteLine("0. Geri qayıt");
                Console.Write("Seçim: ");
                string secim = Console.ReadLine()!;

                switch (secim)
                {
                    case "1": MasinElaveEt(); break;
                    case "2": MasinSil(); break;
                    case "3": ButunMasinlariGoster(); break;
                    case "4": MasinSat(); break;
                    case "0": return;
                    default: Console.WriteLine("Yanlış seçim."); break;
                }
            }
        }
    }

}
