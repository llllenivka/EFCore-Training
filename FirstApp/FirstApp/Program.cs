namespace FirstApp;

public class Program
{
    static void Main(string[] args)
    {
        using (ApplicationDbContext db = new ApplicationDbContext())
        {
            User tom = new User() { Name = "Tom", Age = 33 };
            User alice = new User() { Name = "Alice", Age = 26 };
            
            // добавление в базу данных новых пользователей
            db.Users.Add(tom);
            db.Users.Add(alice);
            db.SaveChanges();
            Console.WriteLine("Пользователи успешно сохранены");
            
            var users = db.Users.ToList();
            Console.WriteLine("Список пользователей:");
            foreach (var u in users)
            {
                Console.WriteLine($"\t{u.Id}. {u.Name} - {u.Age}");
            }
        }
        
    }
    
}