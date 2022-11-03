using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface {
    public interface IUI {
        void Draw(Menu menu);
        string ReadIntInput<T>(List<T> list);
        string ReadIntInput();
        string ReadStringInput();
    }
}
