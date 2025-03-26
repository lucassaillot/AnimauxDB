namespace AnimauxDB;

public enum Rarete
{
    Commun = 1,
    Rare = 2,
    Legendaire = 3
}

public abstract class Animal
{
    public abstract string Name { get; set; }
    public abstract int TypeId { get; }
    
    public abstract int RareteId { get; set; }
}


public class Chien : Animal
{
    public override string Name { get; set; }
    public override int TypeId => 1;
    
    public override int RareteId { get; set; }

    public Chien(string name) => Name = name;
}


public class Dragon : Animal
{
    public override string Name { get; set; }
    public override int TypeId => 2;
    
    public override int RareteId { get; set; }
    public Dragon(string name)
    {
        Name = name;
    }
}