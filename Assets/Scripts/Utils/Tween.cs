//////////////////////////////////////////////////////////////////////////
/// Author: Burnian
/// Date: 2018-3-19
/// Description: 缓动算法
//////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;


namespace Utils
{
    delegate double EaseFunc(double time, double start, double delta, double ttime);

    public class Tween
    {
        public enum Ease
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

            END
        }

        public static Tween Instance;
        public static void Init()
        {
            Instance = new Tween();
        }

        public Tween()
        {
            _dic = new Dictionary<Ease, EaseFunc>();
            _dic.Add(Ease.Linear, Linear);
            //_dic.Add(Ease.Sin_In, Sin_In);
            //_dic.Add(Ease.Sin_Out, Sin_Out);
            //_dic.Add(Ease.Sin_In_Out, Sin_In_Out);
        }

        /// <summary>
        /// <param name="time">当前时间戳</param>
        /// <param name="start">属性初始值</param>
        /// <param name="delta">属性变化量</param>
        /// <param name="ttime">变化总时间</param>
        /// </summary>
        public double Linear(double time, double start, double delta, double ttime)
        {
            return start + delta * time / ttime;
        }


        Dictionary<Ease, EaseFunc> _dic;
    }
}
