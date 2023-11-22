using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneCollision : MonoBehaviour
{

    BoxCollider2D zoneCollider;
    Vector3 min, max;

    // Start is called before the first frame update
    void Update()
    {
        zoneCollider = GetComponent<BoxCollider2D>();
        min = zoneCollider.bounds.min;
        max = zoneCollider.bounds.max;
    }

    // Update is called once per frame
    public float getMin()
    {
        return min.x;
    }

    public float getMax()
    {
        return max.x;
    }
}
