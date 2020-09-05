using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip tapSound;

    public float ShakeDetectionThreshold;
    public float MinShakeInterval;

    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake = 0;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    
    void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
    }
    void Update()
    {
        if (Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold
                   && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval)
        {            
            timeSinceLastShake = Time.unscaledTime;
        }
    }

    void OnMouseDown()
    {
        audioSource.PlayOneShot(tapSound);
    }
}
