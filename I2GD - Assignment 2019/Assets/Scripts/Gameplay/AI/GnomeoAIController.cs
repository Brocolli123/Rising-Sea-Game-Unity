using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.Characters.FirstPerson;

// We inherit the AICharacter Control object from UnityStandardAssets.Characters.ThirdPerson
public class GnomeoAIController : AICharacterControl {

    // overwrite the update function in AICharacterControl.cs
	void Update () {

        if (target != null)
        {
            agent.SetDestination(target.position);

            // use the values to move the character
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            // We still need to call the character's move function, but we send zeroed input as the move param.
            character.Move(Vector3.zero, false, false);
        }
        
        // check if the agent is near to the player
        if (Vector3.Distance(target.position, transform.position) < 1.5f)
        {
            Kamikaze();
        }
	}

    private void Kamikaze()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerDeath>().PlayDeathAnim();     //Change function
        Destroy(gameObject, 5f);        //Waits for animation to end (guess here) before destroying player
        GameManager.Instance.GameOver(); 
    }
}
