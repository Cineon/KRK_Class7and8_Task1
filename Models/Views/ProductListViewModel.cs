
namespace KRK_Class7_Task1.Models.Views
{
    public class ProductListViewModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }


        // W zamyśle klasa Produkt.cs służy nam jedynie do wyciągnięcia danych z bazy,
        // podczas gdy ta klasa służy do wyświetlenia danych w modelu.
        // Zasilenie tego modelu danymi wymaga przemapowanie danych.
        // czego dokonujemy w serwisie.
    }
}
