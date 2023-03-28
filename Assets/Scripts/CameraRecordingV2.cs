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
    private static int OFFSET = 0;

    [SerializeField] private int requiredFrames = 25000 + OFFSET;
    public static int REFRESH_SCENE_PER_FRAME = 10000;
    public static int frameCount = OFFSET;
    

    void Start()
    {
        Random.InitState(0);
    }
    void Update()
    {
        frameCount++;
        if (frameCount > requiredFrames)
        {
            Debug.Log("Captured enough frames. Quitting application.");
            Application.Quit();
        }
    }
}
