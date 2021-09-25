using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{

    [Tooltip("This is the logic of the player")]
    private Player player;


    
    [SerializeField]
    private ItemDataContainer itemDataContainer = null;
    // Start is called before the first frame update
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && player.playerAction && player.item == null )
        {
            player.item = this;

        }
    }
}
