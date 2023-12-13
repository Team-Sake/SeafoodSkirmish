using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase1FishAnim : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }
    public IEnumerator AnimateFish()
    {
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("FishPopUp");
    }


   

}
