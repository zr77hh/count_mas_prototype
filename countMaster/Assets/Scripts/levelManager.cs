using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    [SerializeField]
    GameObject loseScreen,winScreen;
    public void win()
    {
        winScreen.SetActive(true);
    }
    public void lose()
    {
        loseScreen.SetActive(true);
    }
    public void tryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
