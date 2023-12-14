using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition : MonoBehaviour
{
    public string sceneName;
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public IEnumerator AnimateInTransition()
    {
        animator.SetTrigger("AnimateIn");
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("Idle");
    }


    public IEnumerator AnimateOutTransition()
    {
        yield return new WaitForSeconds(2f);
        animator.SetTrigger("AnimateOut");
        yield return new WaitForSeconds(1f);
        //load the scene we want
        if (DifficultyLevel.difficulty == 3 && SceneManager.GetActiveScene().name == "Phase 2")
        {
            SceneManager.LoadScene("End Screen");
            DifficultyLevel.difficulty = 1;
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
               
     
    }
}