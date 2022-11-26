using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager_mouri : MonoBehaviour
{
    [SerializeField]
    private Statue_mouri[] m_statusObjects;

    [SerializeField]
    private Player_mouri m_playerObject;

    private void Start() {

        // isRotate に bool の結果を受け取る。
        for (int i = 0; i< m_statusObjects.Length; i++) {
            m_statusObjects[i].get_rotate += isRotate => {
                if (isRotate) {
                    m_playerObject.IsMovable = false;
                } else {
                    m_playerObject.IsMovable = true;
                }
            };
        }
    }
}
