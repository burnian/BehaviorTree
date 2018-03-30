using System;
using System.Collections.Generic;


namespace Jobs
{
    public class Archer : Job
    {
        public Archer()
        {
            attribute.attack += 10;
            attribute.defence += 1;
            attribute.hit += 10;
            attribute.dodge += 5;
            attribute.moveSpeed += 20;
            attribute.vision *= 1.5f;
        }
    }
}
