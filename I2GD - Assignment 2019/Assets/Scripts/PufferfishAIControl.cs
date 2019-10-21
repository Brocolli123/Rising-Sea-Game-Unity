using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.Characters.FirstPerson;

public class PufferfishAIControl : MonoBehaviour
{
    private NavMeshAgent nav;
    private Vector3 playerTrans;
    private GameObject player;
    public ThirdPersonCharacter character { get; private set; } // the character we are controlling
    private bool growing;
    private float growTimer;

    private void Start()
    {
        character = GetComponent<ThirdPersonCharacter>();
        player = GameObject.FindWithTag("Player");     //Get player for chasing and killing
        nav = GetComponent<NavMeshAgent>();     //Get agent for movement

        nav.updateRotation = false;
        nav.updatePosition = true;

        nav.SetDestination(player.transform.position);   //set navmesh to move to player

        growing = false;
        growTimer = 0f;
 
    }

    void Update()
    {

        if (player != null)
        {
            playerTrans = player.transform.position;
            nav.SetDestination(playerTrans);       //move to player, constantly update

            // use the values to move the character
            character.Move(nav.desiredVelocity, false, false);

            if (Vector3.Distance(playerTrans, transform.position) < 4f)       //if is close enough to player
            {
                //Kamikaze();
                Grow();
            }
        }
        else
        {       //No player found
            // We still need to call the character's move function, but we send zeroed input as the move param.
            character.Move(Vector3.zero, false, false);
        }

        if (growing)
        {
            //Give more health
            character.Move(Vector3.zero, false, false);     //stays in place while growing
            // Grow the object by 0.01 each frame
            if (growTimer <= 5f)
            {
                transform.localScale += new Vector3(0.025f, 0.025f, 0.025f);
                growTimer += Time.deltaTime;
            }
        }
    }

    private void Grow()
    {
        growing = true;
    }

    private void Kamikaze()
    {
        player.GetComponent<PlayerDeath>().PlayDeathAnim();     //Change function
        Destroy(gameObject, 5f);        //Waits for animation to end (guess here) before destroying player    (doesn't disappear after killing player)
        GameManager.Instance.GameOver();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Kamikaze();
        }
    }

}
