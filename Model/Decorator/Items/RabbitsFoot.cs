﻿using Model.Decorator.Abstract;

namespace Model.Decorator.Items {
    //TODO: HAM,PEPPERONI ETC
    public class RabbitsFoot : CharacterDecorator
    {

        public int Pirce { get; set; } = 100;
        public int Lvl { get; set; } = 1;
        public string ItemName { get; set; } = "Rabbit Foot";
        private bool isUsed = false;
        public RabbitsFoot(Character original) : base(original)
        {

        }
        public override void RemoveHealth(double weaponDmg)
        {
            if (GetHealth() - weaponDmg <= 0 && !isUsed)
            {
                weaponDmg = 0;
                isUsed = true;
            }
            base.RemoveHealth(weaponDmg);
        }

        public override void Attack(Character person)
        {
            base.Attack(person);
            Console.WriteLine(GetLevel());

        }

        public override string GetDescription()
        {
            return base.GetDescription() + "\n# RabbitsFoot status:" + (isUsed ? " used": " not used");
        }
    }
}