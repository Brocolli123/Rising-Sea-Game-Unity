using UnityEngine;
using System.Collections.Generic;

public class ShotgunCollision : MonoBehaviour {

    [SerializeField] private GameObject ragdollPrefab;
    [SerializeField] private float force;
    [SerializeField] private GameObject deathSounds;
    [SerializeField] private GameObject riseText;

    void OnTriggerEnter(Collider other)
    {
        // Replace the enemy with a ragdoll and add force to replicate knockback
        if(other.tag == "Enemy")
        {
            //if ()     //check for health, needs to check both gnomeo and pufferfish (a workaround to this?)
            GameObject rg = (GameObject)Instantiate(ragdollPrefab, other.transform.position, other.transform.rotation);

            // move the rigidbody up so it does not intersect with the ground collider on spawn (causes wierd behaviour otherwise)
            rg.transform.position = new Vector3(other.transform.position.x, 0.2f, other.transform.position.z);

            // Apply an explosive force to the ragdoll, propelling them upwards and away (because it looks better)
            float randomForce = Random.Range(force * 0.7f, force * 1.3f);
            rg.GetComponentInChildren<Rigidbody>().AddForce(-transform.forward * randomForce/2, ForceMode.Impulse);
            rg.GetComponentInChildren<Rigidbody>().AddForce(transform.up * randomForce, ForceMode.Impulse);

            Instantiate(deathSounds, other.transform.position, other.transform.rotation);       //Play random death sound
            Instantiate(riseText, other.transform.position, other.transform.rotation);     //instantiates at enemy position
            riseText.GetComponent<RisingScoreText>().setup(1, 5f, 10f);     //Sets up the text element

            Destroy(other.gameObject);
            Destroy(rg, 5);
          
            ScoreManager.IncreaseScore();       //increase score on enemy hit
        }        
    }

}
