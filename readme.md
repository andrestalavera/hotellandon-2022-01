# .NET
> Pour vérifier la version des SDKS : `dotnet --list-sdks`
> Pour vérifier la version des runtimes : `dotnet --list-runtimes`

## Syntaxe C#

### Légende
| Symbole | Définition |
|-|-|
| `\|` | `x` ou `y`. |
| `[abc]` | Non obligatoire.

```csharp
/* Définition d'une classe
Portée/visibilité (voir section dédiée ci-dessous)
Modificateur (voir section dédiée ci-dessous)
Le mot clé `class`
Nom de la classe (ClassName)
Si héritage, ajouter ":" + le nom de la classe parente (on ne peut hériter que d'une seule classe, mais de plusieurs interfaces)
Par convention, elle doit être écrite en PascalCase
*/
public|internal|protected|private [abstract|static|sealed] class ClassName
{
    /* Champ privé :
    Portée
    Type (HttpClient)
    nom du champ (httpclient)
    */
    private HttpClient httpClient;

    /* Propriété
    - Portée (visibilité)
    - Type
    - Nom de la propriété
    - Accesseur (leur portée peut être différente)
    */
    public HttpClient HttpClient { get; public|internal|protected|private set; } = new HttpClient();

    /* Constructeur 
    - Paramètres entre parenthèses
    - Si héritage de constructeur, le mot clé `base` avec les paramètres du contructeur parent
    */
    public ClassName([params]TypeParametre nomParametre)
        [base(/*Paramètres du contructeur parent*/)]
    {

    }

    public void DoSomething()
    {

    }
}
```

### Portée

| Portée | Description |
|-|-|
| `public` | Visible par toutes les classes, quelque soit l'assembly. |
| `internal` | Visible par toutes les classes du même assembly. |
| `protected` | Visible par la classe et les classes qui hérite de celle-ci. |
| `private` | Visible uniquement par la classe. |

### Modificateur
| | Description |
|-|-|
| `abstract` | La classe ne peut pas être instanciée, elle peut comporter des champs/propriété ou méthodes abstraites. |
| `static` | La classe ne peut pas être instanciée, les méthodes publiques sont accessibles depuis l'objet (Exemple `System.Console` ou `System.IO.File`). |
| `sealed` | La classe ne peut plus être parente d'une autre classe. |

### Propriété
`public HttpClient HttpClient { get; set; } [= new()]`

| Index | Description |
|-|-|
| 0 | Portée | 
| 1 | Type de la proriété |
| 2 | Nom de la propriété |
| 3 | Accesseurs, la portée peut être modifiée pour l'un ou l'autre (par exemple ``public HttpClient HttpClient { get; private set; }``) |
| 4 | Symbole `=` pour affecter une valeur par défaut |
| 5 | Valeur |

### Champ
`private [readonly] HttpClient _httpClient [= new()];`

| Index | Description |
|-|-|
| 0 | Portée |
| 1 | Qualificatif `readonly`, on ne pourra affecter la valeur que lors de la construction d'une instance. |
| 2 | Type du champs |
| 3 | Nom du champs |
| 4 | Symbole `=` pour affecter une valeur par défaut |
| 5 | Valeur |

### Méthode
`private void DoSomething(Type type, Type type) { ... }`

| Index | Description |
|-|-|
| 0 | Portée |
| 1 | Type de retour (`int`\|`string`\|`Customer`\|...) ou le mot clé `void` pour signifier que l'on n'a pas de type de retour. |
| 2 | Nom de la méthode. Par convention, c'est du PascalCase |
| 3 | Paramètres de la méthode. Par convention, la case est camelCase. |

Le mot clé `params` permet d'avoir un nombre illimité de paramètres. Le type doit être un tableau.
```csharp
void DoSomething(params string[] array)
{

}
```
___
## Modèles 
1. Ouvrir un terminal dans le dossier `C:\Repos`
1. Créer un projet `librairie de classes` à l'aide de .NET CLI grâce à la commande `dotnet new classlib --name HotelLandon.Models`
1. Créer 3 classes : `Customer`, `Room` et `Reservation`
- `Customer` contient les propriétés suivantes : `FirstName`, `LastName`, `Birthdate`
- `Room` contient `Number`, `Floor`
- `Reservation` : `Customer`, `Room`, `Start`, `End`

___
## Programme console
1. Créer un projet console avec la commande `dotnet new console --name HotelLandon.DemoConsole`
1. Référencer le projet `HotelLandon.Models` dans le nouveau projet grâce à la commande `dotnet add reference HotelLandon.Models`
1. Ecrire un programme console capable d'instancier un `Customer`
1. Sérialiser et désérialiser en CSV grâce aux classes `System.IO.StreamWriter` et `System.IO.StreamReader`

### Créer un fichier, remplacer un fichier avec un nouveau contenu :
```csharp
using (StreamWriter writer = new StreamWriter("data.csv"))
{
    writer.WriteLine(customer.ToCsv());
}
```

### Ajouter du texte dans un fichier existant :
```csharp
using (StreamWriter writer = File.AppendText("data.csv"))
{
    writer.WriteLine(customer.ToCsv());
}
```

### Lire du texte depuis un fichier :
```csharp
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
```csharp
public string ToCsv()
{
    // avec string interpolation
    return $"{LastName};{FirstName};{BirthDate}";
}
```

### Désérialiser depuis du CSV : 
```csharp
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
```csharp
using Newtonsoft.Json;
// ...
public string ToJson(Customer customer)
{
    return JsonConvert.SerializeObject(customer);
}
```

### Désérialiser en JSON 
```csharp
using Newtonsoft.Json;
public Customer ToCustomer(string json)
{
    return JsonConvert.DeserializeObject<Customer>(json);
}
```

> Vous pouvez exécuter l'application à l'aide de la commande `dotnet run` (= `dotnet restore`, `dotnet build`, exécution). 

___
## Données
> Installer des outils pour .NET : `dotnet tool install [NAME]`

1. A la racine, créer un projet _librairie de classes_ `HotelLandon.Data`
1. Installer les packages `Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.SqlServer` et `Microsoft.EntityFrameworkCore.Design`
1. Créer la classe `HotelLandonContext` qui hérite de `Microsoft.EntityFrameworkCore.DbContext` et qui contient 3 propriétés : 
- `DbSet<Room> Rooms`
- `DbSet<Customer> Customers`
- `DbSet<Reservation> Reservations`
1. Dans le projet `HotelLandon.Models`, ajouter une classe abstraite `EntityBase` qui contient une seule propriété `int Id`.
1. Faire hériter les classes `Customer`, `Room` et `Reservation` de la nouvelle classe `EntityBase`.
1. Installer l'outil `dotnet-ef` grâce à la commande `dotnet tool install` au niveau global (argument `--global`).

### Créer un projet pour tester EF Core
1. A la racine, créer un projet console (`HotelLandon.DemoEfCore`) qui va me permettre d'interagir avec la base de données : on doit pouvoir créer des clients.
1. Ajouter des chambres (avec une boucle pour initialiser la liste des chambres disponibles).

## Web API
1. A la racine, créer un projet Web API à l'aide de la commande `dotnet new webapi --name HotelLandon.Api`
1. Exécuter et explorer
1. Ajouter les références `HotelLandon.Data`, `HotelLandon.Models`, `HotelLandon.Repository` dans le projet `HotelLandon.Api`
1. Créer un contrôleur avec les contraintes suivantes :
- Classe abstraite (mot-clé `abstract`).
- Hérite de `Microsoft.AspNetCore.Mvc.ControllerBase`.
- Prends 2 paramètres génériques : Repository qui doit hériter de `IRepositoryBase<TModel>` et le Modèle qui doit hériter de `TEntity`.
- Décorée par les attributs `Microsoft.AspNetCore.Mvc.ApiController` et `Microsoft.AspNetCore.Mvc.Route` (ce dernier doit prendre en paramètre un template, par exemple `[controller]` pour que les routes correspondent au nom du contrôleur).

```csharp
[Route("[controller]")]
[ApiController]
public abstract class GenericController<TRepository, TEntity> : ControllerBase
    where TRepository : IRepositoryBase<TEntity>
    where TEntity : EntityBase
{
}
```
___
## Design Patterns

### Inversion of Control (IoC)

Il existe plusieurs implémentations possibles :
- [**Dependency Injection** (Injection de dépendences)](https://docs.microsoft.com/fr-fr/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0#overview-of-dependency-injection)
- Service Locator
- Factory
...

Il permet d'ajouter des services (dépendence) dans un dictionnaire (en mémoire).

On peut les utiliser en ajoutant des paramètres soit dans le contructeur (le plus commun), soit à travers une méthode. On l'injecte.

Exemple :
```csharp
// Startup.cs :
Configure(IServiceCollection services)
{
    // méthode d'extension fournie par un package tiers
    services.AddWeatherService();
}

// Autre classe (contrôleur par exemple) :
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        // on affecte le champs
        _weatherService = weatherService;
    }

    public Weather Get(id)
    {
        // on consomme le service
        return _weatherService.Get(id);
    }
}
```
> Ici, WeatherController dépends de IWeatherService.

![Dependency Injection](/images/di.png)
___
## Autres

### Exceptions
Cela permet de gérer un comportement inattendu. Il peut être personnalisable. Les exceptions héritent de la classe `Exception` et, par convention, on suffixe avec `Exception`.

> Il en existe quelques unes dans l'assembly `System`

```csharp
DoSomething();
try
{
    DoSomethingElse();
}
catch(FormatException ex)
{
    Console.WriteLine("Format incorrect.");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    FinishAndExecuteAnyway();
}
```

Une exception faite maison :
```csharp
public class NoNumberException : Exception
{
}
```

### Génériques (repository)
> Un paramètre générique est entouré de chevrons. Voir l'exemple en bas de cette section.

1. Créer un projet `HotelLandon.Repository`.
1. Créer l'interface `IRepositoryBase`. Elle doit prendre un paramètre générique (_TEntity par exemple_).
1. Utiliser la classe `RepositoryBase<TEntity>` au lieu de `HotelLandonContext` pour ajouter des clients.
1. Ajouter des chambres à l'aide d'une boucle.

#### Exemple de code d'une classe générique
```csharp
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

Les génériques peuvent s'utiliser avec des méthodes :
```csharp
bool IsPositive<TEntity>(TEntity entity)
    where TEntity : EntityBase
{
    if (entity.Id >= 0)
    {
        return true;
    }
    else return false;
}
```

### Méthodes d'extension
On peut ajouter des méthodes à des classes, même scellées.
```csharp
public IsPositive<TEntity>(this TEntity entity)
    where TEntity : EntityBase
{
    ...
}

// utilisation :
Customer customer = new();
bool isPositive = customer.IsPositive();
```

### Créer la solution
1. Utiliser la commande `dotnet new sln --name HotelLandon` pour créer une solution Visual Studio nommée "HotelLandon"
1. Pour chaque projet, l'ajouter à la solution à l'aide de la commande `dotnet sln add [PATH-RELATIF-DU-PROJET]` _(`dotnet sln add HotelLandon.Data`)_.
1. Ouvrir la solution avec Visual Studio : tous les projets y sont référencés !

### Ressources complémentaires
- [LinkedIn Learning](https://linkedin.com/learning) (cours vidéo avec présentations - payant, 20€/mois~)
- [Microsoft Learn](https://learn.microsoft.com) (cours écrit avec TP - gratuit)
- [Documentation .NET](https://docs.microsoft.com/dotnet)
- [Documentation EFCore](https://docs.microsoft.com/ef/core)
