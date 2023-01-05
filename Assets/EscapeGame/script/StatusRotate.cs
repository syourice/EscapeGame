using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusRotate : MonoBehaviour
{
    private Player playerScript;

    private StatusSelect statusSelect;

    //方向を数値に直す
    private int m_directionNum = 0;

    private bool m_nameMatchFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        statusSelect = GameObject.Find("StatusSelect").GetComponent<StatusSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        //回転の値を0にする
        Vector3 Zero = new Vector3(0, 0, 0);

        //Debug.Log(playerScript.MoveLimit);

        if (this.transform.name == playerScript.GetObjectName())
        {
            m_nameMatchFlag = true;
        }
        for (int i = 0; i < 4; i++)
        {
            //カウントを0に戻す
            if (playerScript.GetRotateCount[i] <= 0)
            {
                //回転が1週したら
                if (transform.localEulerAngles.z >= 358.5f)
                {
                    //カウントを元に戻す
                    playerScript.GetRotateCount[i] = 4;
                    transform.localEulerAngles = Zero;
                }
            }
        }
        //正解のように何かで像を分けて判定するようにする
        //像のそれぞれの正解も上と同じやり方でやってみる

        //回転の制御の処理
        for (int i = 0; i < 4; i++)
        {
            if (playerScript.GetRoteStartFlag[i] == true)
            {
                //名前で像の判定をしている
                if (m_nameMatchFlag == true)
                {
                    //角度が90度毎に止るようにする      (1週(360度)から差し引いた答えが押した数×90度になるようにし、ちょうどの値だと360度の時に対応出来ないので少しだけ値を減らす)
                    if (transform.localEulerAngles.z <= (360.0f - (playerScript.GetRotateCount[i] * 90.0f)))
                    {
                        //回転処理から抜け出す
                        //半時計周りに回転する
                        transform.Rotate(new Vector3(0, 0, 10) * Time.deltaTime);
                        playerScript.MoveLimit = false;
                    }
                    else
                    {
                        //回転処理から抜け出す
                        //.playerScript.GetRoteStartFlag[i] = false;
                        m_nameMatchFlag = false;
                        playerScript.MoveLimit = true;
                    }
                }
            }
        }
    }

    public bool NameMatchFlag
    {
        get { return m_nameMatchFlag; }
        set { m_nameMatchFlag = value; }
    }
}