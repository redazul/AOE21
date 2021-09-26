using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] spawner;
    [SerializeField] float firstTimeWait = 3f; //Time before the first patient to spawn
    [SerializeField] float mandatoryWaitTime = 2f; //Mandatory wait time between two spawnings
    [SerializeField] int maxPatients = 3;
    bool hasToWait = false;
    bool isFirstTime = true;
    int patientsNum = 0;

    
    void FixedUpdate()
    {

        patientsNum = CountPatients();


        if (!hasToWait && patientsNum < maxPatients)
        {
            hasToWait = true;
            StartCoroutine(SpawnCoroutine());
        }

    }

    IEnumerator SpawnCoroutine()
    {
        if (isFirstTime)
        {
            yield return new WaitForSeconds(firstTimeWait);
            isFirstTime = false;
        }

        yield return new WaitForSeconds(mandatoryWaitTime);
        int spawnerNum = 0;
        bool canSpawn = false;
        while (!canSpawn)
        {
            spawnerNum = Random.Range(0, 6);
            if (spawner[spawnerNum].GetComponent<Spawner>().isOccupied == false)
                canSpawn = true;
        }

        spawner[spawnerNum].GetComponent<Spawner>().SpawnPatient();
        patientsNum++;
        hasToWait = false;
    }

    private int CountPatients()
    {
        int count = 0;
        foreach(GameObject i in spawner)
        {
            if (i.GetComponent<Spawner>().isOccupied == true)
                count++;
        }
        return count;
    }

}
