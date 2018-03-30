using System;
using System.Collections.Generic;
using Races;
using Jobs;


namespace Skills
{
    public class Buff
    {
        public Buff()
        {
            duration = 0;
        }

        
        public float duration; // -1:永久生效 0:失效
        public Agent target;
    }
}
