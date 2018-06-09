using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    // Unityちゃんオブジェクト取得
    private GameObject unitychan;

    // carPrefabを入れる
    public GameObject carPrefab;

    // coinPrefabを入れる
    public GameObject coinPrefab;

    // cornPrefabを入れる
    public GameObject conePrefab;

    // スタート地点
    private int startPos = -160;

    // ゴール地点
    private int goalPos = 120;

    // アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //[発展課題向け] Itemが生成されるz方向の場所
    private float itemPos;

    // Use this for initialization
    void Start() {
        //[発展課題向け] オブジェクト初期化
        unitychan = GameObject.Find("unitychan");

        //[発展課題向け] Itemが生成されるのはUnityちゃんの前方40m
        itemPos = unitychan.transform.position.z + 40; 
/*    
        // 一定の距離ごとにアイテムを生成
        for (int i = startPos; i < goalPos; i += 15)
        {
            ItemCreation(i);
        }
*/
    }
	
	// Update is called once per frame
	void Update() {
        //[発展課題向け] 一定の距離ごとにアイテムを生成
        if (itemPos < goalPos)
        {
            if (itemPos <= unitychan.transform.position.z + 40)
            {
                // Itemを生成
                ItemCreation(itemPos);

                // 次のItemの生成場所を決定(Unityちゃんの前方40mに15m毎生成)
                itemPos += 15;
            }
        }
    }

    // Itemをランダムに生成する関数
    void ItemCreation(float PosZ) {
        // どのアイテムを出すのかをランダムに設定
        int num = Random.Range(0, 10);

        if (num <= 1)
        {
            // コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab) as GameObject;
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, PosZ);
            }
        }
        else
        {
            // レーンごとにアイテムを生成
            for (int j = -1; j < 2; j++)
            {
                // アイテムの種類を決める
                int item = Random.Range(1, 11);

                // アイテムを置くZ座標のオフセットをランダムに設定
                int offsetZ = Random.Range(-5, 6);

                // 60%コイン配置:30%車配置:10%何もなし
                if (1 <= item && item <= 6)
                {
                    // コインを生成
                    GameObject coin = Instantiate(coinPrefab) as GameObject;
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, PosZ + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    // 車を生成
                    GameObject car = Instantiate(carPrefab) as GameObject;
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, PosZ + offsetZ);
                }
            }
        }
    }
}
