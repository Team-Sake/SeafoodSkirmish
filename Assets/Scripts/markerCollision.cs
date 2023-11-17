using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class markerCollision : MonoBehaviour
{
    //bool check = false;
    BoxCollider2D fishCollider;
    Vector3 min, max;
    // Start is called before the first frame update

    private void Update()
    {
        fishCollider = GetComponent<BoxCollider2D>();

        min = fishCollider.bounds.min;
        max = fishCollider.bounds.max;
    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        
        check = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        check = false;
    }

    public bool getChecker()
    {
        return check;
    }*/

    public float getMin()
    {
        return min.x;
    }

    public float getMax()
    {
        return max.x;
        
    }


}
