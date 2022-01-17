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

Créer un fichier, remplacer un fichier avec un nouveau contenu :
```CSharp
using (StreamWriter writer = new StreamWriter("data.csv"))
{
    writer.WriteLine(customer.ToCsv());
}
```

Ajouter du texte dans un fichier existant :
```CSharp
using (StreamWriter writer = File.AppendText("data.csv"))
{
    writer.WriteLine(customer.ToCsv());
}
```

Lire du texte depuis un fichier :
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

> Vous pouvez exécuter l'application à l'aide de la commande `dotnet run` (= `dotnet restore`, `dotnet build`, exécution). 