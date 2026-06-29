using System;
using MySql.Data.MySqlClient;

namespace kütüphaneSistemi
{
    public static class KutuphaneVeri
    {
        // Veritabanı bağlantı cümleni buraya yaz
        public static string BaglantiCumlesi = "Server=localhost;Database=kutuphanedb;Uid=root;Pwd=1234;";

        public static MySqlConnection Baglan()
        {
            return new MySqlConnection(BaglantiCumlesi);
        }
    }
}