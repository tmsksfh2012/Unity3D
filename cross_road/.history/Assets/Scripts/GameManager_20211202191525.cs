using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Width = 5;
    public int Height = 5;

    public GameObject Platform;
    public Transform Platform_Parents;
    public GameObject Character;
    private List<GameObject> Platform_List = new List<GameObject>();
    private List<int> Platform_Check_List = new List<int>();
    public GameObject DeadLine;
    public float DeadLine_Speed = 1.0f;
    public float DeadLine_Speed_Max = 3.0f;
    public float DeadLine_Speed_Accel = 0.1f;

    public int Score;
    public Text Score_Text;
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

    private bool Game_Start = false;

    void Init()
    {
        for(int h = 0; h < Height; h++) {
            for(int w = 0; w < Width; w++) {
                Platform_List[Width * h + w].transform.position = new Vector3(-(Width - 1) / 2f + w,
                -0.5f, h);
                Set_Platform(Width * h + w, 0);
            }
        }
        Character.transform.position = new Vector3(0f, 0.5f, 0f);
        DeadLine.transform.position = new Vector3(0f, 0.5f, -3f);
        DeadLine.transform.localScale = new Vector3(Width, 1f, 1f);
        Game_Start = false;
        Score = 0;
        Score_Text.text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Game_Start){
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                Move(0);
            }        
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                Move(1);
            }        
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                Move(2);
            }        

            DeadLine.transform.position += Vector3.forward * DeadLine_Speed * Time.deltaTime;

            if(DeadLine_Speed < DeadLine_Speed_Max) {
                DeadLine_Speed += DeadLine_Speed_Accel;
            }
        }
        else {
            if(Input.GetKeyDown(KeyCode.Space)) {
                Init();
                Game_Start = true;
            }
        }
    }

    public void Move(int direction) {

        bool next_Platform = false;
        switch(direction) {
            case 0:
                if(Restrict(Vector3.left)) {
                    Character.transform.position += Vector3.left;
                }
                break;
            case 1:
                if(Restrict(Vector3.right)) {
                    Character.transform.position += Vector3.right;
                }
                break;
            case 2:
                Character.transform.position += Vector3.forward;
                next_Platform = true;
                break;
        }

        Check_Platform((int)(Width * (Character.transform.position.z % Height) 
        + Character.transform.position.x + Width / 2));

        if(next_Platform) {
            Next_Platform((int)Character.transform.position.z);
        }
    }

    void Check_Platform(int idx) {
        if(Platform_Check_List[idx] == 1) {
            Result();
        }
    }

    void Next_Platform(int character_z){
        for(int i = 0; i < Width; i++) {
            Platform_List[((character_z - 1) % Height) * Width + i].transform.position = new Vector3(-Width / 2 + i, -0.5f,
            (character_z - 1) + Height);
            Set_Platform((((character_z - 1) % Height) * Width + i),
                         UnityEngine.Random.Range(0, 8));
        }
        Score++;
        Score_Text.text = Score.ToString();
    }

    bool Restrict(Vector3 direction) {
        Vector3 move_Pos = Character.transform.position + direction;

        if(move_Pos.x > Width / 2 || move_Pos.x < -Width / 2) {
            return false;
        }
        else {
            return true;
        }
    }

    // void Set_Platform(int idx, Color color) {
    //     Platform_List[idx].GetComponent<MeshRenderer>().material.color = color;
    // }

    void Set_Platform(int idx, int randomNum) {
        switch(randomNum) {
            case 1:
                Platform_List[idx].GetComponent<MeshRenderer>().material.color = Color.red;
                Platform_Check_List[idx] = 1;
                break;
            default:
                Platform_List[idx].GetComponent<MeshRenderer>().material.color = Color.green;
                Platform_Check_List[idx] = 0;
                break;
        }
    }


    public void Result() {
        Debug.Log("Game Over");
        Game_Start = false;
    }
}
