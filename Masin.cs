using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagementSystem
{
    public class Masin
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public double Qiymet { get; set; }
        public bool Icarede { get; set; }

        public Masin(string marka, string model, double qiymet)
        {
            Marka = marka;
            Model = model;
            Qiymet = qiymet;
            Icarede = false;
        }
    }
}
