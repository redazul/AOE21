using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    bool debugMode;


    private Player player;

    void Start()
    {
        StartCoroutine(FindComponents());
    }


    IEnumerator FindComponents()
    {
        player = FindObjectOfType<Player>();


        yield return new WaitForEndOfFrame();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.playerInZone = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.playerInZone = false;
        }
    }

}
