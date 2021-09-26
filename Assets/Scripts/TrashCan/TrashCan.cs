using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{

    public bool debugMode;
 
    [Tooltip("This is the logic of the player")]
    public Player player;



    void Start()
    {

        StartCoroutine(FindComponents());
    }


    IEnumerator FindComponents()
    {

        player = FindObjectOfType<Player>();
        yield return new WaitForEndOfFrame();
    }

        //when the player enters the trigger of the item and item on the player is null
        private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && player.GetComponent<Player>().playerAction && player.GetComponent<Player>().item != null)
        {

            if (player.GetComponent<Player>().item == null)
            {
                if (debugMode)
                {
                    Debug.Log("The player does not have an item");
                }

            }
            else
            {
                if (debugMode)
                {
                    Debug.Log("The player is getting rid of the item");
                }

                player.GetComponent<Player>().item = null;
            }


        }
    }
}
