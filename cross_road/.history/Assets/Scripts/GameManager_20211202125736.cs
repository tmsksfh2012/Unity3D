using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Width = 5;
    public int Height = 5;

    public GameObject Platform;
    public GameObject Platform_Parents;
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
            Platform_List.Add()
        }
    }
    void Update()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
