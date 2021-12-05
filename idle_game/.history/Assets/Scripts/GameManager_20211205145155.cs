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
        
        public void Get_Gold(BigInteger value, UnityEngine.Vector3 pos) {
            Gold += value;
            GameManager.Instance.Text_Gold.text = "Gold : " + Gold;
            GameManager.Instance.Set_Text(value.ToString(), pos);
        }

        public void Get_Level_Hp() {

            if(Gold >= Level_Hp * 10) {
                Gold -= Level_Hp * 10;
                Level_Hp += 1;
                GameManager.Instance.Text_Level_Hp.text = "Level Hp : " + Level_Hp;
            }
        }

        public void Get_Level_Damage() {
            if(Gold >= Level_Damage * 5) {
                Gold -= Level_Damage * 5;
                Level_Damage += 1;
                GameManager.Instance.Text_Level_Damage.text = "Level_Damage : " + Level_Damage;
            }
        }
    }

    public static GameManager Instance;
    public Player_Value m_Player_Value;
    public Text Text_Gold;
    public Text Text_Level_Hp;
    public Text Text_Level_Damage;
    public Text Text_Damage;
    public List<Text> Text_List;

    
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

    public void Btn_Level_Up_Hp() {
        m_Player_Value.Get_Level_Hp();
    }

    public void Btn_Level_Up_Damage() {
        m_Player_Value.Get_Level_Damage();
    }

    public void Set_Text(string text, UnityEngine.Vector3 pos) {
        bool set = false;
        foreach(Text t in Text_List) {
            if(!t.gameObject.activeSelf) {
                t.text = text;
                t.transform.position = Camera.main.WorldToScreenPoint(pos);
                t.GetComponent<Controller_Text>().Init();
                set = true;
                break;
            }
        }

        if(!set) {
            Text t = Instantiate(Text_Damage, Camera.main.WorldToScreenPoint(pos), UnityEngine.Quaternion.
            identity).GetComponent<Text>();

            t.transform.SetParent(Text_Damage.transform.parent);
            t.text = text;

            t.GetComponent<Controller_Text>().Init();

            Text_List.Add(t);
        }
    }
    public void Set_Text(string text) {
        bool set = false;
        foreach(Text t in Text_List) {
            if(!t.gameObject.activeSelf) {
                t.text = text;
                t.transform.position = new UnityEngine.Vector2(Screen.width * 0.5f, Screen.)
                t.GetComponent<Controller_Text>().Init();
                set = true;
                break;
            }
        }

        if(!set) {
            Text t = Instantiate(Text_Damage, Camera.main.WorldToScreenPoint(pos), UnityEngine.Quaternion.
            identity).GetComponent<Text>();

            t.transform.SetParent(Text_Damage.transform.parent);
            t.text = text;

            t.GetComponent<Controller_Text>().Init();

            Text_List.Add(t);
        }
    }
}
