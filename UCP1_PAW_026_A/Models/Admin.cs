using System;
using System.Collections.Generic;

namespace UCP1_PAW_026_A.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Pesanan = new HashSet<Pesanan>();
        }

        public int IdAdmin { get; set; }
        public string NamaAdmin { get; set; }
        public string NoHp { get; set; }

        public ICollection<Pesanan> Pesanan { get; set; }
    }
}
