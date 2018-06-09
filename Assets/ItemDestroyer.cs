using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour {
    // Unityちゃんオブジェクト取得
    private GameObject unitychan;

    // Use this for initialization
    void Start() {
        this.unitychan = GameObject.Find("unitychan");
    }
	
	// Update is called once per frame
	void Update() {
        //[課題向け] Unityちゃんの後方(画面外)にオブジェクトが移動したら消す。
		if (this.transform.position.z <= unitychan.transform.position.z - 10)
        {
            Destroy(this.gameObject);
        }
	}

/*
    //[課題向け] 画面外にオブジェクトが移動したら消す。
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
*/
}
