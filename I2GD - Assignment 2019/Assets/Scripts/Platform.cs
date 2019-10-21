using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    int direction = 1;
    bool playerlanded = false;


    // Update is called once per frame
    void Update()
    {
            transform.Translate(0, direction * Time.deltaTime, 0);  //To move up or down if timer isn't above limit
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
        {
            direction = -direction;     //flip direction
        }
    }

}
