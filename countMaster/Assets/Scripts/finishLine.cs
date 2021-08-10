using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishLine : MonoBehaviour
{
    bool iscollided;
    private void OnTriggerEnter(Collider other) 
    {
        if(!iscollided)
        {
            other.transform.parent.GetComponent<armyManager>().scaleUp();
            iscollided = true;    
        }
    }
}
