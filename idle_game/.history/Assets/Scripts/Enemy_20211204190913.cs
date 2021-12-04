using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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
        if(Attack_CoolTime < Attack_Speed) {
            Attack_CoolTime
        }
    }
}
