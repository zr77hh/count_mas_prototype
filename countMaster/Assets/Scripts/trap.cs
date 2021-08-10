using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        Sytickman sytickman = other.GetComponent<Sytickman>();
        if(sytickman != null)
        {
            sytickman.kill();
        }
        
    }
}
