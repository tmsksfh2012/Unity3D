using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Width = 5;
    public int Height = 5;

    public GameObject Platform;
    public Transform Platform_Parents;
    public GameObject Character;
    private List<GameObject> Platform_List = new List<GameObject>();
    private List<int> Platform_Check_List = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        Data_Load();
        Init();
    }

    void Data_Load()
    {
        for(int i = 0; i < Width * Height; i++) {
            GameObject t_Obj = Instantiate(Platform, Vector3.zero, Quaternion.identity);
            t_Obj.transform.parent = Platform_Parents;
            Platform_List.Add(t_Obj);
            Platform_Check_List.Add(0);
        }

        Platform.SetActive(false);
    }
    void Init()
    {
        for(int h = 0; h < Height; h++) {
            for(int w = 0; w < Width; w++) {
                Platform_List[Width * h + w].transform.position = new Vector3(-(Width - 1) / 2f + w,
                -0.5f, h);
            }
        }
        Character.transform.position = new Vector3(0f, 0.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            Move(0);
        }        
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            Move(1);
        }        
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            Move(2);
        }        
    }

    public void Move(int direction) {
        switch(direction) {
            case 0
        }
    }
}
