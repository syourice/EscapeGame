using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * humanにヒントをしゃべらせる
 */
public class HumanTalk : MonoBehaviour
{
    [SerializeField]//画面に表示する
    UnityEngine.UI.Text textbox;
    
    private Player playerScript;

    private string character = "";

    [SerializeField]//スクリクタブルオブジェクトデータ
    private CurrectData[] currectData = new CurrectData[2];
    //どのスクリクタブルオブジェクトデータを使うか
    private int n;

    //ここでどのキャラクターに話しかけたか判定して
    //その判定にあうキャラのセリフをあてる

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        //ランダムにデータを選ぶ
        n = Random.Range(1, 3);
        Debug.Log(n);
    }

    void Update()
    {
        //humanの名前を取得
        character = playerScript.GetObjectName();
        //humanに触れたか
        if (playerScript.GetHumanFlag == true)
        {
            for (int i = 0; i < currectData.Length; i++)
            {
                //どのhumanに話を聞きに行ったか
                switch (character)
                {
                    case "Human1":
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
                        break;
                    default:
                        textbox.text = "";
                        break;
                }
            }
        }
    }
}
