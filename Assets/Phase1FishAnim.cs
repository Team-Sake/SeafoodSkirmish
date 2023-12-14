using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Phase1FishAnim : MonoBehaviour
{
    public Sprite salmon;
    public Sprite shark;

    Animator animator;

    Image image;

    void Start()
    {
        animator = transform.GetComponent<Animator>();
        image = this.gameObject.GetComponent<Image>();

        if(DifficultyLevel.difficulty == 2)
        {
            image.sprite = salmon;
        }
        else if(DifficultyLevel.difficulty == 3)
        {
            image.sprite = shark;
        }
        
    }
    public IEnumerator AnimateFish()
    {
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("FishPopUp");
    }


   

}
