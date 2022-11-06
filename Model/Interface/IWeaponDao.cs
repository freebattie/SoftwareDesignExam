using Model.Base;

namespace Model.Interface {
    public interface IWeaponDao {
        public List<DBWeapon> GetAllWeapons();
        public void AddWeapon(DBWeapon weapon);
    }
}