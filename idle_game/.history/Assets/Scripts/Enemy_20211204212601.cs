using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Character Target;

    // Start is called before the first frame update
    void Start()
    {
        Init(10, 1);
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
        Debug.Log("Enemy Dead");
        GameManager.Instance.m_Player_Value.Get_Gold(Gold);
        Spawn();
    }

    public int Lv_Hp = 200;
    public int Lv_Damage = 200;
    public int Lv_Gold = 200;

    public void Spawn() {
        Hp_Max += Hp_Max * Lv_Hp
    }
}
