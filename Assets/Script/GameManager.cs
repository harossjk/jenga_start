using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameManager
{
	private static GameManager instance;

	public static GameManager Instance
	{
		get
		{
			if (instance == null) instance = new GameManager();
			return instance;
		}
	}

	private List<GameObject> m_objectList = new List<GameObject>();

	public List<GameObject> GM_objectList
	{
		get { return m_objectList; }
		set { value = m_objectList; }
	}






}
