using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    bool debugMode;
    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField]
    private float drawnRadius = 3;


    private Vector3 colliderSize;


    private bool playerInZone = false; 
    void Start()
    {
        //Use this to ensure that the Gizmos are being drawn when in Play Mode.
        debugMode = true;

        colliderSize = gameObject.GetComponent<BoxCollider>().bounds.extents * 2;
    }

    void FixedUpdate()
    {
        PlayerCollisions();


    }

    void PlayerCollisions()
    {
        //Use the OverlapBox to detect if there are any other colliders within this box area.
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, colliderSize, Quaternion.identity, playerLayer);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
      
        while (i < hitColliders.Length)
        {
            //Output all of the collider names
            Debug.Log("Hit : " + hitColliders[i].name + i);
            //Increase the number of Colliders in the array
            i++;
            if (Input.GetKey("space"))
            {
                Debug.Log("REssurect the zombies");
            }
        }
       
       
    }

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (debugMode)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
