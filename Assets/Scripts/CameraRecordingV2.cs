using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.Perception.GroundTruth;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

/// <summary>
/// For scene dataset recording
/// </summary>
/// 
public class CameraRecordingV2 : MonoBehaviour
{
    private int frameCount = DomainParameters.OFFSET;

    private string basePath = "X:/GithubProjects/NeuralNets-SynthWorkplace_V3/Recordings/";
    //NOTE: When running on EXE, images are saved in "C:/Users/delgallegon/AppData/LocalLow/DefaultCompany/NeuralNets-SynthWorkplace_V3/";

    private static CameraRecordingV2 sharedInstance;

    public static CameraRecordingV2 Instance
    {
        get
        {
            return sharedInstance;
        }
    }

    [SerializeField] private PerceptionCamera perceptionCamera;

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
        Random.InitState(DomainParameters.OFFSET);
    }

    void Update()
    {
        frameCount++;

        //allow render to finalize lighting and post-processing first.
        const int offsetFrames = 20;
        if (frameCount < offsetFrames)
        {
            return;
        }

        this.perceptionCamera.RequestCapture();

        if (frameCount - offsetFrames > DomainParameters.MAX_IMAGES_TO_SAVE)
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
