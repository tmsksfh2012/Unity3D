using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Character;
    public Transform Platform_Parents;
    public GameObject Platform;
    private List<GameObject> Platforn_List = new List<GameObject>();
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
        
    }

    public void Data_Load()
    {
        for(int i = 0; i < 20; i++) {
        GameObject t_Obj = Instantiate(Platform, Vector3.zero, Quaternion.indentity);
        t_Obj.transform.parent = Platform_Parents;
        Platform_Check_List.Add(t_Obj);
        }
    }
}
