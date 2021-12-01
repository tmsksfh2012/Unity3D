using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool Game_Start = false;
    public float Current_Time = 0.0f; // 현재 남은 시간
    public float Destination_Time = 10.0f; // 전체 시간
    public float Add_Time_Flow = 0.001f; //감소 시간
    public Slider Slider;
    public Text text;
    public int Score =0;
    public GameObject Character;
    public Transform Platform_Parents;
    public GameObject Platform;
    private List<GameObject> Platform_List = new List<GameObject>();
    private List<int> Platform_Check_List = new List<int>();

        // Start is called before the first frame update
    void Start()
    {
        Data_Load();
        Init();
    }

        // Update is called once per frame
    void Update()
    {
        if(Game_Start) {
            if(Input.GetKeyDown(KeyCode.RightArrow)) {
                Check_Platform(Character_Pos_Idx, 1);
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
                Check_Platform(Character_Pos_Idx, 0);
            }

            Destination_Time -= Add_Time_Flow;
            Current_Time -= Time.deltaTime;

            Slider.value = Current_Time / Destination_Time;

            if(Current_Time < 0f)
                Result();

        }
        else {
            if(Input.GetKeyDown(KeyCode.Space)) {
                Init();
            }
        }
    }

    public void Data_Load()
    {
        for(int i = 0; i < 6; i++) {
            GameObject t_Obj = Instantiate(Platform, Vector3.zero, Quaternion.identity);
            t_Obj.transform.parent = Platform_Parents;
            Platform_List.Add(t_Obj);
            Platform_Check_List.Add(0);
        }

        Platform.SetActive(false);
    }

    private int Pos_Idx = 0;
    private int Character_Pos_Idx = 0;

    public void Init()
    {
        Character.transform.position = Vector3.zero;

        for(Pos_Idx =0; Pos_Idx <6;)
            Next_Platform(Pos_Idx);

        Destination_Time = 10.0f;
        Current_Time = Destination_Time;

        Character_Pos_Idx = 0;
        Score = 0;
        Text.text = Score.ToString();

        Game_Start = true;
    }

    public void Next_Platform(int idx)
    {
        int pos = Random.Range(0,2);

        if(idx == 0) {
            Platform_List[idx].transform.position = new Vector3(0, -0.5f, 0);
        }
        else {
            if(Pos_Idx < 6) {
                if(pos == 0) {
                    Platform_Check_List[idx - 1] = pos;
                    Platform_List[idx].transform.position = Platform_List[idx - 1].transform.position
                    + new Vector3(-1f, 0.5f, 0);
                }
                else {
                    Platform_Check_List[idx - 1] = pos;
                    Platform_List[idx].transform.position = Platform_List[idx - 1].transform.position
                    + new Vector3(1f, 0.5f, 0);
                }
            }
            else {
                if(pos == 0) {
                    if(idx % 6 == 0) {
                        Platform_Check_List[6 - 1] = pos;
                        Platform_List[idx % 6].transform.position = Platform_List[6 - 1].transform.position
                        + new Vector3(-1f, 0.5f, 0);
                    }
                    else {
                        Platform_Check_List[idx % 6 - 1] = pos;
                        Platform_List[idx % 6].transform.position = Platform_List[idx % 6 - 1].transform.position
                        + new Vector3(-1f, 0.5f, 0);
                    }
                }
                else {
                      if(idx % 6 == 0) {
                        Platform_Check_List[6 - 1] = pos;
                        Platform_List[idx % 6].transform.position = Platform_List[6 - 1].transform.position
                        + new Vector3(1f, 0.5f, 0);
                    }
                    else {
                        Platform_Check_List[idx % 6 - 1] = pos;
                        Platform_List[idx % 6].transform.position = Platform_List[idx % 6 - 1].transform.position
                        + new Vector3(1f, 0.5f, 0);
                    }
                }
            }
        }
        Score++;
        Text.text = Score.ToString();
        Pos_Idx++;
    }

    void Check_Platform(int idx, int direction) {
        if(Platform_Check_List[idx % 6] == direction) {
            Character_Pos_Idx++;
            Character.transform.position = Platform_List[Character_Pos_Idx % 6].transform.position +
            new Vector3(0f, 0.5f, 0);
            Next_Platform(Pos_Idx);
        }
        else {
            Result();
        }

    }

    public void Result() {
        Debug.Log("Game Over");
        Game_Start = false;
    }
}
