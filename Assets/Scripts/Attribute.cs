using System;
using System.Collections.Generic;


public class Attribute
{
    public Attribute()
    {
    }

    public static Attribute operator +(Attribute a, Attribute b)
    {
        var temp = new Attribute();
        temp.attack = a.attack + b.attack;
        temp.defence = a.defence + b.defence;
        temp.health = a.health + b.health;
        temp.magic = a.magic + b.magic;
        temp.hit = a.hit + b.hit;
        temp.dodge = a.dodge + b.dodge;
        temp.moveSpeed = a.moveSpeed + b.moveSpeed;
        temp.mass = a.mass + b.mass;
        temp.drag = a.drag + b.drag;
        temp.vision = a.vision + b.vision;

        return temp;
    }

    public static Attribute operator -(Attribute a, Attribute b)
    {
        var temp = new Attribute();
        temp.attack = a.attack - b.attack;
        temp.defence = a.defence - b.defence;
        temp.health = a.health - b.health;
        temp.magic = a.magic - b.magic;
        temp.hit = a.hit - b.hit;
        temp.dodge = a.dodge - b.dodge;
        temp.moveSpeed = a.moveSpeed - b.moveSpeed;
        temp.mass = a.mass - b.mass;
        temp.drag = a.drag - b.drag;
        temp.vision = a.vision - b.vision;

        return temp;
    }


    public float attack;
    public float defence;
    public float health;
    public float magic;
    public float hit; // percent
    public float dodge; // percent
    public float moveSpeed; // pixel/s
    public float mass; // 物理质量
    public float drag; // 物理移动衰减
    public float vision; // 视野距离
}
