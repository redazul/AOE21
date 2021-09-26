using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedItems : MonoBehaviour
{

    public bool debugMode;

    public ItemDataContainer[] items;
    public bool itemPresent = false;

    SpriteRenderer itemSprite;

   // public ItemType itemType;


    private int i;

    public ItemDataContainer item;


    private Player player;

    [SerializeField]
    private GameObject fireEffect;

    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = fireEffect.GetComponent<ParticleSystem>();

        particleSystem.Stop();
        itemSprite = GetComponent<SpriteRenderer>();
        SpawnItem();
        StartCoroutine(FindComponents());
    }


    IEnumerator FindComponents()
    {
        player = FindObjectOfType<Player>();


        yield return new WaitForEndOfFrame();

    }
    public void SpawnItem()
    {
        i = Random.Range(0, items.Length);
        if (debugMode)
        {
            Debug.Log(items[i]);
        }

        particleSystem.Play(true);
        StartCoroutine(TurnOffFlames());
        itemSprite.sprite = items[i].itemSprite;

        item = items[i];
        itemPresent = true;

       
    }

    IEnumerator TurnOffFlames()
    {

        yield return new WaitForSeconds(3);
        particleSystem.Stop();
    }


    public float itemTimerDuration = 10f;
    private float itemTimer = 10f; 
    private void Update()
    {
        if(itemTimer > 0)
        {
            itemTimer -= Time.deltaTime;
        }
        if(itemTimer <= 0)
        {
            Debug.Log("Spawned Items with timer");
            SpawnItem();
            itemTimer = itemTimerDuration;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && player.playerAction && player.item == null)
        {
            player.item = item;
            itemPresent = false;
            itemSprite.sprite = null;

            StartCoroutine(SetItems());
          //  SpawnItem();
        }
    }


    private IEnumerator SetItems()
    {
        SpawnItem();
        yield return new WaitForSeconds(Random.Range(1, 5));
    }
}
