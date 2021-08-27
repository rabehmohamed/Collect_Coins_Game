using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    public GameObject[] Objprefab;
    private float spawnposz = -7.55f;
    private float spawnposz2 = 88f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnrandomOb", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnrandomOb ()
    {
        Vector3 spawnpos = new Vector3(-0.01f, 0.02f, Random.Range(spawnposz, spawnposz2));
        int index = Random.Range(0, Objprefab.Length);
        Instantiate(Objprefab[index], spawnpos, Objprefab[index].transform.rotation);
    }
}
