using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class markerCollision : MonoBehaviour
{
    bool check = false;
    // Start is called before the first frame update

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("marker is in zone");
        check = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("marker left zone");
        check = false;
    }

    public bool getChecker()
    {
        return check;
    }
}
