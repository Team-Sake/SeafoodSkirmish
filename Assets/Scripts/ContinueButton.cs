using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{

    [SerializeField] Transition transition;
 
    public void ContinueGame()
    {
        //transition.AnimateTransition();
        //SceneManager.LoadScene("Phase 2"); // loads next scene
    }
}
