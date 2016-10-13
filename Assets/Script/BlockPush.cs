using UnityEngine;
using System.Collections;

public class BlockPush : MonoBehaviour
{

	private bool m_push; // 블럭을 밀기위한 변수
	private Ray ray; // 레이저를 사용하기 위한 변수
	private RaycastHit hit; // 레이저가 어떤 물체에 부딛혔는지 판단하기위한 변수
	private GameObject m_cameraPos; // 카메라의 위치를 알기위한 변수
	private float m_speed = 0.1f; // 물체의 이동속도를 주기위한 변수, 이 변수값은 0.1f로 설정
	private GameObject blockPos; // 블럭의 위치를 알기위한 변수

	// Use this for initialization
	void Start()
	{
		m_cameraPos = GameObject.Find("Main Camera") as GameObject; //카메라의 위치를 알기위해서 m_camerPos 변수에 Main Camera를 불러와서 담음
		m_push = false; // m_push 값을 false로 설정

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(1)) // 물체가 레이저에 닫았는지 확인하기위해 마우스좌측버튼의 입력을 받았는지 확인함
		{

			ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 스크린상의 마우스 포지션을 ray에 담음
			if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // 레이저를 일직선으로 무한대로 쏴서 물체가 앞에 있는지 확인하기위한 조건문
			{
				if (hit.transform.gameObject == gameObject) // 레이저가 블럭에 닿았는지 확인
				{
					m_push = true; // 물체에 레이저가 닿았으면 위의 조건은 성립함
					blockPos = hit.transform.gameObject; // 블럭에 레이저가 닿은 블럭을 담아줌
				}
			}
		}
		if (m_push == true) // 레이저가 블럭에 닿았는지 확인함 (물체를 확인했다)
		{                   // 레이저와 블럭의 방향을 확인하여 블럭의 위치를 확인하여 마우스좌버튼 클릭시 화면이 바라보는 방향으로 블럭을 밀어내기위한 조건문
			if (blockPos == null) // 블럭이 마우스포지션에 없으면 이 조건을 타지 않고 빠져나온다
				return;           // 블럭이 없는 위치에 마우스좌버튼을 눌럿을때에도 프로그램이 오작동하지 않게하기위한 조건문

			Vector3 cameraPos = new Vector3(m_cameraPos.transform.position.x, // 카메라의 위치를 알기위해 vector3를 사용해 좌표값을 구함
											m_cameraPos.transform.position.y,
											m_cameraPos.transform.position.z);

			float deltaX = blockPos.transform.position.x - cameraPos.x; // 블럭을 x축으로 밀기위해 카메라와 블럭의 방향을 구함
			float deltaZ = blockPos.transform.position.z - cameraPos.z; // 블럭을 z축으로 밀기위해 카메라와 블럭의 방향을 구함

			if (blockPos.name == "block" && deltaX > 0) // 현재 블럭의 이름이 block이고 블럭을 x축으로 밀기위한 변수 델타가 0보다 크다면 조건성립
			{                                           // 블럭과 카메라의 방향을구해 블럭의 위치를 판단하고  x축으로 밀기위한 조건문

				Vector3 push = new Vector3(m_speed, 0.0f, 0.0f); // 블럭을 x축으로 m_speed(0.1f)의 속도로 밀기위한 변수를 만들었다
				Vector3 blockPosition = transform.position + push; // 블럭의 위치에 현재 블럭의위치와 x축으로 0.1f증가한값을 더해준 값을 넣어줌
				transform.position = blockPosition; // 현재 블럭의 위치에 위의 값을 넣어준다

			}
			else if (blockPos.name == "block" && deltaX < 0) // 위의 조건이 맞지않고 블럭의 이름이 block이고 x축으로 밀기위한 변수 델타가 0보다 작다면 조건성립
			{                                                // 블럭과 카메라의 방향을 구해 블럭의 위치를 판단하고 -x축으로 밀기위한 조건문

				Vector3 push = new Vector3(-m_speed, 0.0f, 0.0f); // 블럭을 -x축으로 m_speed(0.1f)의 속도로 밀기위한 변수
				Vector3 blockPosition = transform.position + push;// 
				transform.position = blockPosition; // 

			}
			else if (blockPos.name == "block_rotate" && deltaZ > 0) //위의 조건이 맞지않고 블럭의 이름이 block_rotate이고 델타가 0보다 크면 조건성립
			{                                                       // 블럭과 카메라의 방향을 구해 블럭의 위치를 판단하고 z축으로 밀기위한 조건문

				Vector3 push = new Vector3(0.0f, 0.0f, m_speed);
				Vector3 blockPosition = transform.position + push;
				transform.position = blockPosition;

			}
			else if (blockPos.name == "block_rotate" && deltaZ < 0) // 위의 조건이 맞지않고 블럭의 이름이 block_rotate이고 델타값이 0보다 작으면 조건성립
			{                                                       // 블럭과 카메라의 방향을 구해 블럭의 위치를 판단하고 -z축으로 밀기위한 조건문

				Vector3 push = new Vector3(0.0f, 0.0f, -m_speed);
				Vector3 blockPosition = transform.position + push;
				transform.position = blockPosition;

			}

		}

		if (Input.GetMouseButtonUp(1)) // 마우스좌측버튼을 누르지 않았을시 레이저가 물체의확인을 하지않게하기 위한 조건문
		{
			m_push = false; // 레이저가 쏘지 않으므로 위 스크립트는 작동하지않고 물체는 이동하지 않음
		}
	}
}
