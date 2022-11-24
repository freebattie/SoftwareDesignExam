using Model.Decorator.Abstract;
using Model.Base.Weapons.Abstract;
namespace Model.Base.Weapons
{
    public class Axe : Weapon
    {
        #region private fileds
        private int _counter = 0;
        List<CharacterInfo> _targets;
        #endregion

        #region constructors
        public Axe() : base() {
            
            Description = "Will do a spinning attack on the 3 attack. Hitting all enemies you have hit before with 100 dmg * target level";
     
            _targets = new();
        }
        #endregion

        #region overrides methods
        public override double GetDamage() {
            if (_counter == 3) {
                foreach (var target in _targets) {
                    target.RemoveHealth(100 * target.GetLevel());
                   
                }
                _targets.Clear();
                _counter = 0;
            }
            else {
                _counter++;
            }
        
            return Damage;
        }

        public override void SetTarget(CharacterInfo target) {
            
            _targets.Add(target);
        }
        #endregion
    }
}