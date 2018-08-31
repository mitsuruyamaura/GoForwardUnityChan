using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    //  キューブの移動速度
    private float speed = -0.2f;

    //  消滅位置
    private float deadLine = -10;


    //　AudioSourceを格納する変数を宣言する
    private AudioSource se1;


	// Use this for initialization
	void Start () {

        //  AudionSourceコンポーネントを取得
        se1 = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {

        //  キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        //  画面外に出たら破棄する
        if ( transform.position.x < this.deadLine ){

            Destroy(gameObject);

        }

		
	}

    //  コリジョンモードでcubeTagオブジェクトと接触した場合
    void OnCollisionEnter2D(Collision2D other) {

        //  キューブか地面に接触したら音を鳴らす
        if (other.gameObject.tag == "cubeTag"|| other.gameObject.tag == "groundTag") { 

            se1.Play();
        }
    }
}
