using UnityEngine;
using System.Collections;

public class BlockMove : MonoBehaviour
{
	Vector3 screenPoint;
	Vector3 offset;

	void Start()
	{


	}

	void Update()
	{

	}

	void OnMouseDown() // 마우스버튼이 클릭됬는지 알기위한 함수
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag() // 마우스를 드래그하기위한 함수
	{
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}

}



