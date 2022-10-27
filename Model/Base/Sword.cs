using System.Reflection.Metadata.Ecma335;
using Model.Interface;

namespace Model.Base
{
    public class Sword : IWeapon
    {

        private string _name;
        private double _damage;

        public Sword(int damage, string name)
        {
            _damage = damage;
            _name = name;
        }



        public string Name { get { return _name; } }

        public double Damage { get { return _damage; } set { _damage = value; } }


    }
}