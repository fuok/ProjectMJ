using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour
{

	public List<int> Mah;
	public int Ting;

	// Use this for initialization
	void Start ()
	{
	


	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnGUI ()
	{
		if (GUI.Button (new Rect (50f, 50f, 200f, 50f), "Check")) {
			Util.IsCanHU (Mah, Ting);
		}
	}
}
