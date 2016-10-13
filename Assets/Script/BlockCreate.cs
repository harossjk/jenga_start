using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class BlockCreate : MonoBehaviour
{
	private int interval = 3; // 블럭의 간격을 3으로 설정
	private int count = 0; // 블럭의 층수를 설정
	private float timeSpan; // !
	private float checkTime; // 몇초 간격으로 블럭을 생성할지 정함
	private int m_madeBlock = 0;


	// Use this for initialization
	private void Start()
	{
		//	gamelist = GameObject.Find("GameManager").GetComponent<GameManager>();
		timeSpan = 0.0f; // !
		checkTime = 1.0f; // 1초 간격으로 블럭을 생성
	}

	// Update is called once per frame
	private void Update()
	{
		if (count < 5) // 블럭의 층수를 지정하기 위한 조건문
		{
			timeSpan += Time.deltaTime; // !
			if (timeSpan > checkTime) // !
			{
				interval += 2; // 블럭의 간격을 2씩 더해줌

				Vector3 lf_block, cnt_block, ri_block, rotate; // 블럭을 각각의 위치에 쌓기위한 변수선언

				if (count % 2 == 0) // 블럭의 층수를 2로 나누었을때 나머지가 0이라면, 즉 블럭의 층이 짝수층일때의 조건문
				{
					lf_block = new Vector3(2.5f, interval, 0);  // lf_block블럭의 위치를 2.5, 3, 0에 지정
					cnt_block = new Vector3(0, interval, 0); // cnt_block블럭의 위치를 0,3,0에 지정
					ri_block = new Vector3(-2.5f, interval, 0); // ri_block블럭의 위치를 -2.5,3,0에 지정
					rotate = new Vector3(0, 90, 0); // 블럭을 y축으로 90도 방향으로 돌리기위한 변수선언

					blockCreate(lf_block, rotate); // lf_block블럭이 y축으로 90도 회전하여 생성
					blockCreate(cnt_block, rotate); // cnt_block블럭이 y축으로 90도 회전하여 생성
					blockCreate(ri_block, rotate); // ri_block블럭이 y축으로 90도 회전하여 생성
				}
				else // 위의 조건이 성립하지 않으면, 블럭의 층수가 홀수일때의 조건문
				{
					lf_block = new Vector3(0, interval, 2.5f); // lf_block블럭의 위치를 0,3,2.5에 지정
					cnt_block = new Vector3(0, interval, 0); // cnt_block블럭의 위치를 0,3,0에 지정
					ri_block = new Vector3(0, interval, -2.5f); // re_block블럭의 위치를 0,3,-2.5에 지정
					rotate = new Vector3(0, 0, 0); // 블럭을 0도 회전하여 생성 , 즉 블럭회전을 하지 않는다.

					blockCreate(lf_block, rotate); //지정된 위치에 블럭생성
					blockCreate(cnt_block, rotate); //지정된 위치에 블럭생성
					blockCreate(ri_block, rotate); //지정된 위치에 블럭생성

				}
				count++; // 블럭의 층수를 1층씩 증가
				timeSpan = 0; // !



				if (count == 5)
				{
					//Application.LoadLevel("Jenga");
				}


			}
		}

	}


	private void blockCreate(Vector3 createPos, Vector3 rotate) // 블럭을 생성하고 회전시키기 위한 함수
	{
		GameObject prefab_block = Resources.Load("Prefab/block") as GameObject; // 젠가 탑을 쌓기위해 프리팹에 저장되있는 블럭을 불러옴
		if (prefab_block == null) // 블럭이 없다면 실행불가
			return;
		GameObject block = MonoBehaviour.Instantiate(prefab_block) as GameObject;//자식
		block.transform.parent = this.transform;

		if (rotate.y == 90) //블럭을 회전시키기 위해 만든조건문, y축으로 90도 돌았다면
			block.name = "block_rotate"; // 블럭의 이름을 block_rotate로 한다
		else // 위의 조건에 부합하면, 블럭이 돌지 않았다면
			block.name = "block"; // 블럭의 이름을 block로 한다

		GameManager.Instance.GM_objectList.Add(block);
		//InFoManager.Instance.WriteData(GameManager.Instance.GM_objectList[m_madeBlock].name);

		//m_madeBlock++;

		block.transform.Rotate(rotate); // 블럭생성함수의 매개변수에서 받아온 값을 돌리겠다는 것
		block.transform.position = createPos; //블럭생성의 위치를 현재블럭에 넣음

	}

}

