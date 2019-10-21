using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    Vector3 position;
    public float fallspeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position = new Vector3(transform.position.x, transform.position.y - (Time.deltaTime * fallspeed), transform.position.z);
        transform.position = position;
    }
}
