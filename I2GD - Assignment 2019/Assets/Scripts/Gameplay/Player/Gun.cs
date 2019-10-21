using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    [SerializeField] private GameObject buckshotPrefab;

    [SerializeField] private Transform barrel;          //for shooting collision
    [SerializeField] private GameObject collisionCone;

    [SerializeField] private Vector3 sightVector;       //for shooting range
    [SerializeField] private float range;

    private AudioSource audioSource;    //sound
    private Animator anim;  //recoil animation

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

	void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            Fire();
            audioSource.Play();
        }
	}

    private void Fire()
    {
        // create the shooting particle effect
        GameObject emitter = (GameObject)Instantiate(buckshotPrefab);
        emitter.transform.SetParent(barrel, false);
        emitter.transform.localPosition = Vector3.zero;
        emitter.transform.localEulerAngles = Vector3.zero;
        Destroy(emitter, 2);

        anim.Play("Fire", -1, 0);

        // Create the collision cone to see if th enemies are inside the collider
        GameObject cone = (GameObject)Instantiate(collisionCone);
        cone.transform.SetParent(barrel, false);
        cone.transform.localPosition = Vector3.zero;
        cone.transform.localEulerAngles = Vector3.zero;
        Destroy(cone, 0.1f);
    }
}
