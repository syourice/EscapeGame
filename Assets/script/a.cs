using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 ここでは入力判定を取る
 */

/*
 ここで像の回転の処理を書き直す
 */

public class a : MonoBehaviour
{
    private Vector2 m_speed;

    private bool m_keyFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        //if (m_movelimit == true)
        {
            //左右移動
            MoveX();
            //上下移動
            MoveY();

            m_keyFlag = true;

        }
        //else
        //{
        //    //何も無い
        //}
        //移動の結果を入れる
        transform.Translate(m_speed.x, m_speed.y, 0.0f);
        //if (this.gameObject.CompareTag("Status1"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_keyFlag = true;
                Debug.Log("回転");
            }
        }
    }

    void MoveX()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            m_speed.x = 0.01f;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            m_speed.x = -0.01f;
        }
        else
        {
            m_speed.x = 0;
        }
    }

    void MoveY()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            m_speed.y = 0.01f;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            m_speed.y = -0.01f;
        }
        else
        {
            m_speed.y = 0;
        }
    }

    public bool GetKeyFlag
    {
        get { return m_keyFlag; }
        set { m_keyFlag = value; }
    }
}
