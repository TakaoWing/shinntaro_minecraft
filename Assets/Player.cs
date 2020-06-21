using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	float WaitTime;

	bool IsRun;//走っているかどうか
	bool IsRunning;


	public Rigidbody rb;//物理演算の変数
    public int jump_switch = 0;//ジャンプを切り替える変数
	// Start is called before the first frame update
	void Start()
	{
		IsRun = false;//最初は走っていないようにする
		IsRunning = false;
		WaitTime = 0f;

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			if (IsRunning == false)//もし走ってなかったら
			{
				rb.AddForce(transform.forward*20);//プレイヤーの向いている方向に力を加える
			}

			else if (IsRunning == true)//もし走ってたら
			{
				transform.position += transform.forward * 2.0f;//自分の位置を前に進める2.0f

                CancelInvoke("LaunchProjectile");//LaunchProjectileのInvokeをキャンセルする

			}

            if (Input.GetKeyUp(KeyCode.W))//wキーを離した時IsRunningをfalseにする
            {
				IsRunning = false;
			}
			


		}
        
		if (Input.GetKeyDown(KeyCode.W))//もしWキーを押している時
		{
			if (IsRun == true)
            {
				IsRunning = true;
            }

            IsRun = true;//走っているようにする

			Invoke("LaunchProjectile", 0.2f);

         }


		if ((Input.GetKey(KeyCode.Space))&&(jump_switch == 1))//もしスペースキーが押されたら＆もしjump_switchの変数が1だったら
		{
			rb.AddForce(0, 750, 0);//Y座標に750力を加える
			jump_switch = 0;//jump_switchの変数を0にする
		}

		

		if (Input.GetKey(KeyCode.S))//もしSキーが押されたら
		{
			transform.position -= transform.forward * 1f;//自分の位置を後ろに進める1.0f

		}

		if (Input.GetKey(KeyCode.D))//もしDキーが押されたら
		{
			transform.position += new Vector3(1, 0, 0);//自分の位置を右に進める1.0f

		}

		if (Input.GetKey(KeyCode.A))//もしAキーが押されたら
		{
			transform.position -= new Vector3(1, 0, 0);//自分の位置を左に進める1.0f
		}
	}


	void OnCollisionEnter(Collision collion)
	{
		Debug.Log("Hit");//この機能を確認するコメント
		jump_switch = 1;//jump_switchを1にする
    }

    void LaunchProjectile()

    {

		IsRun = false;




    }
}










