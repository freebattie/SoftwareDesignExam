﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesignExam.Interface;
using SoftwareDesignExam.Weapons;

namespace SoftwareDesignExam.Factory
{
    public class WeaponFactory
    {

        public static IWeapon GetWeapon(string weaponName, string name, int dmg)
        {

            switch (weaponName)
            {
                case "axe": return new Axe(dmg, name);
                case "sword": return new Sword(dmg, name);
            }

            return null;
        }
    }
}
