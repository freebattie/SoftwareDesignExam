namespace Model.Base;

public class Weapon
{
    private int _damage;
    private string _description;

    public Weapon()
    {
    }

    public Weapon(int damage, string description)
    {
        _damage = damage;
        _description = description;
    }

    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }

    public string Description
    {
        get => _description;
        set => _description = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public override bool Equals(object? o)
    {
        Weapon? other = o as Weapon;
        return Damage == other?.Damage && Description == other?.Description;
    }
}