using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class armyManager : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField]
    GameObject sytickManPrefab,sytickMan;
    [SerializeField]
    levelManager levelMang;

    float maxY = 0.5f;
    float maxX;
    int armyCount;
    private void Start() 
    {
        addSytickman();
    }
    
    public void editPlayerAmount(int num)
    {
        if(num > 0)
        {
            for (int i = 0; i < num; i++)
            {
                addSytickman();
            }
        }
        else
        {
            for (int i = 0; i < num*-1; i++)
            {
                destroyRandomSytickman();
            }
        }
    }
    public int getPlayersNum()
    {
        return armyCount;
    }

    void addSytickman()
    {
        maxY+=0.01f;
        if(maxY<=1.85f)
        {
            maxX = maxY;
        }
    
        bool noPlaceAvailable = true;
        while (noPlaceAvailable)
        {
            Vector3 pos = new Vector3(Random.Range(-maxX,maxX),0,Random.Range(-maxY,maxY)) + transform.position;
            if(NavMesh.SamplePosition(pos,out NavMeshHit hit,0.3f,NavMesh.AllAreas))
            {
                noPlaceAvailable = false;
                GameObject g = Instantiate(sytickManPrefab,pos,Quaternion.identity).gameObject;
                g.transform.SetParent(transform);
                armyCount+=1;
                g.GetComponent<Sytickman>().manager = this;
            }
        }
    }
    public void removeSytickman()
    {
        maxY-=0.01f;
        if(maxY<=1.85f)
        {
            maxX = maxY;
        }
        armyCount-=1;

        if(armyCount<=0)
        {
            GetComponent<movement>().stop = true;
            levelMang.lose();
        }

    }
    void destroyRandomSytickman()
    {
        Sytickman[] s = GetComponentsInChildren<Sytickman>();
        s[Random.Range(0,s.Length)].kill();
       // Debug.Log(s.Length);
    }
    public void scaleUp()
    {
        GetComponent<movement>().stop = true;
        Sytickman[] sytickmans = GetComponentsInChildren<Sytickman>();
        foreach (var item in sytickmans)
        {
            Destroy(item.gameObject);
            transform.localScale+= new Vector3(0.05f,0.05f,0.05f);
        }
        sytickMan.SetActive(true);
        sytickMan.GetComponent<Animator>().SetBool("attack",true);
        if(transform.localScale.z > 5)
        {
            levelMang.win();
        }
        else
        {
            levelMang.lose();
        }
    }
}
