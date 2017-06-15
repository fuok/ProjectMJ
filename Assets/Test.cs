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
			
			/////////
			ShouPai pai = new ShouPai ();
			pai.QueTou.SetValue (100, 0);
			pai.QueTou.SetValue (101, 1);
//			pai.QueTou [2] = 102;
			
			pai.JianKe.Add (new int[]{ 1, 2 });
//			print ("haha" + pai.FengKe.Count);
		}

	}
}
