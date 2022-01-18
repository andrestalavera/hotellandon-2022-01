# .NET
> Pour vérifier la version des SDKS : `dotnet --list-sdks`
> Pour vérifier la version des runtimes : `dotnet --list-runtimes`

## Modèles 
1. Ouvrir un terminal dans le dossier `C:\Repos`
1. Créer un projet `librairie de classes` à l'aide de .NET CLI grâce à la commande `dotnet new classlib --name HotelLandon.Models`
1. Créer 3 classes : `Customer`, `Room` et `Reservation`
- `Customer` contient les propriétés suivantes : `FirstName`, `LastName`, `Birthdate`
- `Room` contient `Number`, `Floor`
- `Reservation` : `Customer`, `Room`, `Start`, `End`

## Programme console
1. Créer un projet console avec la commande `dotnet new console --name HotelLandon.DemoConsole`
1. Référencer le projet `HotelLandon.Models` dans le nouveau projet grâce à la commande `dotnet add reference HotelLandon.Models`
1. Ecrire un programme console capable d'instancier un `Customer`
1. Sérialiser et désérialiser en CSV grâce aux classes `System.IO.StreamWriter` et `System.IO.StreamReader`

### Créer un fichier, remplacer un fichier avec un nouveau contenu :
```CSharp
using (StreamWriter writer = new StreamWriter("data.csv"))
{
    writer.WriteLine(customer.ToCsv());
}
```

### Ajouter du texte dans un fichier existant :
```CSharp
using (StreamWriter writer = File.AppendText("data.csv"))
{
    writer.WriteLine(customer.ToCsv());
}
```

### Lire du texte depuis un fichier :
```CSharp
using (StreamReader reader = new StreamReader("data.csv"))
{
    while (!reader.EndOfStream)
    // Alternative: while ((line = reader.ReadLine()) != null)
    {
        string line = reader.ReadLine();
        if (line != null || string.IsNullOrWhiteSpace(line))
        {
            // permet d'ignorer la ligne
            continue;
        }
    }
}
```

### Sérialiser en CSV : 
```CSharp
public string ToCsv()
{
    // avec string interpolation
    return $"{LastName};{FirstName};{BirthDate}";
}
```

### Désérialiser depuis du CSV : 
```CSharp
public Customer ToCustomer(string line)
{
    return new Customer()
    {
        // mapper les propriétés avec les indes des 'colonnes'
        LastName = line[0],
        FirstName = line[1],
        BirthDate = DateTime.Parse(line[2])
    }
}
```

### Sérialiser en JSON
> Pour installer un package NuGet avec dotnet-cli : `dotnet add package {NOM_PACKAGE}` *(`dotnet add package Newtonsoft.Json`)*.
```CSharp
using Newtonsoft.Json;
// ...
public string ToJson(Customer customer)
{
    return JsonConvert.SerializeObject(customer);
}
```

### Désérialiser en JSON 
```CSharp
using Newtonsoft.Json;
public Customer ToCustomer(string json)
{
    return JsonConvert.DeserializeObject<Customer>(json);
}
```

> Vous pouvez exécuter l'application à l'aide de la commande `dotnet run` (= `dotnet restore`, `dotnet build`, exécution). 

## Données
> Installer des outils pour .NET : `dotnet tool install [NAME]`

1. Créer un projet _librairie de classes_ `HotelLandon.Data`
1. Installer les packages `Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.SqlServer` et `Microsoft.EntityFrameworkCore.SqlServer.Design`
1. Créer la classe `HotelLandonContext` qui hérite de `Microsoft.EntityFrameworkCore.DbContext` et qui contient 3 propriétés : 
- `DbSet<Room> Rooms`
- `DbSet<Customer> Customers`
- `DbSet<Reservation> Reservations`
1. Dans le projet `HotelLandon.Models`, ajouter une classe abstraite `EntityBase` qui contient une seule propriété `int Id`
1. Faire hériter les classes `Customer`, `Room` et `Reservation` de la nouvelle classe `EntityBase`
1. Installer l'outil `dotnet-ef` grâce à la commande `dotnet tool install` au niveau global (argument `--global`)

### Créer un projet pour tester EF Core
1. Créer un projet console (`HotelLandon.DemoEfCore`) qui va me permettre d'interagir avec la base de données : on doit pouvoir créer des clients.
1. Ajouter des chambres (avec une boucle pour initialiser la liste des chambres disponibles).

### Génériques (repository)
> Un paramètre générique est entouré de chevrons. Voir l'exemple en bas de cette section.

1. Créer un projet `HotelLandon.Repository`
1. Créer l'interface `IRepositoryBase`. Elle doit prendre un paramètre générique (_TEntity par exemple_).
1. Utiliser la classe `RepositoryBase<TEntity>` au lieu de `HotelLandonContext` pour ajouter des clients

```CSharp
/// <summary>
/// Définition d'une classe générique 
/// avec des exemples de contraintes 
/// </summary>
/// <remarks>
/// il peut ne pas y en avoir</remarks>
class Repository<TEntity>
// TEntity doit avoir un constructeur public sans paramètres
// where TEntity : new()

// TEntity doit être une classe (pas une interface par exemple)
// where TEntity : class

// TEntity doit hériter de EntityBase
    where TEntity : EntityBase
{
}

// utilisation
class Program
{
    static void Main()
    {
        // Room hérite de EntityBase, Repository
        var repository = new Repository<Room>();
    }
}
```

## Créer la solution
1. Utiliser la commande `dotnet new sln --name HotelLandon` pour créer une solution Visual Studio nommée "HotelLandon"
1. Pour chaque projet, l'ajouter à la solution à l'aide de la commande `dotnet sln add [PATH-RELATIF-DU-PROJET]` _(`dotnet sln add HotelLandon.Data`)_
1. Ouvrir la solution avec Visual Studio

## Ressources complémentaires
- [LinkedIn Learning](https://linkedin.com/learning) (cours vidéo avec présentations - payant, 20€/mois~)
- [Microsoft Learn](https://learn.microsoft.com) (Cours écrit avec TP - gratuit)
- [Documentation .NET](https://docs.microsoft.com/dotnet)
- [Documentation EFCore](https://docs.microsoft.com/ef/core)