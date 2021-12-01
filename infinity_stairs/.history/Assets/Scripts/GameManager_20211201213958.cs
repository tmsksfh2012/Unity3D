using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool Game_Start = false;
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
        if()
    }

    public void Data_Load()
    {
        for(int i = 0; i < 20; i++) {
            GameObject t_Obj = Instantiate(Platform, Vector3.zero, Quaternion.identity);
            t_Obj.transform.parent = Platform_Parents;
            Platform_List.Add(t_Obj);
            Platform_Check_List.Add(0);
        }

        Platform.SetActive(false);
    }

    private int Pos_Idx = 0;

    public void Init()
    {
        Character.transform.position = Vector3.zero;

        for(Pos_Idx =0; Pos_Idx <20; Pos_Idx++)
            Next_Platform(Pos_Idx);
    }

    public void Next_Platform(int idx)
    {
        int pos = Random.Range(0,2);

        if(idx == 0) {
            Platform_Check_List[idx] = pos;
            Platform_List[idx].transform.position = new Vector3(0, -0.5f, 0);
        }
        else {
            if(pos == 0) {
                Platform_Check_List[idx] = pos;
                Platform_List[idx].transform.position = Platform_List[idx - 1].transform.position
                + new Vector3(-1f, 0.5f, 0);
            }
            else {
                Platform_Check_List[idx] = pos;
                Platform_List[idx].transform.position = Platform_List[idx - 1].transform.position
                + new Vector3(1f, 0.5f, 0);
            }
        }
    }
}