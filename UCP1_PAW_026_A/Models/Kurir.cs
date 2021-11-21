using System;
using System.Collections.Generic;

namespace UCP1_PAW_026_A.Models
{
    public partial class Kurir
    {
        public Kurir()
        {
            Pesanan = new HashSet<Pesanan>();
        }

        public int IdKurir { get; set; }
        public string NamaKurir { get; set; }
        public int? NoHp { get; set; }

        public ICollection<Pesanan> Pesanan { get; set; }
    }
}
