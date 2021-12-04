using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public class Player_Value
    {
        public BigInteger Gold;
        public BigInteger Level_Hp;
        public BigInteger Level_Damage;
        
        public void Get_Gold(BigInteger value) {
            Gold += value;
            GameManager.Instance.Text_Gold.text = "Gold : " + Gold;
        }

        public void Get_Level_Hp() {
            Level_Hp += 1;
            GameManager.Instance.Text_Level_Hp.text = "Level Hp : " + Level_Hp;
        }

        public void Get_Level_Damage() {
            Level_Damage += 1;
            GameManager.Instance.Text_Level_Damage.text = "Level_Damage : " + Level_Damage;
        }
    }

    public static GameManager Instance;
    public Player_Value m_Player_Value;
    public Text Text_Gold;
    public Text Text_Level_Hp;
    public Text Text_Level_Damage;
    public Text Text

    
    private void Awake() {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Player_Value = new Player_Value();
        GameManager.Instance.Text_Gold.text = "Gold : " + m_Player_Value.Gold;
        GameManager.Instance.Text_Level_Hp.text = "Level Hp : " + m_Player_Value.Level_Hp;
        GameManager.Instance.Text_Level_Damage.text = "Level_Damage : " + m_Player_Value.Level_Damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
