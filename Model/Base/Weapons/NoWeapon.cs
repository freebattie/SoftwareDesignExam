using Model.Abstract;
using Model.Interface;
using System.Reflection.Metadata.Ecma335;

namespace Model.Base.Weapons
{
    public class NoWeapon : IWeapon
    {
        public double Damage { get; set; }

        public string Name => "No Weapon";

        string IWeapon.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Attack() {
            throw new NotImplementedException();
        }

        public void GetAllTargets(List<Character> targets) {
            throw new NotImplementedException();
        }

        public void SetTarget(Character target) {
            throw new NotImplementedException();
        }
    }
}