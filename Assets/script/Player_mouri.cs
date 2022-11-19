using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mouri : MonoBehaviour
{
    private Vector2 m_speed;
    private GameObject targetObject = null;
    private Statue_mouri statueScript = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //左右移動
        MoveX();
        //上下移動
        MoveY();

        transform.Translate(m_speed.x, m_speed.y, 0.0f);

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
            if (statueScript != null) {
                statueScript.Rotate();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Human")) {
        } else if (collision.gameObject.CompareTag("Statue")) {
            targetObject = collision.gameObject;
            statueScript = targetObject.GetComponent<Statue_mouri>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        targetObject = null;
        statueScript = null;
    }
}
