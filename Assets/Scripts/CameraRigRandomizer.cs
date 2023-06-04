using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class CameraRigRandomizer : MonoBehaviour
{
    private Transform cameraRig;

    [SerializeField] private bool shouldRandomizeCamera = true;
    [SerializeField] private bool shouldRandomizeLight = true;
    [SerializeField] private Light directionalLight;

    private Vector3 minRot;
    private Vector3 maxRot;

    private const float INTERVAL = 1.0f;
    private float ticks = 0.0f;

    private Color[] rwLightColors;

    // Start is called before the first frame update
    void Start()
    {
        this.cameraRig = this.gameObject.transform;

        this.minRot = new Vector3(DomainParameters.MIN_ROT_CONFIG, DomainParameters.MIN_ROT_CONFIG, 0.0f);
        this.maxRot = new Vector3(DomainParameters.MAX_ROT_CONFIG, DomainParameters.MAX_ROT_CONFIG, 0.0f);

        this.InitializeLightColors();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*this.ticks += Time.captureDeltaTime;
        if (this.ticks >= INTERVAL)
        {
            this.ticks = 0.0f;
            this.RandomizeCamera();
        }*/

        if (this.shouldRandomizeCamera)
        {
            this.RandomizeCamera();
        }

        if (this.shouldRandomizeLight)
        {
            this.RandomizeLightDirection();
        }
    }

    private void RandomizeCamera()
    {
        Vector3 localPos = this.cameraRig.localPosition;
        localPos.x = Random.Range(DomainParameters.MIN_POS_CONFIG.x, DomainParameters.MAX_POS_CONFIG.x);
        localPos.y = Random.Range(DomainParameters.MAX_POS_CONFIG.y, DomainParameters.MAX_POS_CONFIG.y);
        localPos.z = Random.Range(DomainParameters.MIN_POS_CONFIG.z, DomainParameters.MAX_POS_CONFIG.z);

        this.cameraRig.localPosition = localPos;

        Vector3 localRot = this.cameraRig.localEulerAngles;
        localRot.x = Random.Range(this.minRot.x, this.maxRot.x);
        localRot.y = Random.Range(this.minRot.y, this.maxRot.y);

        this.cameraRig.localEulerAngles = localRot;
    }

    private void RandomizeLightDirection()
    {
        const float MIN_ANGLE = 15.0f;
        const float MAX_ANGLE = 170.0f;

        Transform lightTransform = this.directionalLight.transform;
        Vector3 rotAngles = lightTransform.localEulerAngles;

        rotAngles.x = Random.Range(MIN_ANGLE, MAX_ANGLE);
        rotAngles.y = Random.Range(MIN_ANGLE, MAX_ANGLE);
        lightTransform.localEulerAngles = rotAngles;

        int randLight = Random.Range(0, this.rwLightColors.Length);
        this.directionalLight.color = this.rwLightColors[randLight];
        Debug.Log("<b> Light coords: " + lightTransform.ToString() + "</b>");

        //this.PrintSphericalHarmonics(RenderSettings.ambientProbe);
    }

    private void PrintSphericalHarmonics(SphericalHarmonicsL2 shL2)
    {
        //range (0,2) (0, 8)
        float rc0 = shL2[0, 0]; float rc1 = shL2[0, 1]; float rc2 = shL2[0, 2];
        float rc3 = shL2[0, 3]; float rc4 = shL2[0, 4]; float rc5 = shL2[0, 5];
        float rc6 = shL2[0, 6]; float rc7 = shL2[0, 7]; float rc8 = shL2[0, 8];

        float gc0 = shL2[1, 0]; float gc1 = shL2[1, 1]; float gc2 = shL2[1, 2];
        float gc3 = shL2[1, 3]; float gc4 = shL2[1, 4]; float gc5 = shL2[1, 5];
        float gc6 = shL2[1, 6]; float gc7 = shL2[1, 7]; float gc8 = shL2[1, 8];

        float bc0 = shL2[2, 0]; float bc1 = shL2[2, 1]; float bc2 = shL2[2, 2];
        float bc3 = shL2[2, 3]; float bc4 = shL2[2, 4]; float bc5 = shL2[2, 5];
        float bc6 = shL2[2, 6]; float bc7 = shL2[2, 7]; float bc8 = shL2[2, 8];

        Debug.Log("R coefficients: " + rc0 + " " + rc1 + " " + rc2 + " " + rc3 + " " + rc4 + " " + rc5 + " " + rc6 + " " + rc7 + " " + rc8);
        Debug.Log("G coefficients: " + gc0 + " " + gc1 + " " + gc2 + " " + gc3 + " " + gc4 + " " + gc5 + " " + gc6 + " " + gc7 + " " + gc8);
        Debug.Log("B coefficients: " + bc0 + " " + bc1 + " " + bc2 + " " + bc3 + " " + bc4 + " " + bc5 + " " + bc6 + " " + bc7 + " " + bc8);
    }

    private void InitializeLightColors()
    {
        this.rwLightColors = new Color[8];
        //from http://planetpixelemporium.com/tutorialpages/light.html
        this.rwLightColors[0].r = 255.0f / 255.0f;
        this.rwLightColors[0].g = 147.0f / 255.0f;
        this.rwLightColors[0].b = 41.0f / 255.0f;

        this.rwLightColors[1].r = 255.0f / 255.0f;
        this.rwLightColors[1].g = 197.0f / 255.0f;
        this.rwLightColors[1].b = 143.0f / 255.0f;

        this.rwLightColors[2].r = 255.0f / 255.0f;
        this.rwLightColors[2].g = 214.0f / 255.0f;
        this.rwLightColors[2].b = 170.0f / 255.0f;

        this.rwLightColors[3].r = 255.0f / 255.0f;
        this.rwLightColors[3].g = 241.0f / 255.0f;
        this.rwLightColors[3].b = 224.0f / 255.0f;

        this.rwLightColors[4].r = 255.0f / 255.0f;
        this.rwLightColors[4].g = 250.0f / 255.0f;
        this.rwLightColors[4].b = 244.0f / 255.0f;

        this.rwLightColors[5].r = 255.0f / 255.0f;
        this.rwLightColors[5].g = 255.0f / 255.0f;
        this.rwLightColors[5].b = 251.0f / 255.0f;

        this.rwLightColors[6].r = 201.0f/255.0f;
        this.rwLightColors[6].g = 226.0f/255.0f;
        this.rwLightColors[6].b = 255.0f/255.0f;

        this.rwLightColors[7].r = 64.0f/255.0f;
        this.rwLightColors[7].g = 156.0f/255.0f;
        this.rwLightColors[7].b = 255.0f/255.0f;

    }


}
