using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    //  アニメーションするためのコンポーネントを入れる
    Animator animator;

    //  Unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    //  地面の位置
    private float groundLevel = -0.3f;

    //　ジャンプの速度の減衰
    private float dump = 0.8f;

    //  ジャンプの速度
    float jumpVelocity = 50;

    //　ゲームオーバーになる位置
    private float deadLine = -9;


	// Use this for initialization
	void Start () {

        //  アニメータのコンポーネントを取得
        this.animator = GetComponent<Animator>();

        //  Rigidbody2Dのコンポーネントを取得
        this.rigid2D = GetComponent<Rigidbody2D>();

    
    }
	
	// Update is called once per frame
	void Update () {

        //  走るアニメーションを再生するためにAnimatorのパラメータを調整する
        this.animator.SetFloat("Horizontal", 1);

        //  着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround",isGround);

        //  ジャンプ状態のときにはボリュームを0にする
        //  isGroundがtrueの場合は音量を1、falseの場合は音量を0に判別する、
        //  AudioSourceコンポーネントを取得すると同時にvolume変数に音量の値を代入
        GetComponent<AudioSource>().volume = (isGround) ? 0.5f : 0;

        //  着地状態でクリックした場合
        if(Input.GetMouseButtonDown(0) && isGround){

            //  上方向のちからをかける
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);

        }

        //  クリックをやめたら上方向への速度を減衰する
        if (Input.GetMouseButtonUp(0) == false){
            if ( this.rigid2D.velocity.y > 0){
                this.rigid2D.velocity *= this.dump;
            }
        }

        //  デッドラインを超えた場合ゲームオーバーにする
        if (transform.position.x < this.deadLine ){

            //  UIControllerのGameOver関数を呼び出す
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //  Unityちゃんを破棄する
            Destroy(gameObject);

        }

	}
}
