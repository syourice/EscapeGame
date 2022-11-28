using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * humanにヒントをしゃべらせる
 */
public class HumanTalk : MonoBehaviour
{
    [SerializeField]//画面に表示する
    UnityEngine.UI.Text m_textbox;
    //選ばれた成否が入ってる
    private CurrectData m_humanBrain;
    
    private Player m_playerScript;
    //Humanの名前を入れる
    private string m_character = "";

    // Start is called before the first frame update
    void Start()
    {
        m_playerScript = GameObject.Find("Player").GetComponent<Player>();
        m_humanBrain = GameObject.Find("HumanDataBase").GetComponent<HumanBrain>().GetIsSynapse();
    }

    void Update()
    {
        //humanの名前を取得
        m_character = m_playerScript.GetObjectName();
        //humanに触れたか
        if (m_playerScript.GetHumanFlag == true)
        {
            for (int i = 0; i < 4; i++)
            {
                //どのhumanに話を聞きに行ったか
                switch (m_character)
                {
                    case "Human1":
                        m_textbox.text = m_humanBrain.CurrectDirection[0];
                        break;
                    case "Human2":
                        m_textbox.text = m_humanBrain.CurrectDirection[1];
                        break;
                    case "Human3":
                        m_textbox.text = m_humanBrain.CurrectDirection[2];
                        break;
                    case "Human4":
                        m_textbox.text = m_humanBrain.CurrectDirection[3];
                        break;
                    default:
                        m_textbox.text = "失敗";
                        break;
                }
            }
        }
    }
}
