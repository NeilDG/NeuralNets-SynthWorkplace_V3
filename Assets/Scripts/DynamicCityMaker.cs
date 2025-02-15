using System.Collections;
using System.Collections.Generic;
using FCG;
using UnityEngine;

public class DynamicCityMaker : MonoBehaviour
{
    [SerializeField] private CityGenerator cityGenerator;

    private int frames = DomainParameters.OFFSET;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.frames % DomainParameters.REFRESH_SCENE_PER_FRAME == 0)
        {
            this.frames = 0;
            this.GenerateNewCity();
        }

        this.frames++;

    }

    private void GenerateNewCity()
    {
        this.cityGenerator.GenerateStreetsVerySmall();

        float randomDowntownSize = Random.Range(25, 200);
        this.cityGenerator.GenerateAllBuildings(true, randomDowntownSize);

        GameObject.Find("City-Maker").transform.SetParent(this.transform);
    }
}
