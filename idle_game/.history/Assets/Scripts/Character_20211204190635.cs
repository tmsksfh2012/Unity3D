using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Nume

public class NewBehaviourScript : MonoBehaviour
{
    public BingInteger Hp;
    public BingInteger Hp_Max;
    public BigInteger Damage;
    public float Attack_Speed;

    public void Init(BigInteger hp, BigInteger damage) {
        Hp_Max = hp;
        Hp = Hp_Max;
        Damage = damage;
        Attack_Speed = 1.0f;
    }

    public void Get_Hp(BigInteger hp) {
        Hp += hp;
        if(Hp > Hp_Max) {
            Hp = Hp_Max;
        }
    }

    public void Get_Damage(BigInteger damage) {
        Hp -= damage;

        if(Hp <= 0) {
            Dead();
        }
    }

    public void Hit_Damage(Character target, BigInteger damage) {
        target.Get_Damage(damage);
    }


    public void Dead() {
        Debug.Log("Dead");
    }
}
