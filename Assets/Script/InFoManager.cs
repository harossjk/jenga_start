using UnityEngine;
using System.Collections;
using System.IO;

public class InFoManager{

	private static InFoManager instance;

	public static InFoManager Instance
	{
		get
		{
			if (instance == null) instance = new InFoManager();
			return instance;
		}
	}


	private string m_strPath = "Assets/Resources/";

	public void WriteData(string dataName)
	{
		FileStream file = new FileStream(m_strPath + "Data.txt", FileMode.Append, FileAccess.Write);
		StreamWriter writer = new StreamWriter(file, System.Text.Encoding.Unicode);

		writer.WriteLine(dataName+",");

		writer.Close();
	}
	/*
	public bool textload()
	{
		bool istextload = false;
		TextAsset data = Resources.Load("Data", typeof(TextAsset)) as TextAsset;

		if (data == null)
			istextload = false;
		else
			istextload = true;

		return istextload;
	}

	public void Parse()
	{
		TextAsset data = Resources.Load("Data", typeof(TextAsset)) as TextAsset;
		StringReader sr = new StringReader(data.text);

		// 먼저 한줄을 읽는다. 

		string source = sr.ReadLine();
		Debug.Log("파일 읽는중 "+source);
		string[] values;                // 쉼표로 구분된 데이터들을 저장할 배열 (values[0]이면 첫번째 데이터 )


		while (source != null)
		{
			values = source.Split(',');  // 쉼표로 구분한다. 저장시에 쉼표로 구분하여 저장하였다.
			if (values.Length == 0)
			{
				sr.Close();
				return;
			}
			source = sr.ReadLine();    // 한줄 읽는다.
			Debug.Log("파일 읽는중 " + source);
		}
	}
	*/


}
