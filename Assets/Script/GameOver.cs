﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y <= -10)
		{
			DestroyObject(gameObject);
			Application.LoadLevel("GameOver");
		}
	}
}
