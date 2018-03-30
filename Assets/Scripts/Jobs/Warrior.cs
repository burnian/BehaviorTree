using System;
using System.Collections.Generic;


namespace Jobs
{
    public class Warrior : Job
    {
        public Warrior()
        {
            attribute.defence += 4;
            attribute.health += 200;
            attribute.magic -= 50;
        }

    }
}
