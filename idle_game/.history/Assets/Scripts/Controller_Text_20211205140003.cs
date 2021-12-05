using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Text : MonoBehaviour
{
    float move_Time = 0f;
    // Start is called before the first frame update

    public void  Init() {
        move_Time = 0f;
        this.gameObject.SetActive(true);
    }

    void Active_Off() {
        this.gameObject.SetActive(false);
    }
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(move_Time < 1.0f)
    }
}
