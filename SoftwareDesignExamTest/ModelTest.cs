using Model.Base.Weapons;
using Model.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExamTest {
    internal class ModelTest {

        [Test]
        public void WeaponFactoryInvalidInputTest() {
            var item = WeaponFactory.GetWeapon("error", "test", 200);
            Assert.IsNotNull(item);
            Assert.AreEqual(new NoWeapon(), item);
        }

        [Test]
        public void WeaponFactoryValidInputTest() {
            var item = WeaponFactory.GetWeapon("sword", "test", 200);
            Assert.IsNotNull(item);
            Assert.AreEqual(new NoWeapon(), item);
        }
    }
}
