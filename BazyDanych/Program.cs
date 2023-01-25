//SQL

//var inventory = new UserInventory();

/*for (int i = 0; i < 100; i++) { //pomocnicze tylko - dodanie do bazy danych 100 uzytkownikow

    inventory.NewQuerry(
        new User {
            Id = i,
            FirstName = "Piotr " + i,
            LastName = "Nowak" + i,
            Age = 17,
            Mail = "test@testted.com"
        }
    );
}*/


//var r1 = inventory.GetData("Piotr 9");

//foreach (var item in r1) {
//    Console.WriteLine($"Id: {item.Id}, Imie: {item.FirstName}, Nazwisko: {item.LastName}, Wiek: {item.Age}, Mail: {item.Mail}");
//}



///SQLite

/*var inventorySqlite = new UserInventorySQLite();

var r2 = inventorySqlite.GetData();

foreach (var item in r2) {
    Console.WriteLine($"Id: {item.Id}, Imie: {item.FirstName}, Nazwisko: {item.LastName}, Wiek: {item.Age}, Mail: {item.Mail}");
}*/


//menu

var inventorySqlite = new UserInventorySQLite();
var inventory = new UserInventory();

var menu = new Menu(inventorySqlite, inventory);

menu.MenuShow();
