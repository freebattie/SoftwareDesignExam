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
            Assert.That(item.Equals(new NoWeapon()));
        }

        [Test]
        public void WeaponFactoryValidInputTest() {
            var item = WeaponFactory.GetWeapon("sword", "test", 200);
            Assert.IsNotNull(item);
            Weapon wep = new Sword();
            wep.Name = "test sword";
            wep.Damage=200;
            Assert.That(item.Equals(wep));
        }
        [Test]
        public void ItemFacoryInvalidInputNotNullTest() {
            var starteq = new StartingCharacteGear();
            var equipment = CharacterInfoDecoratorFactory.GetItem("rabbitsf00t", starteq);
            Assert.IsNotNull(equipment);
            CharacterInfo wep = new NoItem(starteq);
            Assert.That(equipment.Equals(wep));
        }

        [Test]
        public void ItemFacoryValidInputTest() {
            var starteq = new StartingCharacteGear();
            var equipment = CharacterInfoDecoratorFactory.GetItem("rabbitsfoot", starteq);
            Assert.IsNotNull(equipment);
            CharacterInfo wep = new RabbitsFoot(starteq);
            
            Assert.That(equipment.Equals(wep));
        }
    }
}
