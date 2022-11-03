﻿using Model.Abstract;
using Model.Interface;

namespace Model.Base.Weapons
{
    public class Axe : IWeapon
    {

        double _damage;
        private string _name;
        public Axe() {

        }
        public Axe(float dmg, string name)
        {
            _damage = dmg;
            _name = name;
        }
        public double Damage { get { return _damage; } set { _damage = value; } }
        public string Name { get { return _name; } set { _name = value; } }

        public void Attack() {
            throw new NotImplementedException();
        }

        public void GetAllTargets(List<Character> targets) {
            throw new NotImplementedException();
        }

        public void SetTarget(Character target) {
            throw new NotImplementedException();
        }

        public override string? ToString() {
            return  $"Name: {Name}\n" +
                    $"Damage: {Damage}";
        }
    }
}