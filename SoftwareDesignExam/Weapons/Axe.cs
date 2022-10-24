using test.Interface;

namespace test.Weapons
{
    public class Axe : IWeapon
    {

        float _damage;
        private string _name;

        public Axe(float dmg, string name)
        {
            _damage = dmg;
            _name = name;
        }


        public string Name { get { return _name; } }

        float IWeapon.Damage { get { return _damage; } set { _damage = value; } }
    }
}