using Model.Decorator.Abstract;
using Model.Base.Weapons.Abstract;
namespace Model.Base.Weapons
{
    public class Axe : Weapon
    {
      
        private int counter = 0;
        List<CharacterInfo> _targets;


        public Axe() : base() {
            
            Description = "Will do a spinning attack on the 3 attack. Hitting all enemies you have hit before with 100 dmg * target level";
     
            _targets = new();
        }

        public override double GetDamage() {
            if (counter == 3) {
                foreach (var target in _targets) {
                    target.RemoveHealth(100 * target.GetLevel());
                   
                }
                _targets.Clear();
                counter = 0;
            }
            else {
                counter++;
            }
        
            return Damage;
        }

        public override void SetTarget(CharacterInfo target) {
            
            _targets.Add(target);
        }
    }
}