
using Model.Base.Weapons;
using Model.Decorator.Abstract;

namespace Model.Base
{
   
    public abstract class Weapon
    {

       public  Weapon() {
            Name = "";
            Description = "";
        }
      
        public double Damage { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public object Price { get; set; }

        public override bool Equals(object? obj) {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) {
                return false;
            }
            else {
                Weapon Weapon = (Weapon)obj;
                return  (Name == Weapon.Name)     &&
                        (Damage == Weapon.Damage) &&
                        (Description == Weapon.Description);
            }
        }
        public override string? ToString() {
            return $"Name: {Name}\n" +
                    $"Damage: {Damage}";
        }

        public abstract double GetDamage();
        public abstract void SetTarget(CharacterInfo target);

        public override int GetHashCode() {
            return HashCode.Combine(Name,Damage, Description);
        }
    }
}