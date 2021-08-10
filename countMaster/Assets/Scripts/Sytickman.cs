using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sytickman : MonoBehaviour
{
    public armyManager manager;

    public void kill()
    {
        manager.removeSytickman();
        Debug.Log(99);
        transform.SetParent(null);
        Destroy(gameObject);
    }

}
