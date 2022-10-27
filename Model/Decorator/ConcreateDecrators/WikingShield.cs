using Model.Abstract;

namespace Model.Decorator.ConcreateDecrators
{
    internal class WikingShield : ItemDecorator {
        public WikingShield(Item item) : base(item) {
        }

        public override double GetDamage() {
            return base.GetDamage() + 1;
        }

        public override string GetDescription() {
            return base.GetDescription() +", Wiking Shiled";
        }

        public override double GetHealth() {
            return base.GetHealth() +20;
        }
    }
}