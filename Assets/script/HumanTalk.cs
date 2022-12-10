using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * humanにヒントをしゃべらせる
 */
public class HumanTalk : MonoBehaviour
{
    [SerializeField]//画面に表示する
<<<<<<< HEAD
    UnityEngine.UI.Text textbox;
    
    private Player playerScript;

    private string character = "";

    [SerializeField]//スクリクタブルオブジェクトデータ
    private CurrectData[] currectData = new CurrectData[2];
    //どのスクリクタブルオブジェクトデータを使うか
    private int n;

    //ここでどのキャラクターに話しかけたか判定して
    //その判定にあうキャラのセリフをあてる
=======
    UnityEngine.UI.Text m_textbox;
    //選ばれた成否が入ってる
    private HumanBrain m_humanBrain;
    private CorrectData m_humanSynapse;
    private Player m_playerScript;
    //Humanの名前を入れる
    private string m_character = "";
>>>>>>> 2498e7c (変数名の修正 ヒント関連のスクリプトの改良)

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        //ランダムにデータを選ぶ
        n = Random.Range(1, 3);
        Debug.Log(n);
=======
        m_playerScript = GameObject.Find("Player").GetComponent<Player>();
        m_humanBrain = GameObject.Find("HumanDataBase").GetComponent<HumanBrain>();
        m_humanSynapse = m_humanBrain.GetIsSynapse();
>>>>>>> 2498e7c (変数名の修正 ヒント関連のスクリプトの改良)
    }

    void Update()
    {
        //humanの名前を取得
        character = playerScript.GetObjectName();
        //humanに触れたか
<<<<<<< HEAD
        if (playerScript.GetHumanFlag == true)
=======
        if (m_playerScript.GetHumanFlag == true
            & m_humanSynapse != null)
>>>>>>> 2498e7c (変数名の修正 ヒント関連のスクリプトの改良)
        {
            for (int i = 0; i < currectData.Length; i++)
            {
                //どのhumanに話を聞きに行ったか
                switch (character)
                {
                    case "Human1":
<<<<<<< HEAD
                        textbox.text = currectData[n].CurrectDirection[0];
                        break;
                    case "Human2":
                        textbox.text = currectData[n].CurrectDirection[1];
                        break;
                    case "Human3":
                        textbox.text = currectData[n].CurrectDirection[2];
                        break;
                    case "Human4":
                        textbox.text = currectData[n].CurrectDirection[3];
=======
                        m_textbox.text = m_humanSynapse.CorrectDirection[0];
                        break;
                    case "Human2":
                        m_textbox.text = m_humanSynapse.CorrectDirection[1];
                        break;
                    case "Human3":
                        m_textbox.text = m_humanSynapse.CorrectDirection[2];
                        break;
                    case "Human4":
                        m_textbox.text = m_humanSynapse.CorrectDirection[3];
>>>>>>> 2498e7c (変数名の修正 ヒント関連のスクリプトの改良)
                        break;
                    default:
                        textbox.text = "";
                        break;
                }
            }
        }
    }
}
