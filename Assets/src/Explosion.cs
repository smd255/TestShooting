using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour
{
    void OnAnimationFinish()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver"); //ゲームオーバー　プレイヤー専用
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
