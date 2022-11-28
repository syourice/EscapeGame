using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
     * ここでヒントの内容を選ぶ
     */

public class HumanBrain : MonoBehaviour
{
    //選ばれた成否をTextに渡す
    public CurrectData m_isSynapse;

    [SerializeField]//スクリクタブルオブジェクトデータ
    private List<CurrectData> m_currectData = new List<CurrectData>();

    //どのスクリクタブルオブジェクトデータを使うか
    private int m_n;

    public object CurrectDirection { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        //ランダムにデータを選ぶ
        m_n = Random.Range(0, 2);
        //選ばれた成否を渡す
        m_isSynapse = m_currectData[m_n];
    }

    //伝えるためにGet化
    public CurrectData GetIsSynapse()
    {
        return m_isSynapse;
    }
}
