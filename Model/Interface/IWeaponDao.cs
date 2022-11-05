using Model.Base;

namespace Model.Interface;

public interface IWeaponDao
{
    public List<Weapon> GetAllWeapons();
    public void AddWeapon(Weapon weapon);
}