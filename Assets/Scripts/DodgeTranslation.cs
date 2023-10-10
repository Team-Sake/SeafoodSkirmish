using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DodgeTranslation : MonoBehaviour
{
    public Transform player;
    public GameObject targetLeft;
    public GameObject targetRight;
    public float speed;

    Vector3 DefaultPosition;
    // Start is called before the first frame update
    void Start()
    {
        DefaultPosition = player.transform.position;
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            StartCoroutine(dodgeLeft());
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            StartCoroutine(dodgeRight());
        }
    }

    public IEnumerator dodgeLeft()
    {
        player.position = Vector3.MoveTowards(player.position, targetLeft.transform.position, speed);
        yield return new WaitForSeconds(1);
        player.position = Vector3.MoveTowards(player.position, DefaultPosition, speed);

    }

    public IEnumerator dodgeRight()
    {
        player.position = Vector3.MoveTowards(player.position, targetRight.transform.position, speed);
        yield return new WaitForSeconds(1);
        player.position = Vector3.MoveTowards(player.position, DefaultPosition, speed);
    }


    


}
