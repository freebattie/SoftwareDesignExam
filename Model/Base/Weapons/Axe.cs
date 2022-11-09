
using Model.Decorator.Abstract;
using Model.Decorator.Original;
using Model.Interface;
using System.Collections.Specialized;

namespace Model.Base.Weapons
{
    public class Axe : Weapon
    {
      
        
        private int counter = 0;
        List<CharacterInfo> _targets;
        public Axe() : base() {
            
            Description = "Will do a spinning attack on the 3 attack. Hitting all enemies you have hit before with 100 dmg";
            _targets = new();
        }
        public override double GetDamage() {
            if (counter == 3) {
                foreach (var target in _targets) {
                    target.RemoveHealth(100);
                   
                }
                _targets.Clear();
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