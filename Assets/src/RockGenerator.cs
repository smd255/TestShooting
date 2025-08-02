using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    public GameObject rockPrefab;
 

    // Start is called before the first frame update
    void Start()
    {
        //関数,?,リピートタイム
        InvokeRepeating("GenRock", 1, 0.8f);

    }

    void GenRock()
    {
        Instantiate(rockPrefab, new Vector3(-2.5f + 5 * Random.value, 5.5f, 0), Quaternion.identity);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
