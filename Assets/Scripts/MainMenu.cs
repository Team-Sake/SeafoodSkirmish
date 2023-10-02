using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    //Load Phase 1 Screen
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Quit Game
    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Player Has Quit The Game"); //Testing purposes
    }
}
