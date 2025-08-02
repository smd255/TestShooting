using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject explosionPrefab;   //爆発エフェクトのPrefab
    GameObject ui;


    public float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Canvas");
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        //得点加算
        ui.GetComponent<UIController>().AddScore();

        // 爆発エフェクトを生成する	
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(coll.gameObject);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed, 0);

        if ( Mathf.Abs( transform.position.y ) > mat.Y_MAX )
        {
            Destroy(gameObject);
        }
    }
}
