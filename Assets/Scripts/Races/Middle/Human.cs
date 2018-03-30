using System;
using System.Collections.Generic;


namespace Races
{
    public class Human : Race
    {
        public Human()
        {
            attribute.magic += 200;
            attribute.hit += 8;
            attribute.dodge += 2;
        }

    }
}
