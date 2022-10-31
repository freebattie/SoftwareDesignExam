using Model.Abstract;

namespace Model.Interface
{
    public interface IWeapon
    {
        //TODO: not smart
        public double Damage { get; set; }
        public string Name { get; set; }

        void SetTarget(Character target);
        void GetAllTargets(List<Character> targets);
        void Attack();


    }
}