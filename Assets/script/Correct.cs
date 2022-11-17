using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correct : MonoBehaviour
{
    //方向に番号を振ってその番号と照らし合わせて正解を見出す

    //方向を数値に直す
    private int m_directionNum = 0;

    [SerializeField]
    private int m_correctDirectio = 2; 

    private Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            //
            m_directionNum = playerScript.GetRotateCount[i];
        }
        //Debug.Log(playerScript.GetRotateCount);
        //貰ってきた番号と正解の番号を照らし合わせる
        //正解の番号 == 貰ってきた番号
        if (m_directionNum == m_correctDirectio)
        {
            Debug.Log("正解");
        }
    }
}
