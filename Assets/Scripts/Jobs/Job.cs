using System;
using System.Collections.Generic;
using Skills;


namespace Jobs
{
    public class Job
    {
        public Job()
        {
            attribute = new Attribute();
            attribute.attack = 10;
            attribute.defence = 0;
            attribute.health = 100;
            attribute.magic = 100;
            attribute.hit = 10; // percent
            attribute.dodge = 0; // percent
            attribute.moveSpeed = 30;
            attribute.mass = 10f;
            attribute.drag = 10f;
        }


        public Attribute attribute;
        public List<Buff> buffs;
    }
}
