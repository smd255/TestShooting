using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //弾丸関係
    public GameObject PlayerBulletPrefab; //弾丸
    public const float bulletTIME = 0.15f; //連射間隔
    public float bulletTimer;             //タイマー

    // 爆発のPrefab
    public GameObject explosion;

    // 爆発の作成
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    // ぶつかった瞬間に呼び出される
    void OnTriggerEnter2D(Collider2D c)
    {
        // 弾の削除
        Destroy(c.gameObject);

        // 爆発する, 爆発先でゲームオーバー
        this.Explosion();
                
        // プレイヤーを削除
        Destroy(gameObject);
    }


    //▼▼▼フリック対応用▼▼▼
    Vector3 touchCurrentPos; //ポジション現在値
    Vector3 touchPastPos;    //ポジション前回値
    Vector3 PlayerPos;
    const float k = 0.02f;    //Pixel per Unit 1/50

    //string Direction;

    //タップ対応用
#if false

    private const float FlickValue = 30f; //フリック判定閾値

    int UDKey; //上下判定用
    int LRKey; //左右判定用
#endif

    float directionX;  //フリックx成分
    float directionY;  //フリックy成分

    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //押した瞬間に初期化
            touchCurrentPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);

            touchPastPos = touchCurrentPos; //押した瞬間は現在値=前回値
        }
#if false
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {


            touchPastPos = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Input.mousePosition.z);


    }
#endif

        //タップ有無
        if ( Input.GetKey( KeyCode.Mouse0 ) )
        {
            bulletTimer = bulletTimer + Time.deltaTime;

            if ( bulletTimer > bulletTIME ) //連射間隔以上
            { 
                Instantiate(PlayerBulletPrefab, transform.position, Quaternion.identity); //発射
                bulletTimer = 0f;
            }


            //現在値更新
            touchCurrentPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);

            GetDirection();

            //前回値更新
            touchPastPos = touchCurrentPos;
        }

    }

    void GetDirection()
    {
        PlayerPos = transform.position;
        directionX = touchCurrentPos.x - touchPastPos.x;
        directionY = touchCurrentPos.y - touchPastPos.y;
        
        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        { 
            transform.Translate(k * directionX, 0, 0); //左右移動

            //▼タップ対応用
#if false
            if (FlickValue < directionX)
            {
                //右向きにフリック
                Direction = "right";
            }
            else if (-FlickValue > directionX)
            {
                //左向きにフリック
                Direction = "left";
            }
#endif
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            transform.Translate(0, k * directionY, 0); //上下移動
        }
        else
        {
            //タッチを検出
            //Direction = "touch";
        }
        if ((Mathf.Abs(PlayerPos.x) > mat.X_MAX)
            || (Mathf.Abs(PlayerPos.y) > mat.Y_MAX))
        {
            //範囲内の位置に修正
            transform.position = mat.Utils.ClampPosition(PlayerPos);
        }
#if false
        switch (Direction)
        {
            case "up":
                //上フリックされた時の処理
                transform.Translate(0, directionY, 0);
                break;

            case "down":
                //下フリックされた時の処理
                UDKey = -1;
                break;

            case "right":
                //右フリックされた時の処理
                LRKey = 1;
                break;

            case "left":
                //左フリックされた時の処理
                LRKey = -1;
                break;

            case "touch":
                //タッチされた時の処理

                break;
            default:
                //処理なし
                break;
        }
#endif
    }

    //▲▲▲フリック対応用▲▲▲



    // Start is called before the first frame update
    void Start()
    {
        bulletTimer = 0f; //タイマー初期化


    }

    // Update is called once per frame
    void Update()
    {
        Flick();
    }
}

