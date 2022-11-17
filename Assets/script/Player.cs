using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 m_speed;

    //アクションを起こしたか判断する
    //このフラグはプレイヤーが持つ
    private bool[] m_roteStartFlag = new bool[4];

    //アクションを起こした回数を記録する
    //private int m_rotateCount = 4;
    private int[] m_rotateCount = new int[4];

    private StatusSelect m_statusSelect;

    //aaaaa
    private bool m_actionFlag = false;
    //aaaaa
    private bool m_humanFlag = false;

    private string m_objectName = null;

    private bool m_movelimit = true;
    // Start is called before the first frame update
    void Start()
    {
        m_statusSelect = GameObject.Find("StatusSelect").GetComponent<StatusSelect>();
        for (int i = 0; i < 4; i++)
        {
            m_roteStartFlag[i] = false;
            //m_actionFlag = false;
            m_rotateCount[i] = 4;
        }
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
        }
        //else
        //{
        //    //何も無い
        //}

        //移動の結果を入れる
        transform.Translate(m_speed.x, m_speed.y, 0.0f);
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //アクションを起こす
                //回転
                if (m_actionFlag == true)
                {
                    //回転をスタートさせる
                    //for (int i = 0; i < 4; i++)
                    if (i == m_statusSelect.GetStutueNum())
                    {
                        m_roteStartFlag[i] = true;
                    }
                    else
                    {
                        m_roteStartFlag[i] = false;
                    }
                    //アクションを起こした数を記録する
                    m_rotateCount[i]--;
                }
            }
            //最後にはfalseにする
            m_actionFlag = false;
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

    //StatusRotateに使う
    public bool[] GetRoteStartFlag
    {
        get { return m_roteStartFlag; }
        set { m_roteStartFlag = value; }
    }

    //HumanTalkに使う
    public bool GetHumanFlag
    {
        get { return m_humanFlag; }
        set { m_humanFlag = value; }
    }

    //StatusRotateに使う
    public int[] GetRotateCount
    {
        get { return m_rotateCount; }
        set { m_rotateCount = value; }
    }

    //HumanTalkに使う
    //プレイヤーが当たったオブジェクトの名前を取得する
    public string GetObjectName()
    {
        return m_objectName;
    }

    public bool MoveLimit
    {
        get { return m_movelimit; }
        set { m_movelimit = value; }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            //アクション(会話)を起こす
            m_humanFlag = true;
            m_objectName = collision.transform.name;
        }
    }
}
