using System;
using System.Collections.Generic;

namespace UCP1_PAW_026_A.Models
{
    public partial class Pesanan
    {
        public int IdPesanan { get; set; }
        public int? IdAdmin { get; set; }
        public int? IdKurir { get; set; }
        public int? IdMakanan { get; set; }
        public int? IdPelanggan { get; set; }
        public int? TotalHarga { get; set; }
        public DateTime? TglPemesanan { get; set; }

        public Admin IdAdminNavigation { get; set; }
        public Kurir IdKurirNavigation { get; set; }
        public Makanan IdMakananNavigation { get; set; }
        public Pelanggan IdPelangganNavigation { get; set; }
    }
}
