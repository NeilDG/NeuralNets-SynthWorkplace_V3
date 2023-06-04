using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

/// <summary>
/// For shadow scene dataset recording
/// </summary>
public class CameraRecordingV2 : MonoBehaviour
{
    private int frameCount = DomainParameters.OFFSET;

    private static CameraRecordingV2 sharedInstance;

    public static CameraRecordingV2 Instance
    {
        get
        {
            return sharedInstance;
        }
    }

    void Awake()
    {
        sharedInstance = this;
    }

    void OnDestroy()
    {
        sharedInstance = null;
    }

    void Start()
    {
        Random.InitState(0);
    }

    void Update()
    {
        frameCount++;
        if (frameCount > DomainParameters.MAX_IMAGES_TO_SAVE)
        {
            Debug.Log("Captured enough frames. Quitting application.");
            Application.Quit();
        }
    }

    public int GetCurrentFrameCount()
    {
        return this.frameCount;
    }
}
