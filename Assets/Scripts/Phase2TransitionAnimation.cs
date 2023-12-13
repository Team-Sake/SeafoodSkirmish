using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2TransitionAnimation : MonoBehaviour
{
    [SerializeField] Transition transition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(transition.AnimateInTransition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
