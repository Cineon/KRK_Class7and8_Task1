using KRK_Class7_Task1.Models;

namespace KRK_Class7_Task1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Clients.Any())
            {
                return;
                // DB already seeded. Exit method Initialize.
            }


            var clients = new Client[]
            {
                new Client{ClientID=1,Name="Deck",Email="dshapira0@wikimedia.org",Address="942 Kennedy Terrace"},
                new Client{ClientID=2,Name="Elton",Email="elbutnotjohn@hotmail.com",Address="170 Oak Trail"},
                new Client{ClientID=3,Name="Jayson",Email="jwellstood2@skype.com",Address="90 South Hill"},
                new Client{ClientID=4,Name="Stefano",Email="sbosden4@histats.com",Address="74838 Packers Trail"},
                new Client{ClientID=5,Name="Otis",Email="oransfield5@opera.com",Address="62 Badeau Parkway"},
                new Client{ClientID=6,Name="Maury",Email="mselvey8@army.mil",Address="7181 Reindahl Drive"},
                new Client{ClientID=7,Name="Rob",Email="rmayo9@1688.com",Address="8 Kings Road"}
            };
            foreach (Client c in clients) { context.Clients.Add(c); }
            context.SaveChanges();


            var categories = new Category[]
            {
                new Category{CategoryID=1, Name="Kuchnia", IsActive=true},
                new Category{CategoryID=2, Name="Łazienka", IsActive=true},
                new Category{CategoryID=3, Name="Salon", IsActive=true},
                new Category{CategoryID=4, Name="Ogród", IsActive=true}
            };
            foreach (Category c in categories) { context.Categories.Add(c); }
            context.SaveChanges();


            var orders = new Order[]
            {
                new Order{OrderID=1, Date=DateTime.Parse("12/02/2023"), ClientID=5, Price=169.98m},
                new Order{OrderID=2, Date=DateTime.Parse("15/02/2023"), ClientID=1, Price=4149.97m},
                new Order{OrderID=3, Date=DateTime.Parse("04/04/2023"), ClientID=4, Price=89.99m},
                new Order{OrderID=4, Date=DateTime.Parse("19/02/2023"), ClientID=5, Price=5.99m}
            };
            foreach (Order o in orders) { context.Orders.Add(o); }
            context.SaveChanges();


            var products = new Product[]
            {
                new Product{ProductID=1, Name="Zestaw sztućców", CategoryID=1, Price=99.99m},
                new Product{ProductID=2, Name="Patelnia z teflonem", CategoryID=1, Price=69.99m},
                new Product{ProductID=3, Name="Słuchawka prysznicowa", CategoryID=2, Price=89.99m},
                new Product{ProductID=4, Name="Ręczniki komplet", CategoryID=2, Price=139.99m},
                new Product{ProductID=5, Name="Komoda agristo", CategoryID=3, Price=1659.99m},
                new Product{ProductID=6, Name="Sofa konvora", CategoryID=3, Price=2359.99m},
                new Product{ProductID=7, Name="Hamak uviso", CategoryID=4, Price=129.99m},
                new Product{ProductID=8, Name="trytytki", CategoryID=null, Price=5.99m}
            };
            foreach (Product p in products) { context.Products.Add(p); }
            context.SaveChanges();


            var orderproducts = new OrderProduct[]
            {
                new OrderProduct{OrderProductID=1, Count=2, OrderID=1, ProductID=1, Price=99.99m},
                new OrderProduct{OrderProductID=2, Count=2, OrderID=1, ProductID=2, Price=69.99m},

                new OrderProduct{OrderProductID=3, Count=3, OrderID=2, ProductID=5, Price=1659.99m},
                new OrderProduct{OrderProductID=4, Count=3, OrderID=2, ProductID=6, Price=2359.99m},
                new OrderProduct{OrderProductID=5, Count=3, OrderID=2, ProductID=7, Price=129.99m},

                new OrderProduct{OrderProductID=6, Count=1, OrderID=3, ProductID=3, Price=89.99m},

                new OrderProduct{OrderProductID=7, Count=1, OrderID=4, ProductID=8, Price=5.99m}
            };
            foreach (OrderProduct op in  orderproducts) { context.OrderProducts.Add(op); }
            context.SaveChanges();


            


            


            // Żeby dane w kolumnach price i count miały sens, sam musiałem sumować ceny produktów
            // i wstawiać w odpowiednie miejsca. Jest to oczywiście niepraktyczny i nieprawidłowy sposób
            // na integracje danych.
            // Pytanie: Jak powinno zostać to wykonane, żeby te wartości uzupełniały się same automatycznie?
            // Mój pomysł to dodanie triggera lub procedury w bazie.
        }
    }
}
