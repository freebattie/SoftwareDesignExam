
using Model.Base.Weapons;

namespace Model.Interface
{
    public abstract class Weapon
    {
        //TODO: not smart
        public double Damage { get; set; }
        public string Name { get; set; }

        public abstract double GetDamage();


        public override bool Equals(object obj) {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) {
                return false;
            }
            else {
                Weapon Weapon = (Weapon)obj;
                return (Name == Weapon.Name) && (Damage == Weapon.Damage);
            }
        }
        public override string? ToString() {
            return $"Name: {Name}\n" +
                    $"Damage: {Damage}";
        }
    }
}