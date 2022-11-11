using Model.Decorator.Abstract;


namespace Model.Decorator.Gear {
    internal class KnightGloves :CharacterInfoDecorator{
        bool isbroken = false;
        double hitpoints = 3;
        

        public KnightGloves(CharacterInfo original) : base(original) {
        }

        public override void RemoveHealth(double weaponDmg) {
            if (hitpoints < 1)
                isbroken = true;

            if (!isbroken && base.GetHealth() < base.GetMaxHealth()) {
                
                base.IncreaseHealth(weaponDmg);
                hitpoints -= 1;
            }
            else
                base.RemoveHealth(weaponDmg);
        }
        public override string GetDescription() {
            return base.GetDescription() + "\n# Knights Gloves: " + (isbroken ? "is broken" : $"has {hitpoints} uses left");
        }
    }
}
