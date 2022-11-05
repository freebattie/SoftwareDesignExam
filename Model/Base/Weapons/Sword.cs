
using Model.Interface;

namespace Model.Base.Weapons
{

    //TODO: refactor til abstract weapon?
    public class Sword : IWeapon
    {

        private string _name;
        private double _damage;
        public Sword() { }
        public Sword(int damage, string name)
        {
            _damage = damage;
            _name = name;
        }
        public double Damage { get { return _damage; } set { _damage = value; } }
        public string Name { get { return _name; } set { _name = value; } }

       
        public double GetDamage() {
           return _damage;
        }
    } 
}