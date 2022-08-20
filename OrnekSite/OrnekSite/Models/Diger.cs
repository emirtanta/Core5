namespace OrnekSite.Models
{
    //rol-sipariş-session işlemleri için tanımlandı
    public static class Diger
    {
        public const string Role_Birey = "Birey"; //facebook yada google ile giriş yapanlar için

        public const string Role_Admin = "Admin";
        public const string Role_User = "User";
        public const string ssShoppingCart = "Shopping Car Session";

        //sipariş durumları tanımlandı
        public const string Durum_Onaylandı = "Onaylandı";
        public const string Durum_Beklemede = "Beklemede";
        public const string Durum_Kargoda = "kargoya Verildi";
    }
}
