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

        // @param
        // time 当前时间戳
        // start 属性初始值
        // delta 属性变化量
        // ttime 变化总时间
        public double Linear(double time, double start, double delta, double ttime)
        {
            return start + delta * time / ttime;
        }


        public static Tween Instance;
        Dictionary<Ease, EaseFunc> _dic;
    }
}
