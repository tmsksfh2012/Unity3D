using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comtroller_Character : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider col) {
        if(col.tag == "DeadLine") {
            
        }
    }
}
