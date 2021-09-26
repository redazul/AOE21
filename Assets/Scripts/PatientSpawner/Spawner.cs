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



    private int randomInt;

    public ItemDataContainer[] items;


    public ItemDataContainer item;

    [SerializeField]
    Vector3 platformOffset;

    [SerializeField]
    private SpriteRenderer itemSprite;

    [SerializeField] GameObject spawnerManager;


    private AudioSource audioSource;

   

    private PatientSpawner patientSpawner;


    private ScoreManager scoreManager;


    private void SetItem()
    {
        randomInt = Random.Range(0, 6);
        if (randomInt <= 4)
        {
            i = Random.Range(0, items.Length);

            item = items[i];

            itemSprite.sprite = items[i].itemSprite;

            audioSource.Play();
        }
        else
        {
            item = null;
            int randomPic = Random.Range(0, items.Length);
            itemSprite.sprite = items[randomPic].itemSprite;

            itemSprite.sprite = null;
            StartCoroutine(KillZombie());
        }
    }

    private IEnumerator KillZombie()
    {
        audioSource.Stop();
        itemSprite.sprite = null;
        Destroy(patient);
        yield return new WaitForSeconds(Random.Range(4, 11));
    }
    void Start()
    {

        StartCoroutine(FindComponents());
    }


    IEnumerator FindComponents()
    {

        player = FindObjectOfType<Player>();

        patientSpawner = FindObjectOfType<PatientSpawner>();

        audioSource = GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
        //assigning random need for item 
        ItemType itemType = (ItemType)Random.Range(0, System.Enum.GetValues(typeof(ItemType)).Length);


        yield return new WaitForEndOfFrame();

    }
    public void SpawnPatient()
    {

        if (debugMode)
        {
            print("patient spawned in " + transform.name);
        }

       

        isOccupied = true;
        patient = Instantiate(patientPrefab, this.transform);
        patient.transform.position = transform.position + platformOffset;
        SetItem();
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



                audioSource.Stop();
                player.item = null;
                Destroy(patient);
                isOccupied = false;
                itemSprite.sprite = null;
                scoreManager.SetValue++;
                patientSpawner.SpawnCoroutine();

            }
            else
            {
                player.item = null;
                audioSource.Stop();
                Destroy(patient);
                isOccupied = false;
                itemSprite.sprite = null;
                if (debugMode)
                {
                    Debug.Log("The player is using the wrong item");
                }
            }


        }
    }

}
