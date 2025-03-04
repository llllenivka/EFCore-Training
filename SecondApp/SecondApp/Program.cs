namespace SecondApp;

class Program
{
    static void Main(string[] args)
    {
        // Добавление
        using (AplicationDbContext db = new AplicationDbContext())
        {
            User tom = new User { Name = "Tom", Age = 18 };
            User alice = new User { Name = "Alice", Age = 26 };
            
            db.Users.Add(tom);
            db.Users.Add(alice);
            db.SaveChanges();
        }
        
        // Получение
        using (AplicationDbContext db = new AplicationDbContext())
        {
            var users = db.Users.ToList();
            Console.WriteLine("Данные после добавления:");
            foreach (var u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            }
        }

        // Редактирование
        using (AplicationDbContext db = new AplicationDbContext())
        {
            User? user = db.Users.FirstOrDefault();
            if (user != null)
            {
                user.Name = "Bob";
                user.Age = 26;
                db.SaveChanges();
                
            }
            
            Console.WriteLine("\nДанные после редактирования:");
            var users = db.Users.ToList();
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            }
        }

        using (AplicationDbContext db = new AplicationDbContext())
        {
            User? user = db.Users.FirstOrDefault();
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            
            Console.WriteLine("\nДанные после удаления:");
            var users = db.Users.ToList();
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            }
            
        }
        
        
    }
}