using System;
using System.Collections.Generic;


namespace Races
{
    public class Orc : Race
    {
        public Orc()
        {
            attribute.attack += 2;
            attribute.defence += 1;
            attribute.health += 100;
            attribute.mass += 10;
        }

    }
}
