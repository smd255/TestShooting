using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockContoroller : MonoBehaviour
{
    //得点に応じて段階的に速度変化
    float fallSpeed;
    float rotSpeed;

    float fallSpeed2;
    float rotSpeed2;

    float fallSpeed3;
    float rotSpeed3;

    float TarningScore2;
    float TarningScore3;

    // Start is called before the first frame update
    void Start()
    {
        this.fallSpeed = 0.1f + 0.05f * Random.value;
        this.rotSpeed = 8f + 0.5f * Random.value;

        this.fallSpeed2 = 0.1f + 0.1f * Random.value;
        this.rotSpeed2 = 8f + 5f * Random.value;

        this.fallSpeed3 = 0.1f + 0.5f * Random.value;
        this.rotSpeed3 = 8f + 10f * Random.value;

        TarningScore2 = UIController.ScoreMax / 2;
        TarningScore3 = UIController.ScoreMax * 3 / 4;

    }

    // Update is called once per frame
    void Update()
    {
        if (UIController.score < TarningScore2)
        {
            transform.Translate(0, -fallSpeed, 0, Space.World);
            transform.Rotate(0, 0, rotSpeed);
        }
        else if (UIController.score < TarningScore3)
        {
            transform.Translate(0, -fallSpeed2, 0, Space.World);
            transform.Rotate(0, 0, rotSpeed2);
        }
        else
        {
            transform.Translate(0, -fallSpeed3, 0, Space.World);
            transform.Rotate(0, 0, rotSpeed3);
        }

        if (Mathf.Abs( transform.position.y ) > mat.Y_MAX + 1)
        {
            Destroy(gameObject);
        }
    }
}
