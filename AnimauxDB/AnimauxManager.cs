namespace AnimauxDB;
using Microsoft.Data.SqlClient;

public class AnimauxManager
{
    public Animal CreateAnimal(int choix, string name)
    {
        switch (choix)
        {
            case 1:
                return new Chien(name);
            case 2:
                return new Dragon(name);
            default:
                throw new ArgumentException("Choix invalide");
        }
    }
    
    public void AddAnimal(Animal animal)
    {
        using SqlConnection connection = new SqlConnection("Server=localhost;Database=animaux;Trusted_Connection=True;TrustServerCertificate=True;");
        connection.Open();
        using SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Animaux (Name, typeId, rareteId) VALUES (@Name, @TypeId, @RareteId)";
        command.Parameters.AddWithValue("@Name", animal.Name);
        command.Parameters.AddWithValue("@TypeId", animal.TypeId);
        command.Parameters.AddWithValue("@RareteId", animal.RareteId);
        command.ExecuteNonQuery();
    }
}