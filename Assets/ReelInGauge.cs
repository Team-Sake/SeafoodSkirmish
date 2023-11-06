using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ReelInGauge : MonoBehaviour
{
    public int max;
    public int current;
    public Image Fill;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Deplete", 5.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)max;
        if (fillAmount > 100)
        {
            Fill.fillAmount = 100;
        }
        else
        {
            Fill.fillAmount = fillAmount;
        }
    }

    void Deplete()
    {
        if (current < 5)
        {
            current = 0;
        }
        else
        {
            current -= 5;
        }
    }
}
