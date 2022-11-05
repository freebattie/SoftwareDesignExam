using Model.Abstract;
using Model.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Base.ConcreateDecorators {
    //TODO: HAM,PEPPERONI ETC
    public class NoItem : CharacterDecorator
    {
        public NoItem(Character original) : base(original)
        {
        }
    }
}
