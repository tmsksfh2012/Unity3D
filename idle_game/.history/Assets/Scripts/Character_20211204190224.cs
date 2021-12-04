using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public BingInteger Hp;
    public BingInteger Hp_Max;
    public BigInteger Damage;
    public float Attack_Speed;

    public void Init() {
        Hp_Max = 100;
        Hp = Hp_Max;
        Damage = 10;
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
            
        }
    }
}
