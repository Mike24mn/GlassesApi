using GlassesTypes.Models;

namespace GlassesTypes.GlassesSelection;

public static class GlassesSelection
{
    static List<Glasses> Glasses { get; } = new List<Glasses>();
    static int nextId = 2;

    static GlassesSelection()
    {
            Glasses.Add(new Glasses { Id = 1, Name = "Rayban", Color = "Brown", Shape = "Square" });
    }


public static List<Glasses> GetAll() => Glasses;

public static Glasses? Get(int id) => Glasses.FirstOrDefault(g => g.Id == id);

public static void Add(Glasses glasses)
{
    glasses.Id = nextId++;
    Glasses.Add(glasses);
}

   public static void Delete(int id)
    {
        var glasses = Get(id);
        if(glasses is null)
            return;

        Glasses.Remove(glasses);
    }

    public static void Update(Glasses glasses)
    {
        var index = Glasses.FindIndex(g => g.Id == glasses.Id);
        if(index == -1)
            return;

        Glasses[index] = glasses;
    }
}