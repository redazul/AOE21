using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 10f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] GameObject model;

    void Start()
    {
       
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputY * -1, 0, inputX);
        movement.Normalize();

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if(movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        
    }
}
