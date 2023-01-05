using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusSelect : MonoBehaviour
{
    private string m_statue = "";

    private Player playerScript;
    [SerializeField]
    private GameObject[] status = new GameObject[4];
    [SerializeField]
    private StatusRotate[] m_statusRotateScript = new StatusRotate[4];

    private int m_statueNum = 0;

    private bool m_actionFlag = false;

    private string m_objectName = null;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        for (int i = 0; i < 4; i++)
        {
            //Debug.Log(statusRotateScript[i]);
            //statusRotateScript[i] = GameObject.Find("Statue1");
            //statusRotateScript[i] = GameObject.Find("Statue"+i.ToString()).GetComponent<StatusRotate>();
            m_statusRotateScript[i] = status[i].GetComponent<StatusRotate>();
            m_statusRotateScript[i].enabled = true;
            //Debug.Log(status[i]);
            //status[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_statue = playerScript.GetObjectName();
        //Debug.Log(m_statue);

        for (int i = 0; i < 4; i++)
        {
            if (playerScript.GetRoteStartFlag[i] == true)
            {
                if (m_statusRotateScript[i] == false)
                { 

                }

                if (m_statue == "Statue" + (i + 1).ToString())
                {
                    Debug.Log("Statue" + (i + 1).ToString());
                    m_statusRotateScript[i].enabled = true;
                    m_statueNum = i;
                }
                else
                {
                    m_statusRotateScript[i].enabled = false;
                }
            }
            //Debug.Log(i + ":::" + m_statusRotateScript[i].enabled);            
        }
    }

    public int GetStutueNum()
    {
        return m_statueNum;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
            //アクション(回転)を起こす
            m_actionFlag = true;
            m_objectName = collision.transform.name;
        }
    }
}
