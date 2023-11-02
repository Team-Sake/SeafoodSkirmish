using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSlider : MonoBehaviour
{

    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;

    [SerializeField] Transform topPivotZone;
    [SerializeField] Transform bottomPivotZone;

    [SerializeField] Transform fish;

    float fishPosition;
    float fishDestination;

    float fishTimer;
    [SerializeField] float timerMultiplicator = 3f;

    float fishSpeed;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform hook;
    [SerializeField] Transform zone;
    float hookPosition;
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float zoneSize = 0.1f;
    [SerializeField] float hookPower = 5f;
    float hookProgress;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookProgressDegradationPower = 0.1f;

    [SerializeField] SpriteRenderer hookSpriteRenderer;
    [SerializeField] SpriteRenderer hookSpriteRendererZone;

    [SerializeField] Transform progressBarContainer;

    [SerializeField] Timer timer;

    bool pause = false;


    private void Start()
    {
        Resize();
        ResizeZone();
        timer.SetTimer(20);
        timer.StartTimer();
    }

    private void Resize()
    {
        Bounds b = hookSpriteRenderer.bounds;
        float xSize = b.size.x;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(topPivot.position, bottomPivot.position);
        ls.x = (distance / xSize * hookSize);
        hook.localScale = ls;

    }

    private void ResizeZone()
    {
        Bounds b = hookSpriteRendererZone.bounds;
        float xSize = b.size.x;
        Vector3 ls = zone.localScale;
        float distance = Vector3.Distance(topPivotZone.position, bottomPivotZone.position);
        ls.x = (distance / xSize * zoneSize);
        zone.localScale = ls;

    }

    private void Update()
    {
        if(pause) {
            return;
        }
        Fish();
        Hook();
        ProgressCheck();
    }

    private void ProgressCheck()
    {
        Vector3 ls = progressBarContainer.localScale;
        ls.y = hookProgress;
        progressBarContainer.localScale = ls;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if (!timer.timerIsRunning)
        {
            Lose();
            return;
        }

        if(min < fishPosition && fishPosition < max)
        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookProgressDegradationPower * Time.deltaTime;

        }
        if(hookProgress >= 1.53f)
        {
            Win();
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1.53f);
    }

    private void Lose()
    {
        pause = true;
    }
    
    private void Win()
    {
        timer.timerIsRunning = false;
        pause = true;
        Debug.Log("You caught the fish, go to phase 2");
    }

    void Hook()
    {
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }
        hookPullVelocity -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if(hookPosition - hookSize / 2 < 0f && hookPullVelocity < 0f)
        {
            hookPullVelocity = 0f;
        }
        if(hookPosition + hookSize / 2 >= 1f && hookPullVelocity > 0f)
        {
            hookPullVelocity = 0f;
        }
        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize/2);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);

    }

    void Fish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            fishTimer = UnityEngine.Random.value * timerMultiplicator;

            fishDestination = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPivotZone.position, topPivotZone.position, fishPosition);
    }
}


