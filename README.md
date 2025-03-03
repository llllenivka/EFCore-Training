# EFCore-Training
Обучение фреймворку Entity Framework Core

1. [FirstApp](#1-firstapp)
    - [Подготовка к работе](#подготовка-к-работе)
    - [Работа с базой данных](#работа-с-базой-данных)
    - [Взаимодействие с БД](#взаимодействие-с-бд)

Разработка ведется с использованием .Net 9.

## 1. FirstApp

### Подготовка к работе

Создала новое консольно приложение в __Rider__.

Для работы с __Entity Framework__ Core небходим Nuget-пакет, поэтому установила через интсрумент работы с Nuget в Rider __Microsoft.EntityFrameworkCore.Sqlite__.

![FirstApp-NugetPackage](./img/FirstApp/NugetPackage.png)

### Работа с базой данных

После добавление неоходимого пакета, можно перейти к созданию модели, в которой описываются данные пользователя.

![FirstApp-User](./img/FirstApp/User.png)

Взаимодействие с базой данных в Entity Framework Core происходит посредством специального класса - контекста данных. Поэтому добавила в проект новый класс - __ApplicationDbContext__.

![ApplicationDbContext](./img/FirstApp/ApplicationDbContext.png)

Для работы приложения с базой данной через Entity Framework необходим контекст данных - класс производный от __DbContext__. В данном случае таким контекстом является класс __ApplicationDbContext__.

```csharp
public class AplicationDbContext : DbContext
```

По умолчанию у нас нет базы данных. Поэтому в конструкторе класса контекста определен вызов метода Database.EnsureCreated(), который при создании контекста автоматически проверит наличие базы данных и, если она отсуствует, создаст ее.

``` csharp
public ApplicationContext() => Database.EnsureCreated();
```

Так же определено свойство __Users__, в котором хранится набор объектов __User__. В классе контекста данных набор объектов представляет класс DbSet<T>, и как раз на этом свойстве и создается таблица.

```csharp
DbSet<User> Users { get; set; }
```

Для настройки подключения переопределила метод __OnConfiguring__. Передаваемый в него параметр класса __DbContextOptionsBuilder__ с помощью метода __UseSqlite__ позволяет настроить строку подключения для соединения с базой данных __SQLite__.

```csharp
optionsBuilder.UseSqlite("Data Source=helloapp.db");
```
В качестве параметра в метод передается строка подключения, которая в данном случае имеет только один параметр - __Data Source__. Он определяет файл базы данных - в данном случае "helloapp.db".

### Взаимодействие с БД

Переопределен файл __Program.cs__, в котором работаем с БД. 

![FirstApp-Program](./img/FirstApp/Program.png)

Используется конструкция using для автоматического вызова __Dispose()__ у ApplicationContext.
В конструкции создаются два объекта и добавляются в БД с помощью метода __Add()__ и в конце сохраняем изменения методом __SaveChages()__.

```csharp
User tom = new User() { Name = "Tom", Age = 33 };
User alice = new User() { Name = "Alice", Age = 26 };

db.Users.Add(tom);
db.Users.Add(alice);
db.SaveChanges();
```

Чтобы получить список данных из бд, достаточно воспользоваться свойством Users контекста данных: __db.Users__.

### Вывод

В результате после запуска программа выведет на консоль:

![FirstApp-OutputConsole](./img/FirstApp/OutputConsole.png)

Поскольку в классе контекста при установке строки подключения к Sqlite указан относительный путь, то после выполнения программы мы можем найти файл базы данных в папке проекта:

![FirstApp-SaveDbFile](./img/FirstApp/SaveDbFile.png)

Создание базы данных в EF Core
С помощью специальных программ, например, DB Browser for SQLite мы можем посмотреть ее содержимое.