using UnityEngine;
using System.Collections;

public class CreateEmptyObjects : MonoBehaviour {

	void Start () 
	{
		for(int i = 0; i < 100000; i++)
		{
			new GameObject("Yo");
		}
	}
	
	void Update () 
	{
	
	}
}
