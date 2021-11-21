using System;
using System.Collections.Generic;

namespace UCP1_PAW_026_A.Models
{
    public partial class Makanan
    {
        public Makanan()
        {
            Pesanan = new HashSet<Pesanan>();
        }

        public int IdMakanan { get; set; }
        public int? HargaMakanan { get; set; }
        public string NamaMakanan { get; set; }
        public string Ketersediaan { get; set; }

        public ICollection<Pesanan> Pesanan { get; set; }
    }
}
