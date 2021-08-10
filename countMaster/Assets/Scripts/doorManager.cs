using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManager : MonoBehaviour
{
    bool alreadyAdded = false;
    public void add(GameObject door,armyManager ar,int howMany)
    {
        if(!alreadyAdded)
        {
            Destroy(door);
            ar.editPlayerAmount(howMany);
            alreadyAdded = true;
        }
        
    }
}
