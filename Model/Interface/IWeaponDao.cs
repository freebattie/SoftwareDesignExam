namespace Model.Interface;

public interface IWeaponDao
{
    public List<IWeapon> GetAllWeapons();
    public void AddWeapon(string classname, string description, int damage);
}