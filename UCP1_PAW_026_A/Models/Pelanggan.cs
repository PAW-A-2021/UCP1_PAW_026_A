using System;
using System.Collections.Generic;

namespace UCP1_PAW_026_A.Models
{
    public partial class Pelanggan
    {
        public Pelanggan()
        {
            Pesanan = new HashSet<Pesanan>();
        }

        public int IdPelanggan { get; set; }
        public string NamaPelanggan { get; set; }
        public string Alamat { get; set; }
        public string NoHp { get; set; }

        public ICollection<Pesanan> Pesanan { get; set; }
    }
}
