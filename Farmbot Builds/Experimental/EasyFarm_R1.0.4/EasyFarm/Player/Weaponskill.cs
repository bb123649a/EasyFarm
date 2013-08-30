﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyFarm.PlayerTools
{
    public class WeaponAbility : Ability
    {
        public WeaponAbility() { }
        public WeaponAbility(string name, double distance) : base(name) 
        {
            MaxDistance = distance;
        }
        public double MaxDistance;
        public bool IsEnabled;
    }
}
