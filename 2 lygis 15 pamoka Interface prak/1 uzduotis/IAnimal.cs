﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_15_pamoka_Interface_prak
{
    internal interface IAnimal
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        void Eat();

    }
}
