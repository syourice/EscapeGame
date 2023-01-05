using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 銅像の判定をするクラス
 */

public class Judgement
{
    private HumanBrain m_humanBrain;
    private Statue_mouri[] m_statueObjects;
    private int m_dataNum = 0;

    // コンストラクタ
    public Judgement(HumanBrain humanBrain, Statue_mouri[] statueObject) {
        m_humanBrain = humanBrain;
        m_statueObjects = statueObject;
        m_dataNum = m_statueObjects.Length;
    }

    // 判定
    public void Judge() {
        for (int i = 0; i < m_dataNum; i++) {
            if ((int)m_statueObjects[i].Direction != m_humanBrain.m_isSynapse.CorrectNum[i]) {
                Debug.Log("失敗");
                return;
            }
        }
        Debug.Log("成功");
    }
}
