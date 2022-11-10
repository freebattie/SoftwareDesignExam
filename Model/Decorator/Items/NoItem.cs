﻿using Model.Decorator.Abstract;

namespace Model.Decorator.Items {
    
    public class NoItem : CharacterGearDecorator
    {
        public NoItem(CharacterInfo original) : base(original)
        {


        }

        public override string GetDescription() {
            return "You have no items opsy missing db?";
        }
    }
}
