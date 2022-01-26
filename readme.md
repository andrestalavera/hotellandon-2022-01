# .NET
> Pour vérifier la liste :
> - des SDKS installés : `dotnet --list-sdks`
> - des runtimes installés : `dotnet --list-runtimes`

Possible d'installer .NET depuis le site https://dot.net.

## Syntaxe C#

### Légende pour le support de cours
| Symbole | Définition |
|-|-|
| `\|` | `x` ou `y`. |
| `[abc]` | Non obligatoire.

```csharp
/* Définition d'un namespace (espace de noms)
Permet d'organiser les classes.
On peut utiliser les "`.`" pour délimiter un namespace et hierarchiser le code.
Généralement, Societe.Produit.Project.DossierNiveau1.DossierNiveau2
Exemples : 
- IdeaStudio.HotelLandon.DemoConsole
- IdeaStudio.HotelLandon.DemoConsole.Exceptions <- où on mettra les exceptions
- IdeaStudio.HotelLandon.DemoConsole.Interfaces <- où on mettra les interfaces
Physiquement, dans le dosser qui contient du projet, il y aura les répértoires suivants : 
- C:\Repos\
    - IdeaStudio.HotelLandon.DemoConsole
        - Exceptions
        - Interfaces

Plus d'informations : https://docs.microsoft.com/dotnet/csharp/fundamentals/types/namespaces
*/
namespace Solution.Project 
{
    /* Définition d'une classe
    Portée/visibilité (voir section dédiée ci-dessous)
    Modificateur (voir section dédiée ci-dessous)
    Le mot clé `class`
    Nom de la classe (ClassName)
    Si héritage, ajouter ":" + le nom de la classe parente (on ne peut hériter que d'une seule classe, mais de plusieurs interfaces)
    Par convention, elle doit être écrite en PascalCase
    */
    [public|internal|protected|private] [abstract|static|sealed] class ClassName
    {
        /* Champ privé :
        - Portée (visibilité par les autres classes)
        - Peut être statique ou en lecture seule
        - Type (HttpClient)
        - nom du champ (camelCase)
        */
        private [static] [readonly] HttpClient httpClient;

        /* Propriété
        - Portée
        - Type
        - Nom de la propriété
        - Accesseur (leur portée peut être différente)
        - On peut directement affecter une valeur par défaut
        */
        [public|internal|protected|private] HttpClient HttpClient { get; [internal|protected|private] set; } = new HttpClient();

        /* Constructeur 
        C'est une méthode sans nom
        - Portée
        - Nom de la classe
        - Entre parenthèses, les éventuels paramètres
        - Si héritage de constructeur, le mot clé `base` avec les paramètres du contructeur parent
        */
        public ClassName() { }
        public ClassName(Foo foo) { }
        public ClassName(params Foo[] foos) { }
        public ClassName(Type type) : base (type) { }

        /* Méthode
        - Portée
        - Type de retour
        - Entre parenthèses, les éventuels paramètres
        - Si héritage d'une méthode parente (et qu'on souhaite l'utiliser), le mot clé `base`
        */
        public void DoSomething() { }
        public void DoSomething(Foo foo) { }
        public void DoSomething(params Foo[] foos) { }
    }
}
```

### Portée
Liste exhaustive : 
| Mot-clé | Description |
|-|-|
| `public` | Visible par toutes les classes, quelque soit l'assembly. |
| `internal` | Visible par toutes les classes du même assembly. <br>Valeur par défaut pour les classes. |
| `protected` | Visible par la classe et les classes qui hérite de celle-ci. |
| `private` | Visible uniquement par la classe. <br>Valeur par défaut pour les champs, propriétés et méthodes. |

### Modificateurs
| Mot-clé| Description |
|-|-|
| `abstract` | La classe ne peut pas être instanciée, elle peut comporter des champs/propriété ou méthodes abstraites. |
| `static` | La classe ne peut pas être instanciée, les méthodes publiques sont accessibles depuis l'objet (Exemple `System.Console` ou `System.IO.File`). |
| `sealed` | La classe ne peut plus être parente d'une autre classe. |


> Plus d'informations à propos du...
>
> - mot clé `abstract` https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/abstract
> - mot clé `sealed`   https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/sealed
> - mot clé `static`   https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/static

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
`private void DoSomething(Foo foo1, Foo foo2) { ... }`

| Index | Description |
|-|-|
| 0 | Portée |
| 1 | Type de retour (`int`\|`string`\|`Customer`\|...) ou le mot clé `void` pour signifier que l'on n'a pas de type de retour. |
| 2 | Nom de la méthode. Par convention, c'est du PascalCase |
| 3 | Paramètres de la méthode. Par convention, la case est camelCase. |

> Plus d'informations sur les méthodes : https://docs.microsoft.com/dotnet/csharp/methods

#### Méthode asynchrone & le mot clé `async`
`private Task DoSomethingAsync(Foo foo1, Foo foo2) { ... }`

- Même fonctionnement et but que la méthode classique.
- Mot clé `async` (entre la portée et le type de retour).
- Le type de retour qui change : il doit s'agir d'un objet de type `System.Threading.Tasks.Task<>` (type générique qui peut prendre un autre type).

| Type synchrone | Type asynchrone |
|-|-|
|`void`|`Task`|
|`int`|`Task<int>`|
|`string`|`Task<string>`|
|`double`|`Task<double>`|
|...|...|

> Attention à ne pas abuser de l'asynchronisme. Cela peut être contreproductif.

> Plus d'informations sur les tâches asynchrones : https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/async/

### Le mot clé `params`
- Permet d'avoir un nombre illimité de paramètres. 
- Le type doit être un tableau.
- Il doit être le dernier paramètre
```csharp
// signature dans la méthode
void DoSomething(params string[] array) { ... }

// utilisation
DoSomething("first", "second", "third", "fourth", "fifth", "sixth");
```

> Plus d'informations sur le mot clé `params` : https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/params

### Attributs
Permet de décorer une classe pour lui donner un _flag_ ou de nouveaux paramètres.

Déclaration :
```csharp
// déclaration d'un attribut qui peut décorer 
// une classe, une méthode, un assembly, un constructeur, un champ, une propriété, une interface, etc.
// On peut également utiliser [System.AttributeUsage(System.AttributeTargets.All)]
public class FooAttribute : System.Attribute
{
}

// déclaration d'un attribut qui peut décorer une classe (uniquement)
[System.AttributeUsage(System.AttributeTargets.Class)]
public class FooAttribute : System.Attribute
{
}

// déclaration d'un attribut qui peut décorer une méthode (uniquement)
[System.AttributeUsage(System.AttributeTargets.Method)]
public class FooAttribute : System.Attribute
{
}

// déclaration d'un attribut qui peut décorer une méthode (uniquement)
[System.AttributeUsage(System.AttributeTargets.Method)]
public class FooAttribute : System.Attribute
{
}
```
Utilisation :
```csharp

[FooAttribute] // <- on utilise le constructeur de l'attribut
public class Toto
{
}

[Foo] // <- on utilise le constructeur de l'attribut
public class Toto
{
}
```
> Plus d'informations à propos 
> - Des attributs : https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/attributes/
> - L'énumérateur (`enum`) `System.AttributeTargers` : https://docs.microsoft.com/dotnet/api/system.attributetargets

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
// utilisation : 
// TEntity = Customer
Customer customer = new();
IsPositive(customer);
```

### Méthodes d'extension
On peut ajouter des méthodes à des classes, même scellées. Ce sont des _méthodes d'extention_. Les méthodes d'extention doivent être écrites dans une classe statique.
```csharp
public IsPositive<TEntity>(this TEntity entity)
    where TEntity : EntityBase
{
    ...
}

// utilisation :
// TEntity = Customer
Customer customer = new();
bool isPositive = customer.IsPositive();
```

## Créer la solution
1. Utiliser la commande `dotnet new sln --name HotelLandon` pour créer une solution Visual Studio nommée "HotelLandon"
1. Pour chaque projet, l'ajouter à la solution à l'aide de la commande `dotnet sln add [PATH-RELATIF-DU-PROJET]` _(`dotnet sln add HotelLandon.Data`)_.
1. Ouvrir la solution avec Visual Studio : tous les projets y sont référencés !

# Git
- Gratuit et Open Source
- Peut être utilisé en local ou sur un serveur distant



Il existe plusieurs _logiciels de gestion de versions décentralisé_ en ligne permettant d'avoir un serveur Git distant : 
- Github
- GitLab
- Azure DevOps
- Bitbucket
- ...

Il existe des clients lourds pour Windows, macOS et Linux dont : 
- GitHub Desktop
- SourceTree
- ...

Les IDE intègrent généralement git.

Pour installer l'outil de ligne de commandes : https://git-scm.com.

> Visual Studio et Visual Studio Code intègrent Git.


## Travailler avec Git
Etapes pour publier son code dans un repository Git :

### Workflow complet
![Daniel Kinzler, CC BY 3.0 <https://creativecommons.org/licenses/by/3.0>, via Wikimedia Commons](https://upload.wikimedia.org/wikipedia/commons/d/d8/Git_operations.svg "Daniel Kinzler, CC BY 3.0 <https://creativecommons.org/licenses/by/3.0>, via Wikimedia Commons")(https://commons.wikimedia.org/wiki/File:Git_operations.svg)

### Initialiser avec les commandes Git
Faire une copie locale du repository distant :

|Etape|Commande|Description|
|-|-|-|
|1|_(aucune)_|Choisir un dossier local et y ouvrir une instance d'un terminal. _Par exemple dans le répertoire "`C:\Repos\HotelLandon-2022-01`"._|
|2|`git init`|Git créé un dossier caché nommé "`.git`" contenant toutes les informations nécessaires pour gérer l'historique et les différentes versions.|
|3|(aucune)|Ajouter des fichiers (par exemple `readme.md`, `.gitignore`, votre code, ...). <br>_Le fichier "`readme.md`" contient de la documentation qui est affichée dans une page "index" dans les logiciels en ligne_.|
|4|`git add fichier1 fichier2` ... <br>ou<br>`git add -A`<br>_(Pour ajouter tous les fichiers)_|Ajouter dans le prochain commit le(s) fichier(s).<br>L'argument `-A` (ou `--all`) ajoute au commit tous les fichiers ajoutés, modifiés ou supprimés.|
|4|`git commit -m "Description de vos modifications"`|Prépare les fichiers ajoutés pour leur attribuer un nom de version. <br>On peut réitérer l'opération plusieurs fois. <br>_Par exemple : <br>`git commit -m "Ajouter readme.md"`<br> `git commit -m "Ajouter .gitignore de Visual Studio"`<br>`git commit -m "Création du projet"`_|
|5|`git branch -M main`|Créé la branche par défaut "`main`".<br>_Il est courant de trouver "`master`" comme nom de branche par défaut._|
|6|`git remote add origin git@serveur.com/a/b.git`|Ajoute l'adresse du repository (serveur) distant dans les paramètres du repository local. _Où "`git@serveur.com/a/b.git`" est l'adresse internet du repository.<br>Par exemple "`git@github.com/andrestalavera/hotellandon-2022-01.git`"._|
|6|`git push -u origin main`|Git envoie tous les commits dans le serveur distant (origin). <br>Le paramètre `-u` (ou `--set-upstream`) ajoute une référence entre dans la branche locale "`main`" et la branche "`main`" présente dans le serveur d'origine (paramètre "`origin`").|

- Tutoriel pour cloner un repository avec Visual Studio Code : https://code.visualstudio.com/docs/editor/versioncontrol#_cloning-a-repository (uniquement en anglais).
- Tutoriel pour cloner un repository avec Visual Studio 2019/2022 : https://docs.microsoft.com/visualstudio/version-control/git-clone-repository

## Travailler au quotidien avec Git
>TODO

___
> La commande `git status` permet d'afficher le statut de chaque fichier :<br>- prêt à être ajouté au prochain commit<br>- qui n'est pas inclu dans le prochain commit<br>- non présent dans le repository distant (origin)
# Hotel Landon
Application légère de réservation d'hôtel
___
## Modèles 
1. Ouvrir un terminal dans le dossier de votre choix, par exemple `C:\Repos`. On l'appelera le _dossier racine_.
1. Dans le terminal, à la racine, créer un projet _librairie de classes_ à l'aide de .NET CLI grâce à la commande `dotnet new classlib --name HotelLandon.Models`
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

### Ecrire du texte dans un fichier
- Possible d'utiliser la classe `System.IO.StreamWriter`.
- La classe a plusieurs méthodes permettant d'écrire du texte dans la ressource choisie. Dans les exemples ci-dessous, la ressource est le fichier "`data.csv`".
- Ne pas oublier que la classe `System.IO.StreamWriter` hérite de l'interface `System.IDisposable`. Les ressources, en l'occurrence le fichier "`data.csv`", reste ouvert et est bloqué par le processus. Aucune autre modification des ressources ne sera possible. 2 possibilités : utiliser la méthode `System.IO.StreamWriter.Dispose()` ou utiliser l'instruction `using` (recommandé).
- Une nouvelle instance de la classe `System.IO.StreamWriter` remplacera le fichier. L'ancien contenu sera remplacé.
- Pour ajouter du contenu dans un fichier existant, on peut utiliser la méthode statique `System.IO.File.AppendText` qui va créer une instance de `System.IO.StreamWriter`.
```csharp
using (StreamWriter writer = new StreamWriter("data.csv"))
{
    // Ajoute une ligne
    writer.WriteLine(customer.ToCsv());

    // Ajoute à la fin de la ligne (sans saut de ligne)
    writer.Write(customer.ToCsv());
}
```
```csharp
using (StreamWriter writer = File.AppendText("data.csv"))
{
    // Ajoute une ligne
    writer.WriteLine(customer.ToCsv());

    // Ajoute à la fin de la ligne (sans saut de ligne)
    writer.Write(customer.ToCsv());
}
```
> Plus d'informations 
> 
> - À propos la classe `System.IO.StreamWriter` : https://docs.microsoft.com/dotnet/api/system.io.streamwriter
>
> - À propos de la méthode statique `System.IO.File.AppendText(string)` : https://docs.microsoft.com/dotnet/api/system.io.file.appendtext
>
> - À propos de l'instruction `using` : https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/using-statement

### Lire du texte depuis un fichier :
- Possible d'utiliser la classe `System.IO.StreamReader`
- La classe `System.IO.StreamReader` a plusieurs méthodes permettant de lire du texte dans la ressources choisie. Dans l'exemple ci-dessous il s'agit du fichier "`data.csv`".
- Ne pas oublier que la classe System.IO.StreamWriter hérite de l'interface System.IDisposable. 
- Il est possible de boucler (grâce ) et de lire ligne par ligne.
```csharp
using (StreamReader reader = new StreamReader("data.csv"))
{
    // Crée un entier pour indiquer l'index du numéro de ligne
    int lineNumber = 0;
    // Tant que ce n'est pas la fin du contenu du fichier
    while (!reader.EndOfStream) // Alternative: while ((line = reader.ReadLine()) != null)
    {
        // On récupère la ligne
        string line = reader.ReadLine();
        // Si elle est nulle ou est vide (contient au moins un espace)
        if (string.IsNullOrWhiteSpace(line))
        {
            // Affiche un message dans la console indiquant le numéro de ligne vide
            Console.WriteLine($"La ligne {lineNumber} est vide.");

            // permet d'ignorer la ligne du fichier
            // et de passer à la suivante
            // la prochaine instruction qui va s'exécuter sera :
            // string line = reader.ReadLine();
            continue;
        }
        Console.WriteLine(line);
        // Incrémente le numéro de ligne
        lineNumber++;
    }
}
```

Contrairement au mot-clé `break`, `continue` ne va pas casser le cycle de la boucle `while`.

> Plus d'informations à propos... 
> - Des instructions de saut : https://docs.microsoft.com/dotnet/csharp/language-reference/statements/jump-statements
>
> - Le mot-clé `while` : https://docs.microsoft.com/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement

### Sérialiser en CSV :
Un exemple parmi tant d'autres possibilités, le faire soi-même avec une méthode :
```csharp
public string ToCsv()
{
    // avec string interpolation
    return $"{LastName};{FirstName};{BirthDate}";
}
```

Avec de la réflexion (pouvant être une méthode d'extension générique) :
```csharp
public string ToCsv<T>(IEnumerable<T> items) // version méthode d'extension : public static string ToCsv<T>(this IEnumerable<T> items)
    where T : class
{
    // Créé 2 variables de type `string`, nommées `output` et `delimiter`
    string output = string.Empty, delimiter = ';';
    // Récupère la liste des propriétés de la classe générique T
    System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties()
    // Filtre les type que l'on souhaite parser au format CSV.
    // La méthode `Where(...)` est issue de `System.Linq`
    .Where(n =>
        n.PropertyType == typeof(string)
        || n.PropertyType == typeof(bool)
        || n.PropertyType == typeof(char)
        || n.PropertyType == typeof(byte)
        || n.PropertyType == typeof(decimal)
        || n.PropertyType == typeof(int)
        || n.PropertyType == typeof(DateTime)
        || n.PropertyType == typeof(DateTime?));
    
    // Création d'un `System.IO.StringWriter` en mémoire (on n'ouvre pas de fichier)
    using (var sw = new StringWriter())
    {
        // Sélectionne les noms des colonnes
        var header = properties
            .Select(n => n.Name)
            .Aggregate((a, b) => a + delimiter + b);

        // On écrit la ligne en mémoire
        sw.WriteLine(header);
        
        // Pour chaque élément d'une liste
        foreach (var item in items)
        {
            // On récupère les valeurs
            var row = properties
                .Select(n => n.GetValue(item, null))
                .Select(n => n == null ? “null” : n.ToString())
                .Aggregate((a, b) => a + delimiter + b);

            // On écrit la ligne en mémoire
            sw.WriteLine(row);
        }
        
        // On récupère le contenu écrit en mémoire
        output = sw.ToString();
    }

    // On renvoie le contenu CSV
    return output;
}

// Admettons que la liste aie plusieurs objets de type `Customer`
IEnumerable<Customer> customers; 

// appel (méthode classique)
string csv = ToCsv(customer);

// appel (méthode d'extension)
string csv = customers.ToCsv();
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
> Il existe des packages NuGet permettant de mapper automatiquement.

### Sérialiser en JSON
> Pour installer un package NuGet avec dotnet-cli : `dotnet add package {NOM_PACKAGE}` *(En l'occurrence pour le package `Newtonsoft.Json` : `dotnet add package Newtonsoft.Json`)*.
>
> Par défaut, la commande installe la dernière version disponible dans www.nuget.org. Pour installer une version particulière, vous pouvez ajouter l'argument `--version X.X.X.X` (où "`X.X.X.X`" est la version spécifiée)
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
## Créer la base de données
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
1. Ajouter les propriétés de navigation représentant les clés étrangères :
- Dans la classe `Customer`, `HashSet<Reservation> Reservations`
- Dans la classe `Room`, `HashSet<Reservation> Reservations`
- Dans la classe `Reservation`, `int CustomerId` et `int RoomId`
1. Créer une migration grâce à la commande `dotnet ef migrations add NOM_MIGRATION` (par exemple `Initial`).
<br>La migration va créer un delta entre la base de données et le modèle défini dans la classe `HotelLandonContext`. _Si la base de données n'existe pas, elle sera créée par la première migration._
1. Appliquer les migrations dans la base de données (si la base de données n'existe pas, elle sera créée) grâce à la commande `dotnet ef database update`.

[Ajouter un shéma]

### Créer un projet pour tester EF Core
1. A la racine, créer un projet console (`HotelLandon.DemoEfCore`) qui va me permettre d'interagir avec la base de données : on doit pouvoir créer des clients.
1. Ajouter des chambres (avec une boucle pour initialiser la liste des chambres disponibles).

## Web API
1. A la racine, créer un projet Web API à l'aide de la commande `dotnet new webapi --name HotelLandon.Api`.
1. Exécuter et explorer.
1. Ajouter les références `HotelLandon.Data`, `HotelLandon.Models`, `HotelLandon.Repository` dans le projet `HotelLandon.Api`.
1. Créer un contrôleur avec les contraintes suivantes :
- Classe abstraite (mot-clé `abstract`).
- Hérite de `Microsoft.AspNetCore.Mvc.ControllerBase`.
- Prends 2 paramètres génériques : `TRepository` qui doit hériter de `IRepositoryBase<TEntity>` et `TEntity` qui doit hériter de `EntityBase`.
- Décorée par les attributs `Microsoft.AspNetCore.Mvc.ApiController` et `Microsoft.AspNetCore.Mvc.Route` (ce dernier doit prendre en paramètre un template, par exemple `[controller]` pour que les routes correspondent au nom du contrôleur).
- Ayant les méthodes `GetAll`, `GetById(int)`, `Create`, `Update` et `Delete`. <br>Chacune devra retourner un objet de type `ActionResult<T>`, _`T` étant soit un énumérable de `TEntity`, soit un `TEntity`, soit un `bool`_. <br>Chaque méthode devra être décorée d'un attribut associé à son verbe HTTP (get, post, put, delete).

```csharp
[Route("[controller]")]
[ApiController]
public abstract class GenericController<TRepository, TEntity> : ControllerBase
    where TRepository : IRepositoryBase<TEntity>
    where TEntity : EntityBase
{
}
```

## MVC & Razor
1. A la racine, créer un projet web mvc nommé `HotelLandon.MvcRazor`.
1. Exécuter et explorer.
1. Ajouter les références `HotelLandon.Data`, `HotelLandon.Models`, `HotelLandon.Repository` dans le projet `HotelLandon.MvcRazor`.
1. Créer un contrôleur avec les contraintes suivates :
- Classe abstraite 
- Hérite de `Microsoft.AspNetcore.Mvc.Controller` (qui gère les vues en plus de sa classe mère).
- Prends 2 paramètres génériques : `TRepository` qui doit hériter de `IRepositoryBase<TEntity>` et `TEntity` qui doit hériter de `EntityBase`.
- Pas de décoration
- Ayant les méthodes `Index()`, `Details(int)`, `Create(int)`, `Create(int, TEntity)`, `Edit(int)`, `Edit(int,TEntity)`, `Delete(int)`, `DeleteConfirmed` qui devront retourner un `IActionResult` (ou sa version asynchrone, si nécessaire). 
<br>Les méthodes `Edit(int,TEntity)` et `Create(int,TEntity)` devront être marquées comme étant virtuelles. Les autres méthodes peuvent l'être également. 
1. Créer une classe concrète pour les clients, `CustomersController`, qui devra hériter de votre classe abstraite `GenericController<IRepositoryBase<Customer>, Customer>`.
1. Surcharger les méthodes `Edit(int,Customer)` et `Create(int,Customer)` afin d'ajouter au paramètre de type `Customer` l'attribut `[Bind("Id","FirstName,LastName,BirthDate")]`
1. Dans le dossire `Views` du projet ; Créer un dossier ayant comme nom, le nom de vôtre contrôleur sans son suffixe. 
<br>_Exemple : Pour le contrôleur `CustomerController`, le dossier devra porter le nom "`Customers`"._
1. Pour chaque méthode publique retourant un objet de type `IActionResult`, créer une vue razor (extension "`.cshtml`") du nom de la méthode. Ecrire un code HTML simple permettant simplement de réaliser ce pourquoi la page a été définie.
<br>_Exemples : 
<br>Pour la méthode `Index()`, créer un fichier nommé "`Index.cshtml`". Il faudra afficher la liste de tous les clients.
<br>Pour la méthode `Create()`, créer un fichier nommé "`Create.cshtml`". Il faudra afficher un formulaire permettant de créer un client._

## Razor Pages

# Design Patterns

## Singleton
> https://fr.wikipedia.org/wiki/Singleton_(patron_de_conception)#C#

## Inversion of Control (IoC)

Il existe plusieurs implémentations possibles :
- [**Dependency Injection** (Injection de dépendences)](https://docs.microsoft.com/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0#overview-of-dependency-injection)
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

## Ressources complémentaires
- [LinkedIn Learning](https://linkedin.com/learning) (cours vidéo avec présentations - payant, 20€/mois~)
- [Microsoft Learn](https://learn.microsoft.com) (cours écrit avec TP - gratuit)
- [Documentation .NET](https://docs.microsoft.com/dotnet)
- [Documentation EFCore](https://docs.microsoft.com/ef/core)