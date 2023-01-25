public class Menu {
    public UserInventorySQLite _inventorySQLite;
    public UserInventory _inventory;
    public string _db;

    public Menu(UserInventorySQLite inventorySQLite, UserInventory inventory) {
        _inventorySQLite = inventorySQLite;
        _inventory = inventory;
        _db = "SQLite";
    }

    public void MenuShow() {
        while (true) {
            Console.WriteLine($"Aktualna baza danych: {_db}\n");
            Console.WriteLine("Menu programu");
            Console.WriteLine("-----------------");
            Console.WriteLine("1. Dodaj uzytkownika");
            Console.WriteLine("2. Wyswietl wszystko");
            Console.WriteLine("3. Zmiana bazy");

            Console.Write("\nWybor: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice) {
                case 1:
                    AddUser();
                    break;
                case 2:
                    ShowDB();
                    break;
                case 3:
                    ChangeDB();
                    break;
                default:
                    break;
            }
        }
    }

    private void ChangeDB() {
        Console.Clear();
        Console.WriteLine("Bazy danych");
        Console.WriteLine("--------------");
        Console.WriteLine("1. SQL");
        Console.WriteLine("2. SQLite");

        Console.Write("\nWybor: ");
        int wyborDB = int.Parse(Console.ReadLine());

        switch (wyborDB) {
            case 1:
                _db = "SQL";
                break;
            case 2:
                _db = "SQLite";
                break;
            default:
                break;
        }

        Console.Clear();
    }

    private void AddUser() {
        Console.Clear();
        Console.Write("Podaj id: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Podaj imie: ");
        string firstname = Console.ReadLine();

        Console.Write("Podaj nazwisko: ");
        string lastname = Console.ReadLine();

        Console.Write("Podaj wiek: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Podaj mail: ");
        string mail = Console.ReadLine();

        User newUser = new User {
            Id = id,
            FirstName = firstname,
            LastName = lastname,
            Age = age,
            Mail = mail
        };

        if (_db == "SQL") {
            _inventory.NewQuerry(newUser);
        }else if(_db == "SQLite") {
            _inventorySQLite.NewQuerry(newUser);
        }



        Console.Clear();
    }

    private void ShowDB() {
        Console.Clear();

        IEnumerable<User> r2 = null;

        if (_db == "SQL") {
            r2 = _inventory.GetData();
        } else if (_db == "SQLite") {
            r2 = _inventorySQLite.GetData();
        }

        foreach (var item in r2) {
            Console.WriteLine($"Id: {item.Id}, Imie: {item.FirstName}, Nazwisko: {item.LastName}, Wiek: {item.Age}, Mail: {item.Mail}");
        }

        Console.Write("Nacisnij dowolny przycisk aby kontynuowac...");
        Console.ReadKey();
        Console.Clear();
    }
}