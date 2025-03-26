using System;
using AnimauxDB;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Quel est le type d'animal que vous voulez ajouter ?\n1. Chien\n2. Dragon\n3. Griffon");
        string animalInputType = Console.ReadLine();
        if (!int.TryParse(animalInputType, out int animalType))
        {
            Console.WriteLine("Veuillez entrer un nombre");
            return;
        }
        
        Console.WriteLine("Quel est le nom de l'animal ?");
        string animalName = Console.ReadLine();
        
        Console.WriteLine("Quelle est la rareté de l'animal ?");
        foreach (var value in Enum.GetValues(typeof(Rarete)))
        {
            Console.WriteLine($"{(int)value}. {value}");
        }

        string rareteInput = Console.ReadLine();
        if (!int.TryParse(rareteInput, out int rareteId) || !Enum.IsDefined(typeof(Rarete), rareteId))
        {
            Console.WriteLine("Rareté invalide");
            return;
        }

        
        
        AnimauxManager animauxManager = new AnimauxManager();
        Animal animal = animauxManager.CreateAnimal(animalType, animalName);
        animal.RareteId = rareteId;
        animauxManager.AddAnimal(animal);
    }
}