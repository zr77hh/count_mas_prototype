using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField]
    doorManager manager;
    [SerializeField]
    bool multiplyWith;
    [SerializeField]
    int add;
    TextMesh text;
    private void Awake() 
    {
        text = GetComponentInChildren<TextMesh>();
        if(multiplyWith)
        {
            text.text = "X"+add.ToString();
        }
        else
        {
            if(add > 0)
            {
                text.text = "+"+add.ToString();
            }else
            {
                text.text = add.ToString();
            }
            
        }    
    }
    
    


    private void OnTriggerEnter(Collider other) 
    {
        armyManager army = other.transform.parent.GetComponent<armyManager>();
        if(army != null)
        {
            manager.add(gameObject,army,howMany(army));
        }
        
    }
    int howMany(armyManager ar)
    {
        int howMutch = add;

        if(multiplyWith)
        {
            howMutch = (ar.getPlayersNum()*add)-ar.getPlayersNum();
        }
        return howMutch;
    }
}
