using System;
using MySql.Data.MySqlClient;

namespace kütüphaneSistemi
{
    public static class Veritabani
    {
        private static string baglantiCumlesi = "Server=localhost;Database=kutuphanedb;Uid=root;Pwd=1234;";

        public static MySqlConnection Baglan()
        {
            return new MySqlConnection(baglantiCumlesi);
        }
    }
}