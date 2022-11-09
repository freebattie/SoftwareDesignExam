namespace Model.Base;

public class DBWeapon
{
    private int _damage;
    private string _description;

    public DBWeapon()
    {
        _description = "";
    }

    public DBWeapon(int damage, string description)
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
        DBWeapon? other = o as DBWeapon;
        return Damage == other?.Damage && Description == other?.Description;
    }

    public override int GetHashCode() {
        throw new NotImplementedException();
    }
}