using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButton : MonoBehaviour
{
    public Transition transition;

    void Start()
    {
        StartCoroutine(transition.AnimateInTransition());   
    }
    public void transitionToTitle()
    {
        StartCoroutine(transition.AnimateOutTransition());
    }
}
