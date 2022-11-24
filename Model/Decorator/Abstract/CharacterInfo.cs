using Model.Base.Player;
using Model.Base.Weapons.Abstract;
namespace Model.Decorator.Abstract
{

    /// <summary>
    /// abstrakte klassen for decorator pattern
    /// </summary>
    public abstract class CharacterInfo {

        #region private fileds
        private Weapon? _weapon;
        private double _crit = 5;
        private double _level = 1;
        private double _health;
        private const double GAINFACTOR = 0.75;
        private double _maxHealth;
        private string? _dsecription;
        #endregion

        #region Props
        protected string? Dsecription { get => _dsecription; set => _dsecription = value; }
        public string? Name { get; set; }
        protected double MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        protected double Level { get => _level; set => _level = value; }
        protected double Crit { get => CalculateNewLevelValue(_crit); set => _crit = value <= 100 ? value : 100; }
        protected double ArmorLevel { get; set; }
        protected Weapon? Weapon { get => _weapon; set => _weapon = value; }
        protected double Health {
            get { return _health; }
            set {
                if (value <= MaxHealth) {
                    _health = value;
                }
                else {
                    _health = MaxHealth;
                }
            }
        }
        #endregion

        #region Methods
/// <summary>
/// regner ut ny helse basert på en base helse å en gainfactor
/// for å justere vanskligheten så kan man justere end value denne metoden tar inn
/// </summary>
/// <param name="value"></param>
/// <returns></returns>
        protected double CalculateNewLevelValue(double value) {
            return Math.Round((Level * GAINFACTOR * value) + value, 0);
        }
        public override bool Equals(object? obj) {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) {
                return false;
            }
            else {
                CharacterInfo charecter = (CharacterInfo)obj;
                return (GetName() == charecter.GetName()) && (GetDescription() == charecter.GetDescription());
            }
        }
        #endregion

        #region abstract methods
        public abstract double CheckForCritDamage(double dmg);
        public abstract void SetWeapon(Weapon weapon);
        public abstract void Attack(CharacterInfo person);
        public abstract void RemoveHealth(double weaponDmg);
        public abstract void IncreaseHealth(double health);
        public abstract double GetHealth();
        public abstract void SetLevel(int level);
        public abstract double GetLevel();
        public abstract void AddCrit();
        public abstract int GetDamageInRange(int min, int max);
        public abstract string GetDescription();
        public abstract string GetName();
        public abstract void SetName(string name);
        public abstract void SetUser(User user);
        public abstract Weapon GetWeapon();
        public abstract double GetMaxHealth();
        public abstract int GetCrit();
        public abstract int GetDamageDone();
        public abstract int GetMaxDamage();
        #endregion

        #region ovewrites
        public override int GetHashCode() {
            return HashCode.Combine(GetName(), GetDescription());
        }
        #endregion
    }
}
