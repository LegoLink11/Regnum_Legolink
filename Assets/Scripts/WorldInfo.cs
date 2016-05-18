using UnityEngine;
using System.Collections;

public class WorldInfo : MonoBehaviour {

	public float screenWidth;
	public float screenLength;
	public int currCameraPositionX;
	public int currCameraPositionY;


	public GameObject [,] regionCoords = new GameObject[25,25];

	void Start () 
	{

	}
	
	void Update()
	{
		var cameraPosition = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
		currCameraPositionX = Mathf.FloorToInt(cameraPosition.x/10);
		currCameraPositionY = Mathf.FloorToInt(cameraPosition.y/10);

		for(int x = -2+currCameraPositionX; x < (-2+currCameraPositionX)+5; x++)
		{
			for(int y = -2+currCameraPositionY; y < (-2+currCameraPositionY)+5; y++)
			{
				regionCoords[x,y].GetComponent<RegionInfo>().visible = true;
			}
		}
	}
}
	