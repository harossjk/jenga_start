using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	private bool m_isFreeCam; // 휠버튼이 클릭이 됬는지 안됬는지 알기위한 변수선언
	private Vector3 m_mousePosPrev;  // 마우스휠버튼이 클릭된 지점을 알기위한 변수선언
	public float m_wheel_speed = 0.0f; // 마우스 휠을 굴렸을때 줌인,아웃의 값을 지정하기위한 변수선언
	private GameObject m_cameraPos; // 메인카메라를 쓰기위한 변수선언

	private const float m_cameraAnglePerFrame = 3.0f; // 카메라가 돌아가는 값을 3.0f로 지정

	// Use this for initialization
	void Start()
	{
		m_wheel_speed = 3.0f;  // 마우스 휠을 굴렸을때 줌인,아웃의 값을 3.0f로 지정
		m_isFreeCam = false; // 휠버튼의 초기설정을 눌리지 않았다고 지정함
		m_mousePosPrev = new Vector3(0.0f, 0.0f, 0.0f);  // 마우스의 처음 클릭된 곳의 좌표를 초기화 
		m_cameraPos = GameObject.Find("Main Camera") as GameObject; // 메인카메라를 불러옴
																	// GetAxis = 음수,양수 또는 좌우 또는 위아래를 정하는 함수 , -1~1 값만 가짐?

	}

	// Update is called once per frame
	void Update()
	{
		GameObject m_cameraPos = GameObject.Find("Main Camera") as GameObject; // 카메라를 제어하기위해 메인카메라를 불러와서 m_cameraPos변수에 담음
		if (Input.GetAxis("Mouse ScrollWheel") < 0) // 마우스스크롤을 입력받았는지 알기위한 조건문
		{
			Vector3 up = new Vector3(0, 0, -1.0f * m_wheel_speed); // 마우스휠을 -z축방향으로 1.0f의 속도로 돌림, 카메라가 마우스휠을 위로 돌렷을때 줌인되게 하기위한 변수 
			m_cameraPos.transform.Translate(up); // 카메라포지션이 확대되게한다

		}
		else if (Input.GetAxis("Mouse ScrollWheel") > 0) // 위 조건이 맞지않고 마우스스크롤을 입력받았는지 알기위한 조건문, 스크롤값이 0보다 클때
		{
			Vector3 down = new Vector3(0, 0, 1.0f * m_wheel_speed); // 마우스휠을 z축방향으로 1.0f의 속도로 돌림, 카메라가 마우스휠을 아래로 돌렸을때 줌아웃되게 하기위한 변수
			m_cameraPos.transform.Translate(down); // 카메라포지션이 축소되게 한다
		}


		if (Input.GetMouseButtonDown(2)) // 마우스휠을 누르면 조건성립
		{
			m_isFreeCam = true; // 프리캠이 트루이다, 즉 휠버튼이 눌렸다
			m_mousePosPrev = Input.mousePosition; // 마우스의 이전 포지션에 입력받은 마우스포지션을 넣어줌
			Debug.Log(m_cameraPos.transform.position); // 마우스의 현재 움직이는 포지션을 출력한다.
		}
		else if (Input.GetMouseButtonUp(2)) // 위의 조건에 부합하면, 마우스 휠버튼을 누르지 않았을때 조건성립
			m_isFreeCam = false; // 프리캠은 false

		if (m_isFreeCam) // m_isFreeCam이 눌렸을때 조건성립
		{
			Vector3 mousePosCur = new Vector3(0.0f, 0.0f, 0.0f); // 마우스를 클릭한점과 이동후의 마우스지점의 방향을 구하기위해 선언한 변수
			mousePosCur = Input.mousePosition; // 드래그후의 마우스지점의 값을 넣어줌

			float delta = mousePosCur.x - m_mousePosPrev.x; // 마우스를 클릭한점과 이동후의 마우스지점의 방향을 구하기 위한 변수 

			if (delta < 0) // 카메라를 좌우로 회전시키기위한 조건문
			{
				Vector3 angle = new Vector3(0.0f, delta * m_cameraAnglePerFrame, 0.0f); // 카메라앵글을 y축기준으로 좌측으로 돌리기위한 변수
				transform.Rotate(angle); // 카메라를 좌측으로 돌림
				m_mousePosPrev = Input.mousePosition; // 스크린상의 마우스포지션값을 m_mousePosPrev에 넣어줌

			}
			else if (0 < delta) // 위의 조건에 부합하고, 카메라를 좌우로 회전시키기위한 조건문
			{
				Vector3 angle = new Vector3(0.0f, delta * m_cameraAnglePerFrame, 0.0f); // 카메라앵글을 y축기준으로 우측으로 돌리기위한 변수
				transform.Rotate(angle); // 카메라를 우측으로 돌림
				m_mousePosPrev = Input.mousePosition; // 스크린상의 마우스포지션값을 m_mousePosPrev에 넣어줌

			}
		}
	}
}
