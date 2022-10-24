using System.Reflection.Metadata.Ecma335;
using SoftwareDesignExam.Interface;

namespace SoftwareDesignExam.Weapons
{
    internal class Sword : IWeapon
    {

        private string _name;
        private float _damage;
        
        public Sword(int damage, string name)
        {
            _damage = damage;
            _name = name;
        }

        

        public string Name { get { return _name; } }

        float IWeapon.Damage { get { return _damage; } set { _damage = value; } }
    }
}