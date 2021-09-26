using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientNeeds : MonoBehaviour
{
    // Start is called before the first frame update

    public bool debugMode; 
   

   

    //public ItemType itemType;


    [Tooltip("This is the logic of the player")]
    private Player player;


    private Spawner spawnerInfo;

    private int i;


    public ItemDataContainer[] items;


    public ItemDataContainer item;

    private void Awake()
    {
        spawnerInfo = GetComponent<Spawner>();

        i = Random.Range(0, items.Length);

        item = items[i];
    }

    void Start()
    {

        StartCoroutine(FindComponents());
    }


    IEnumerator FindComponents()
    {

        player = FindObjectOfType<Player>();


      
        //assigning random need for item 
       // itemType = (ItemType)Random.Range(0, System.Enum.GetValues(typeof(ItemType)).Length);


        yield return new WaitForEndOfFrame();

    }



    //when the player enters the trigger of the item and item on the player is null
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && player.playerAction && player.item != null)
        {

            if(player.item == item)
            {
                if (debugMode)
                {
                    Debug.Log("The player is trying to save the patient");
                }
            }
            else
            {
                if (debugMode)
                {
                    Debug.Log("The player is using the wrong item");
                }
            }


        }
    }
}
