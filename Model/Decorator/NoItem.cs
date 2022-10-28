﻿using Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Decorator {
    //TODO: HAM,PEPPERONI ETC
    internal class NoItem : CharacterDecorator {
        public NoItem(Character original) : base(original) {
        }
    }
}
