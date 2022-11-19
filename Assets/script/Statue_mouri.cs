using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue_mouri : MonoBehaviour
{
    bool isRotate = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotate() {
        if (!isRotate) {
            isRotate = true;
            StartCoroutine(RotateCoroutine());
        }
    }

    IEnumerator RotateCoroutine() {
        for (int turn = 0; turn < 90; turn++) {
            transform.Rotate(0, 0, -1);
            yield return new WaitForSeconds(0.05f);
        }
        isRotate = false;
    }
}
