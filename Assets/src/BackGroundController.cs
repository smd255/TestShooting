using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.3f, 0);
        if (transform.position.y  < ( mat.Y_MIN + 0.1f) )
        {
            transform.position = new Vector3(0, (mat.Y_MAX - 0.1f), 0);
        }
    }
}
