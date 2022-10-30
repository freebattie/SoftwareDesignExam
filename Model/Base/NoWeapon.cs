using Model.Interface;
using System.Reflection.Metadata.Ecma335;

namespace Model.Base
{
    internal class NoWeapon : IWeapon
    {
        public double Damage { get; set; }

        public string Name => "No Weapon";
    }
}