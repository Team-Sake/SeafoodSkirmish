using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    public void ContinueGame()
    {
        SceneManager.LoadScene("Phase 2"); // loads next scene
    }
}
