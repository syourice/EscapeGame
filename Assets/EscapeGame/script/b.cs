using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ここで像が回転する処理を書く
/*
 ここでは像が一つ一つ回転する為の
分岐の処理を書いていく
Debug.Logで回転1、2を書いてそのなかの一つを
動かしてそれ以外は止る
 */

public class b : MonoBehaviour
{
    private a m_a;

    private bool[] m_playerTouchFlag = new bool[4];

    private 
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            m_playerTouchFlag[i] = false;
        }
        m_a = GameObject.Find("Player").GetComponent<a>();
    }

    // Update is called once per frame
    void Update()
    {
        //キーを押したかの判定
        if (m_a.GetKeyFlag == true)
        {
            if (this.gameObject.CompareTag("Statue1") ||
                m_playerTouchFlag[0] == true)
            {
                Debug.Log("回転1");
                m_a.GetKeyFlag = false;
            }

            else if (this.gameObject.CompareTag("Statue2") ||
                m_playerTouchFlag[1] == true)
            {
                Debug.Log("回転2");
                m_a.GetKeyFlag = false;
            }

            else if (this.gameObject.CompareTag("Statue3") ||
                m_playerTouchFlag[2] == true)
            {
                Debug.Log("回転3");
                m_a.GetKeyFlag = false;
            }

            else if (this.gameObject.CompareTag("Statue4") ||
                m_playerTouchFlag[3] == true)
            {
                Debug.Log("回転4");
                m_a.GetKeyFlag = false;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //アクション(会話)を起こす
            for (int i = 0; i < 4; i++)
            {
                m_playerTouchFlag[i] = true;
            }
            //m_objectName = collision.transform.name;
        }
    }
}
