//////////////////////////////////////////////////////////////////////////
/// Author: Burnian
/// Date: 2018-3-22
/// Description: 每帧更新父类
//////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;


namespace Utils
{
    public class Updatable
    {
        public static List<Updatable> updatables = new List<Updatable>();

        public Updatable()
        {
            updatables.Add(this);
        }

        ~Updatable()
        {
            updatables.Remove(this);
        }

        public virtual void Update() { }
        public virtual void FixedUpdate() { }
    }
}
