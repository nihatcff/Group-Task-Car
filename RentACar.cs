using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManagementSystem
{
    public class RentACar
    {
        private List<Masin> masinlar = new List<Masin>();
        private BankApp bank;

        public RentACar(BankApp bankApp)
        {
            bank = bankApp;
        }


        public void MasinElaveEt()
        {
            Console.WriteLine("Id:"); int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Marka: "); string marka = Console.ReadLine()!;
            Console.Write("Model: "); string model = Console.ReadLine()!;
            Console.Write("Il: ");int il = Convert.ToInt32(Console.ReadLine());
            Console.Write("Qiymet: "); double qiymet = double.Parse(Console.ReadLine()!);

            Masin masin = new Masin(id,marka, model,il, qiymet);
            masinlar.Add(masin);
            bank.PulCixar(qiymet);
            Console.WriteLine($"{marka} {model} sisteme elave olundu.");
        }

        public void MasinSil()
        {
            Console.Write("Silmek istediyiniz masinin ID: ");
            int id = int.Parse(Console.ReadLine()!);

            Masin? masin = masinlar.FirstOrDefault(x => x.Id == id);
            if (masin != null)
            {
                masinlar.Remove(masin);
                Console.WriteLine($"{masin.Marka} {masin.Model} silindi.");
            }
            else Console.WriteLine("Masin tapilmadi.");
        }

       
        public void MasinFiltrle()
        {
            Console.Write("Filtrlenecek Il: ");
            if (!int.TryParse(Console.ReadLine(), out int il))
            {
                Console.WriteLine("Yanlis il daxil edildi.");
                return;
            }

            var fff = masinlar .Where(x => x.Il == il).OrderBy(x => x.Il) .ToList();

            if (fff.Count == 0)
            {
                Console.WriteLine("Heç bir maşın tapilmadi.");
                return;
            }

            Console.WriteLine($"\n{il} ilə istehsal olunan maşınlar:");
            foreach (var m in fff)
                m.DisplayInfo();
        }

       
        public void MasinCesidle()
        {
            var d = masinlar.OrderBy(x => x.Il).ToList();

            Console.WriteLine("\nBütün maşınlar ilə görə sırala:");
            foreach (var m in d)
                m.DisplayInfo();
        }


        public void MasinSatVeyaKiraye()
        {
            Console.Write("Masinin Marka: ");
            string marka = Console.ReadLine()!;
            Console.Write("Model: ");
            string model = Console.ReadLine()!;

            Masin? masin = masinlar.FirstOrDefault(x => x.Marka == marka && x.Model == model);
            if (masin == null) { Console.WriteLine("Masin tapilmadi."); return; }

            Console.WriteLine("1. Satmaq  2. Kiraye vermek");
            string secim = Console.ReadLine()!;
            if (secim == "1")
            {
                bank.PulCixar(masin.Qiymet); 
                masinlar.Remove(masin);
                Console.WriteLine($"{marka} {model} satildi.");
            }
            else if (secim == "2")
            {
                Console.Write("Kiraye qiymeti: ");
                double kiraye = double.Parse(Console.ReadLine()!);
                masin.Icarede = true;
                bank.PulYatir(kiraye);
                Console.WriteLine($"{marka} {model} kirayeye verildi ({kiraye} AZN).");
            }
            else Console.WriteLine("Yanlis secim.");
        }


        public void Menyu()
        {
            while (true)
            {
                Console.WriteLine("\n----------------------------- RENT A CAR-------------------------------------");
                Console.WriteLine("1. Masin elave et");
                Console.WriteLine("2. Masin sil");
                Console.WriteLine("3. Masinlari filtrle");
                Console.WriteLine("4. Masinlari cesidle (Qiymet)");
                Console.WriteLine("5. Masini sat / kiraye ver");
                Console.WriteLine("0. Cixish");
                Console.Write("Secim: ");
                string secim = Console.ReadLine()!;
                switch (secim)
                {
                    case "1": MasinElaveEt(); break;
                    case "2": MasinSil(); break;
                    case "3": MasinFiltrle(); break;
                    case "4": MasinCesidle(); break;
                    case "5": MasinSatVeyaKiraye(); break;
                    case "0": return;
                    default: Console.WriteLine("Yanlis secim."); break;
                }
            }
        }
    }
}
