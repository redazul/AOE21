using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject patientPrefab;
    public bool isOccupied = false;

    GameObject patient;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SpawnPatient()
    {
        print("patient spawned in " + transform.name);
        isOccupied = true;

        patient = Instantiate(patientPrefab, transform.parent);
        patient.transform.position = transform.position;
    }
}
