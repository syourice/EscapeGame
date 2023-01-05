using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_mouri : MonoBehaviour
{
    private Vector2 m_speed;

    // 触れているオブジェクトを格納しておく
    private GameObject m_targetObject = null;
    private Statue_mouri m_statueScript = null;

    // 移動可能かどうか
    private bool m_isMovable = true;
    public bool IsMovable {
        get { return m_isMovable; }
        set { m_isMovable = value; }
    }

    private string m_objectName = null;
    private bool m_humanFlag = false;

    // Update is called once per frame
    void Update()
    {
        // 移動可能でなければここでリターン
        if (!m_isMovable) 
            return;

        //左右移動
        MoveX();
        //上下移動
        MoveY();

        transform.Translate(m_speed.x, m_speed.y, 0.0f);
        
        // 銅像の回転命令
        Action();
    }

    void MoveX() {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            m_speed.x = 0.01f;
        } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            m_speed.x = -0.01f;
        } else {
            m_speed.x = 0;
        }
    }

    void MoveY() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            m_speed.y = 0.01f;
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            m_speed.y = -0.01f;
        } else {
            m_speed.y = 0;
        }
    }

    void Action() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (m_statueScript != null) {
                // 回転処理を実行する
                m_statueScript.Rotate();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Human")) {
            //アクション(会話)を起こす
            m_humanFlag = true;
            m_objectName = collision.transform.name;
        } else if (collision.gameObject.CompareTag("Statue")) {
            // 触れている銅像オブジェクトとそのスクリプトを取得
            m_targetObject = collision.gameObject;
            m_statueScript = m_targetObject.GetComponent<Statue_mouri>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        // 銅像から離れたら参照をnullにしておく
        m_targetObject = null;
        m_statueScript = null;
    }

    //HumanTalkに使う
    //プレイヤーが当たったオブジェクトの名前を取得する
    public string GetObjectName() {
        return m_objectName;
    }

    //HumanTalkに使う
    public bool GetHumanFlag {
        get { return m_humanFlag; }
        set { m_humanFlag = value; }
    }
}
