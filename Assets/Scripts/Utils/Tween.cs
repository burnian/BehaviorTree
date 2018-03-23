//////////////////////////////////////////////////////////////////////////
/// Author: Burnian
/// Date: 2018-3-19
/// Description: 缓动算法
//////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;


namespace Utils
{
    using EaseToFunc = Dictionary<EASE, Func<double, double, double, double, double>>;

    public enum EASE : byte
    {
        Linear = 0,

        //Quad_In,
        //Quad_Out,
        //Quad_In_Out,

        Sin_In,
        Sin_Out,
        Sin_In_Out,

        //Elastic_In,
        //Elastic_Out,
        //Elastic_In_Out,

        None
    }

    public class Tween
    {
        public static Tween Instance;
        public static void Init()
        {
            Instance = new Tween();
        }

        public Tween()
        {
            dicEaseToFunc = new EaseToFunc();
            dicEaseToFunc.Add(EASE.Linear, Linear);
            dicEaseToFunc.Add(EASE.Sin_In, SinIn);
            dicEaseToFunc.Add(EASE.Sin_Out, SinOut);
            dicEaseToFunc.Add(EASE.Sin_In_Out, SinInOut);
        }


        /// <summary>
        /// <param name="start">属性初始值</param>
        /// <param name="delta">属性所需变化值</param>
        /// <param name="time">当前流逝时长</param>
        /// <param name="ttime">所需变化总时长</param>
        /// </summary>
        public double Linear(double start, double delta, double time, double ttime)
        {
            return start + delta * time / ttime;
        }
        // t time   b start   c delta   d ttime
        public double SinIn(double start, double delta, double time, double ttime)
        {
            return start + delta * (1 - Math.Cos(time / ttime * (Math.PI / 2)));
        }

        public double SinOut(double start, double delta, double time, double ttime)
        {
            return start + delta * Math.Sin(time / ttime * (Math.PI / 2));
        }

        public double SinInOut(double start, double delta, double time, double ttime)
        {
            return start - delta / 2 * (Math.Cos(Math.PI * time / ttime) - 1);
        }


        public EaseToFunc dicEaseToFunc;
    }
}
