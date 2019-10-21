using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollution : MonoBehaviour
{

    [SerializeField] float fogAmount = 0.0001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.fogDensity += fogAmount * Time.deltaTime;      //When suit enemy exists increase pollution fog
    }
}
