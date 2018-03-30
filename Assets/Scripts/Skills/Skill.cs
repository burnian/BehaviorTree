using System;
using System.Collections.Generic;
using Races;
using Jobs;


namespace Skills
{
    public class Skill
    {
        public Skill()
        {
            casters = new List<Agent>();
            targets = new List<Agent>();
        }


        public List<Agent> casters;
        public List<Agent> targets;

        public float coolDown;
        public Race[] limitRaces;
        public Job[] limitJobs;
    }
}
