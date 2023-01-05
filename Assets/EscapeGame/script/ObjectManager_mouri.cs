using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 銅像から回転中かの通知を受け取りプレイヤーに設定する
/// </summary>

public class ObjectManager_mouri : MonoBehaviour
{
    [SerializeField]
    private Statue_mouri[] m_statueObjects;

    [SerializeField]
    private Player_mouri m_playerObject;

    private void Start() {

        // isRotate に bool の結果を受け取る。
        for (int i = 0; i< m_statueObjects.Length; i++) {
            m_statueObjects[i].get_rotate += isRotate => {
                if (isRotate) {
                    m_playerObject.IsMovable = false;
                } else {
                    m_playerObject.IsMovable = true;
                }
            };
        }
    }
}
