using System;
using System.Collections.Generic;


namespace Jobs
{
    public class Priest : Job
    {
        public Priest()
        {
            attribute.defence += 1;
            attribute.health += 100;
            attribute.magic += 100;
        }

    }
}
