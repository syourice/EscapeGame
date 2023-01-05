using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 銅像の回転に関する処理
/// </summary>

public class Statue_mouri : MonoBehaviour
{
    // 回転中か否かのイベント
    public event Action<bool> get_rotate;

    // 回転中か否か
    bool m_isRotate = false;
    // 何回転したかカウントする
    int m_rotateCount = 0;
    // オブジェクトの向きを格納する
    DirectionLabel m_direction = DirectionLabel.Up;
    
    // オブジェクトの向きを取得する
    public DirectionLabel Direction {
        get { return m_direction; }
    }

    // 回転の待ち時間
    [SerializeField, Range(0f, 0.1f)]
    private float m_rotateWaitTime = 0.0f;

    // 向き用ラベル
    public enum DirectionLabel {
        Up,
        Left,
        Down,
        Right
    }

    public void Rotate() {
        if (!m_isRotate) {
            // 回転中にする
            m_isRotate = true;
            // コルーチン実行
            StartCoroutine(RotateCoroutine());
        }
    }

    IEnumerator RotateCoroutine() {
        m_rotateCount += 1;
        // 値をtrueにして回転中にする
        get_rotate(true);
        for (int turn = 0; turn < 90; turn++) {
            // 1度ずつ回転(右回り:-1、左回り:1)
            transform.Rotate(0, 0, 1);
            // rotateWaitTimeで指定された秒数待機
            yield return new WaitForSeconds(m_rotateWaitTime);
        }
        // 回転終了にする
        m_isRotate = false;

        switch (GetDirection(m_rotateCount)) {
            case DirectionLabel.Up:
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                break;
            case DirectionLabel.Left:
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
                break;
            case DirectionLabel.Down:
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
                break;
            case DirectionLabel.Right:
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
                break;
        }
        // 値をfalseにして回転終了にする
        get_rotate(false);
    }

    // どの方向を向いているか取得する
    private DirectionLabel GetDirection(int rotateCount) {
        m_direction = (DirectionLabel)(rotateCount % 4);
        return m_direction;
    }
}
