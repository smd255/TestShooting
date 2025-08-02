using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mat : MonoBehaviour
{
    public const float X_MAX = 2.7f;
    public const float X_MIN = -2.7f;
    public const float Y_MAX = 4.9f;
    public const float Y_MIN = -4.9f;



    //移動範囲の制限
    public static class Utils
    {
        // 移動可能な範囲
        public static Vector2 m_moveLimit = new Vector2(X_MAX, Y_MAX);

        // 指定された位置を移動可能な範囲に収めた値を返す
        public static Vector3 ClampPosition(Vector3 position)
        {
            return new Vector3
            (
                Mathf.Clamp(position.x, -m_moveLimit.x, m_moveLimit.x),
                Mathf.Clamp(position.y, -m_moveLimit.y, m_moveLimit.y),
                0
            );
        }
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
