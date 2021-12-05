using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public static Player Instance;
    public Character Target;

    p

    // Start is called before the first frame update
    void Start()
    {
        Init(100, 1);
    }

    float Attack_CoolTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if(State == Character_State.Death) {
            return;
        }

        if(Attack_CoolTime < Attack_Speed) {
            Attack_CoolTime += Time.deltaTime;
        }else {
            Hit_Damage(Target, Damage);
            Attack_CoolTime = 0f;
        }
    }

    public override void Dead() {
        base.Dead();
        Debug.Log("Player Dead");

        Spawn();
    }

    public void Spawn() {
        Hp = Hp_Max;
        State = Character_State.Idle;
    }
}
