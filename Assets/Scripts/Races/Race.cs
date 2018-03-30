using System;
using System.Collections.Generic;
using Skills;


namespace Races
{
    public class Race
    {
        public Race()
        {
            attribute = new Attribute();
            attribute.attack = 10f;
            attribute.defence = 0f;
            attribute.health = 100f;
            attribute.magic = 100f;
            attribute.hit = 50f;
            attribute.dodge = 0f;
            attribute.moveSpeed = 30f;
            attribute.mass = 10f;
            attribute.drag = 10f;
            attribute.vision = 100f;
        }


        public Attribute attribute;
        public List<Buff> buffs;
    }
}
