using Model.Decorator.Abstract;

namespace Model.Base.Weapons.Abstract
{
    /// <summary>
    /// abstract class for weapons, all weapons inherent from this class
    /// </summary>
    public abstract class Weapon
    {
        #region props
        public double Damage { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        #endregion

        #region constructor
        public Weapon()
        {
            Name = "";
            Description = "";
        }
        #endregion

        #region overrides
        public override bool Equals(object? obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Weapon Weapon = (Weapon)obj;
                return Name == Weapon.Name &&
                        Damage == Weapon.Damage &&
                        Description == Weapon.Description;
            }
        }
        public override string? ToString()
        {
            return $"Name: {Name}\n" +
                    $"Damage: {Damage}";
        }
        public override int GetHashCode() {
            return HashCode.Combine(Name, Damage, Description);
        }
        #endregion

        #region abstract metods
        /// <summary>
        /// Gets the weapons damage, each weapon has it own implementation of this
        /// </summary>
        /// <returns></returns>
        public abstract double GetDamage();
        /// <summary>
        /// sets the target for weapons special attack(like disarm)
        /// </summary>
        /// <param name="target"></param>
        public abstract void SetTarget(CharacterInfo target);
        #endregion

    }
}