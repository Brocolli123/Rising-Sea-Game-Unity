using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private ParticleSystem deathParticles;
    private bool isDead;
    private int timer = 0;
    private Vector3 posX;

    // Start is called before the first frame update
    void Start()
    {
        deathParticles = GetComponent<ParticleSystem>();
        ScoreManager.score = 0;     //reset on new game (first person controller not got access to score manager)

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            deathParticles.Play();
            if (Time.timeScale < 0.01f)
            {
                deathParticles.Simulate(Time.unscaledDeltaTime, true, false);       //to play particles when timescale is 0
                //gameObject.transform.rotation = Quaternion.Euler(-90 * Time.unscaledDeltaTime, 0, 0);   //rotate when timescale is 0
                //while (gameObject.transform.rotation.x > -90)      //&& gameObject.transform.position.y >= 0          (While causes infinite loop)
                //while (timer <= 90)                   (this just makes the rotation happen instantly
                //{
                if (timer <= 90)                //TESTTESTESTESTESTESTESTESTESTESTESTSETSTETSTESTETSTESTESTES
                {
                    gameObject.transform.Rotate(Time.unscaledDeltaTime * -90, 0, 0);    //fall back     (Limit this to only going to far)           WORKS           
                    //posX -= 1 * Time.unscaledDeltaTime;                                                                
                    //gameObject.transform.Translate(0, Time.unscaledDeltaTime * -1, 0);  //fall down         //Not doing anything??
                    transform.localScale += new Vector3(0f, 0.1f, 0f) * Time.unscaledDeltaTime;    //shrink in y to fall down           //NOT DOING ANYTHING??
                    timer++;
                }
                //}
            }
        }

    }

    public void PlayDeathAnim()         //Called by GnomeoAIController
    {
        isDead = true;
    }
}
