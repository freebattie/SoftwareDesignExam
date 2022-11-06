
using Model.Interface;

namespace Model.Base.Weapons
{

    //TODO: refactor til abstract weapon?
    public class Sword : Weapon
    {
        


        public override double GetDamage() {
            return Damage;
        }
    } 
}