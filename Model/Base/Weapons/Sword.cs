using System.Reflection.Metadata.Ecma335;
using Model.Abstract;
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

        public List<Character> Targets { get; private set; }
        public Character Target { get; private set; }

        public void Attack() {
            if (Targets != null) {

            }
        }

        public void GetAllTargets(List<Character> targets) {
            Targets = targets;
        }

        public void SetTarget(Character target) {
            Target = target;
        }

        public void SetTarget(List<Character> targets) {
            throw new NotImplementedException();
        }

        public override string? ToString() {
            return $"Name: {Name}\n" +
                    $"Damage: {Damage}";
        }
    } 
}