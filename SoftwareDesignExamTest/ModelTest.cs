using Model.Base.Weapons;
using Model.Decorator.Abstract;
using Model.Decorator.Items;
using Model.Decorator.Original;
using Model.Factory;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExamTest {
    internal class ModelTest {

        [Test]
        public void WeaponFactoryInvalidInputNotNullTest() {
            var item = WeaponFactory.GetWeapon("error", "test", 200);
            Assert.IsNotNull(item);
            Assert.AreEqual(new NoWeapon(), item);
        }

        [Test]
        public void WeaponFactoryValidInputTest() {
            var item = WeaponFactory.GetWeapon("sword", "test", 200);
            Assert.IsNotNull(item);
            Weapon wep = new Sword();
            wep.Name = "test sword";
            wep.Damage=200;
            Assert.AreEqual(wep, item);
        }
        [Test]
        public void ItemFacoryInvalidInputNotNullTest() {
            var starteq = new StartingCharacter();
            var equipment = ItemDecoratorFactory.GetItem("rabbitsf00t", starteq);
            Assert.IsNotNull(equipment);
            Character wep = new NoItem(starteq);
            Assert.AreEqual(wep, equipment);
        }

        [Test]
        public void ItemFacoryValidInputTest() {
            var starteq = new StartingCharacter();
            var equipment = ItemDecoratorFactory.GetItem("rabbitsfoot", starteq);
            Assert.IsNotNull(equipment);
            Character wep = new RabbitsFoot(starteq);
            
            Assert.AreEqual(wep, equipment);
        }
    }
}
