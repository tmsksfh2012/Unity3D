using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public class Player_Value
    {
        public BigInteger Gold;
        public BigInteger Level_Up;
        public BigInteger Level_Damage;
        
        public void Get_Gold(BigInteger value) {
            Gold += value;
        }

        public void Get_Level_Hp() {
            Level += 1;
        }

        public void Get_Level_Damage() {
            Level_Damage += 1;
        }
    }

    public static GameMana

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
