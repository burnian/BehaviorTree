using System;
using System.Collections.Generic;


namespace Jobs
{
    public class Magician : Job
    {
        public Magician()
        {
            attribute.defence += 1;
            attribute.magic += 200;
        }

    }
}
