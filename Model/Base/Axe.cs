using Model.Interface;

namespace Model.Base
{
    public class Axe : IWeapon
    {

        double _damage;
        private string _name;

        public Axe(float dmg, string name)
        {
            _damage = dmg;
            _name = name;
        }


        public string Name { get { return _name; } }



        double IWeapon.Damage { get { return _damage; } set { _damage = value; } }
    }
}