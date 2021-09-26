using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool debugMode;

    [Header("Player Item Info ")]
    [Space(10)]
    [Tooltip("This bool is to determine if the player is within range of a gurney")]
    public bool playerInZone = false;

    [Header("Player Casting Values ")]
    [Space(10)]
    

    [SerializeField]
    private bool shotIsCooling;
    [SerializeField]
    private float coolDown = 1.0f;

    [Tooltip("This bool is to determine if the player is trying to use or pickup an item")]
    public bool playerAction = false;

    [Header("Item Info")]
    //start as null as player must pickup item
    public ItemDataContainer item = null;


    //player animations
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindComponents());
    }


    IEnumerator FindComponents()
    {
        anim = GetComponent<Animator>();


        yield return new WaitForEndOfFrame();

    }
    // Update is called once per frame
    void Update()
    {
        //turn action on  

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAction = true;


        }

        //turn action off 
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAction = false;
        }



        if (item != null && playerInZone)
        {
            if (debugMode)
            {
                Debug.Log("Player trying to save patient");
            }
        }

        //cooldwon to prevent over casting 
        if (shotIsCooling)
        {
            if (debugMode)
            {

                Debug.Log("Shoot is cooling down");
            }
            coolDown -= Time.deltaTime;
            if (coolDown <= 0)
            {

                coolDown = 1.0f;
                if (debugMode)
                {
                    Debug.Log(shotIsCooling);
                }

                shotIsCooling = false;
            }


        }
    }


  
}