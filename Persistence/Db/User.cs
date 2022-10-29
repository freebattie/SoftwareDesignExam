namespace Persistence;

public class User
{
    private string name;
    private int level;
    private int topscore;

    public User()
    {
    }

    public User(string name, int level, int topscore)
    {
        this.name = name;
        this.level = level;
        this.topscore = topscore;
    }

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Level
    {
        get => level;
        set => level = value;
    }

    public int Topscore
    {
        get => topscore;
        set => topscore = value;
    }
}