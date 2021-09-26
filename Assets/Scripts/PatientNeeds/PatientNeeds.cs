using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientNeeds : MonoBehaviour
{
    // Start is called before the first frame update

    public bool debugMode;


    [SerializeField]
    GameObject patient;

    [SerializeField] GameObject patientPrefab;


    //public ItemType itemType;


    [Tooltip("This is the logic of the player")]
    private Player player;


    private Spawner spawnerInfo;

    private int i;

    [SerializeField]
    Vector3 platformOffset;

    [SerializeField]
    private SpriteRenderer itemSprite;

    private int randomInt;

    public ItemDataContainer[] items;


    public ItemDataContainer item;

    [SerializeField]
    private AudioSource audioSource;

    private ScoreManager scoreManager;


    [SerializeField]
    private GameObject fireEffect;

    private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = fireEffect.GetComponent<ParticleSystem>();

        i = Random.Range(0, items.Length);

        item = items[i];
    }

    
    void Start()
    {
        particleSystem.Stop();
        SpawnPatient();

        StartCoroutine(FindComponents());
    }


    IEnumerator FindComponents()
    {

        player = FindObjectOfType<Player>();

       

      

        audioSource = GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
        //assigning random need for item
        ItemType itemType = (ItemType)Random.Range(0, System.Enum.GetValues(typeof(ItemType)).Length);

        //assigning random need for item 
        // itemType = (ItemType)Random.Range(0, System.Enum.GetValues(typeof(ItemType)).Length);


        yield return new WaitForEndOfFrame();

    }
 
    public void SpawnPatient()
    {

        if (debugMode)
        {
            print("patient spawned in " + transform.name);
        }



        StartCoroutine(TurnOffFlames());
        particleSystem.Play(true);

        patient = Instantiate(patientPrefab, this.transform);
        patient.transform.position = transform.position + platformOffset;
        SetItem();
    }

   
    IEnumerator TurnOffFlames()
    {
       
        yield return new WaitForSeconds(3);
        particleSystem.Stop();
    }
    public float timeRemaining = 20;

    private void Update()
    {
        if(randomInt <= 4)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining < 0)
        {
            Destroy(patient);
            itemSprite.sprite = null;
            timeRemaining = 20;
            SpawnPatient();
            if (debugMode)
            {
                Debug.Log("Zombie killed with timer");
               
            }
        }
    }
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


    //when the player enters the trigger of the item and item on the player is null
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && player.playerAction && player.item != null)
        {

            if(player.item == item)
            {
                if (debugMode)
                {
                    Debug.Log("The player is trying to save the patient");
                }

                audioSource.Stop();
                player.item = null;
                Destroy(patient);
             
                itemSprite.sprite = null;
                scoreManager.SetValue++;
                SpawnPatient();
            }
            else
            {

                player.item = null;
                audioSource.Stop();
                Destroy(patient);

                SpawnPatient();
                //   isOccupied = false;
                itemSprite.sprite = null;
                if (debugMode)
                {
                    Debug.Log("The player is using the wrong item");
                }
            }


        }
    }
}
