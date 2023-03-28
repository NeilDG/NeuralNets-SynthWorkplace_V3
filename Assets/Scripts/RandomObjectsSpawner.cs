using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class RandomObjectsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    private List<GameObject> spawnList = new List<GameObject>();

    [SerializeField] private float amount = 100;

    [Header("Positions")]
    [SerializeField] private float MIN_X = -10.0f;
    [SerializeField] private float MAX_X = 11.0f;
    [SerializeField] private float MIN_Y = -10.0f;
    [SerializeField] private float MAX_Y = 11.0f;
    [SerializeField] private float MIN_Z = -10.0f;
    [SerializeField] private float MAX_Z = 11.0f;

    [Header("Rotations")] 
    [SerializeField] private bool enableRotation = false;
    [SerializeField] private float MIN_ROT_X = -90.0f;
    [SerializeField] private float MAX_ROT_X = 90.0f;
    [SerializeField] private float MIN_ROT_Y = -90.0f;
    [SerializeField] private float MAX_ROT_Y = 90.0f;
    [SerializeField] private float MIN_ROT_Z = -90.0f;
    [SerializeField] private float MAX_ROT_Z = 90.0f;

    [Header("Scaling")]
    [SerializeField] private bool enableScaling = false;
    [SerializeField] private bool uniformScaling = true;

    [SerializeField] private float MIN_SCALE_X = 1.0f;
    [SerializeField] private float MAX_SCALE_X = 4.0f;
    [SerializeField] private float MIN_SCALE_Y = 1.0f;
    [SerializeField] private float MAX_SCALE_Y = 4.0f;
    [SerializeField] private float MIN_SCALE_Z = 1.0f;
    [SerializeField] private float MAX_SCALE_Z = 4.0f;



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < this.objects.Length; i++)
        {
            this.objects[i].SetActive(false);
        }

        Random.InitState(0);

        for (int i = 0; i < this.amount; i++)
        {
            int randomIndex = Random.Range(0, objects.Length);
            Vector3 randomSpawnPos = new Vector3(Random.Range(MIN_X, MAX_X), Random.Range(MIN_Y, MAX_Y), Random.Range(MIN_Z, MAX_Z));

            GameObject newObject = GameObject.Instantiate(this.objects[randomIndex], randomSpawnPos, Quaternion.identity);
            newObject.transform.parent = this.transform;
            newObject.SetActive(true);

            this.spawnList.Add(newObject);
        }

        this.Randomize();
    }

    // Update is called once per frame
    void Update()
    {
        this.Randomize();
    }

    private void Randomize()
    {
        for (int i = 0; i < this.spawnList.Count; i++)
        {
            GameObject newObject = this.spawnList[i];

            if (this.enableRotation)
            {
                Vector3 rotAngles = new Vector3(Random.Range(MIN_ROT_X, MAX_ROT_X), Random.Range(MIN_ROT_Y, MAX_ROT_Y), Random.Range(MIN_ROT_Z, MAX_ROT_Z));
                newObject.transform.localEulerAngles = rotAngles;
            }

            if (this.enableScaling)
            {
                Vector3 scale = new Vector3(Random.Range(MIN_SCALE_X, MAX_SCALE_X), Random.Range(MIN_SCALE_Y, MAX_SCALE_Y), Random.Range(MIN_SCALE_Z, MAX_SCALE_Z));

                if (this.uniformScaling)
                {
                    float value = Random.Range(MIN_SCALE_X, MAX_SCALE_X);
                    scale = new Vector3(value, value, value);
                }

                newObject.transform.localScale = scale;
            }
        }
    }
}
