using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool debugMode;

    [SerializeField] GameObject patientPrefab;
    public bool isOccupied = false;

    GameObject patient;



    /// <summary>
    /// 
    /// </summary>

    [Tooltip("This is the logic of the player")]
    private Player player;
    private int i;

    public ItemDataContainer[] items;


    public ItemDataContainer item;

    [SerializeField]
    Vector3 platformOffset;
    private void Awake()
    {
       
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
    public void SpawnPatient()
    {

        if (debugMode)
        {
          //  print("patient spawned in " + transform.name);
        }

       

        isOccupied = true;

        patient = Instantiate(patientPrefab, this.transform);
        patient.transform.position = transform.position + platformOffset;
    }


    //when the player enters the trigger of the item and item on the player is null
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && player.playerAction && player.item != null)
        {

            if (player.item == item)
            {
                if (debugMode)
                {
                    Debug.Log("The player is trying to save the patient");
                }

                player.item = null;
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
