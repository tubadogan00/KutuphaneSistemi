using System;
using System.Collections.Generic;
using System.Text;

namespace kütüphaneSistemi
{
    public class Kitap
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public string ISBN { get; set; }
        public int YayinYili { get; set; }
        public int Sayfa { get; set; }
        public string Tur { get; set; }
        public int Stok { get; set; }
    }
}
