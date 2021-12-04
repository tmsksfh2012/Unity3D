using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class Character : MonoBehaviour
{
    public enum Character_State {
        Idle,
        Death,
    }
    public BigInteger Hp;
    public BigInteger Hp_Max;
    public BigInteger Damage;
    public float Attack_Speed;
    public Character_State State;
    public BigInteger Gold;

    public void Init(BigInteger hp, BigInteger damage) {
        Hp_Max = hp;
        Hp = Hp_Max;
        Damage = damage;
        Attack_Speed = 1.0f;
        Gold = 10;
        State = Character_State.Idle;
    }

    public void Get_Hp(BigInteger hp) {

        if(State == Character_State.Death) {
            return;
        }
        Hp += hp;
        if(Hp > Hp_Max) {
            Hp = Hp_Max;
        }
    }

    public void Get_Damage(BigInteger damage) {
        if(State == Character_State.Death) {
            return;
        }

        Hp -= damage;

        if(Hp <= 0) {
            Dead();
        }
    }

    public void Hit_Damage(Character target, BigInteger damage) {
        target.Get_Damage(damage);
        Debug.Log("Target State : " + target.State + "Hp : " + target.Hp + " / " + damage);
    }


    public virtual void Dead() {

        Debug.Log("Dead");
        State = Character_State.Death;
    }
}
