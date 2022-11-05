using Model.Decorator.Abstract;


namespace Model.Decorator.Items {
    internal class KnightGloves :CharacterDecorator{
        bool isbroken = false;
        double hitpoints = 3;
        

        public KnightGloves(Character original) : base(original) {
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
