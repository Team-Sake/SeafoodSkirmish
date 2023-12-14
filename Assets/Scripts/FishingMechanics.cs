using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishingSlider : MonoBehaviour
{
    AudioSource m_AudioSource;

    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;

    [SerializeField] Transform topPivotZone;
    [SerializeField] Transform bottomPivotZone;

    [SerializeField] Transform fish;

    float fishPosition;
    float fishDestination;

    float fishTimer;
    [SerializeField] float timerMultiplicator;

    float fishSpeed;
    [SerializeField] float smoothMotion;

    [SerializeField] Transform hook;
    [SerializeField] Transform zone;
    float hookPosition;
    [SerializeField] float hookSize;
    [SerializeField] float zoneSize;
    [SerializeField] float hookPower;
    float hookProgress;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookProgressDegradationPower;

    [SerializeField] SpriteRenderer hookSpriteRenderer;
    [SerializeField] SpriteRenderer hookSpriteRendererZone;

    [SerializeField] Transform progressBarContainer;

    [SerializeField] Timer timer;
    [SerializeField] markerCollision fishCollision;
    [SerializeField] zoneCollision zoneCollision;

    [SerializeField] TryAgainButton tryAgainButton;
    [SerializeField] ContinueButton continueButton;
    [SerializeField] Transition transition;
    [SerializeField] Phase1FishAnim phase1FishAnim;
    [SerializeField] TextMeshProUGUI fishCaughtText; 

    bool pause = false;
    //int level = DifficultyLevel.difficulty;

    private void Start()
    {
        StartCoroutine(transition.AnimateInTransition());
        timer.SetTimer(20);
        timer.StartTimer();
        
        if (DifficultyLevel.difficulty == 1)
        {
            timerMultiplicator = 2f;
            smoothMotion = 1f;
            hookSize = 0.025f;
            zoneSize = 0.7f;
            hookPower = 0.2f;
            hookProgressDegradationPower = 0.2f;
            
            Resize();
            ResizeZone();
        } else if (DifficultyLevel.difficulty == 2)
        {
            timerMultiplicator = 2f;
            smoothMotion = 1f;
            hookSize = 0.025f;
            zoneSize = 0.4f;
            hookPower = 0.15f;
            hookProgressDegradationPower = 0.3f;
            
            Resize();
            ResizeZone();
            bottomPivotZone.position = new Vector3(bottomPivotZone.position.x - 1.442f, bottomPivotZone.position.y, bottomPivotZone.position.z);
            topPivotZone.position = new Vector3(topPivotZone.position.x + 1.442f, topPivotZone.position.y, topPivotZone.position.z);
        } else if (DifficultyLevel.difficulty == 3)
        {
            timerMultiplicator = 0.5f;
            smoothMotion = 1f;
            hookSize = 0.025f;
            zoneSize = 0.25f;
            hookPower = 0.4f;
            hookProgressDegradationPower = 0.3f;
            
            Resize();
            ResizeZone();
            bottomPivotZone.position = new Vector3(bottomPivotZone.position.x - 1.942f, bottomPivotZone.position.y, bottomPivotZone.position.z);
            topPivotZone.position = new Vector3(topPivotZone.position.x + 1.942f, topPivotZone.position.y, topPivotZone.position.z);
        }
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

        if (!timer.timerIsRunning)
        {
            Lose();
            return;
        }
     
        if(fishCollision.getMin() > zoneCollision.getMin() && fishCollision.getMax() < zoneCollision.getMax())
        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookProgressDegradationPower * Time.deltaTime;

        }

        if (hookProgress >= 1.53f)
        {
            Win();
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1.53f);
    }

    private void Lose()
    {
        pause = true;
        GameObject marker = GameObject.Find("Marker");
        marker.SetActive(false);
        GameObject zone = GameObject.Find("Zone");
        zone.SetActive(false);
        GameObject fishBar = GameObject.Find("HookFishBar");
        fishBar.SetActive(false);
        GameObject progressBarContainer = GameObject.Find("ProgressBarContainer");
        progressBarContainer.SetActive(false);
        GameObject progressBar = GameObject.Find("ProgressBar");
        progressBar.SetActive(false);
        GameObject timerText = GameObject.Find("Timer Text");
        timerText.SetActive(false);
        tryAgainButton.gameObject.SetActive(true);
        
    }
    
    private void Win()
    {
        timer.timerIsRunning = false;
        pause = true;
        GameObject marker = GameObject.Find("Marker");
        marker.SetActive(false);
        GameObject zone = GameObject.Find("Zone");
        zone.SetActive(false);
        GameObject fishBar = GameObject.Find("HookFishBar");
        fishBar.SetActive(false);
        GameObject progressBarContainer = GameObject.Find("ProgressBarContainer");
        progressBarContainer.SetActive(false);
        GameObject progressBar = GameObject.Find("ProgressBar");
        progressBar.SetActive(false);
        GameObject timerText = GameObject.Find("Timer Text");
        timerText.SetActive(false);
        fishCaughtText.color = new Color(255f, 250f, 134f, 255f);
        StartCoroutine(transition.AnimateOutTransition());
        StartCoroutine(phase1FishAnim.AnimateFish());
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


