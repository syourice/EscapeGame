using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanTalk : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Text textbox;

    private Player playerScript;

    private string character = "";

    //ここでどのキャラクターに話しかけたか判定して
    //その判定にあうキャラのセリフをあてる

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        //
        character = playerScript.GetObjectName();
        if (playerScript.GetHumanFlag == true)
        {
            switch (character)
            {
                case "Human1":
                    textbox.text = "右";
                    break;
                case "Human2":
                    textbox.text = "左";
                    break;
                case "Human3":
                    textbox.text = "右";
                    break;
                case "Human4":
                    textbox.text = "右";
                    break;
                default:
                    textbox.text = "";
                    break;
            }
        }
    }
}
