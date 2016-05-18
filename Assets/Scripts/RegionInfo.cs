using UnityEngine;
using System.Collections;

public class RegionInfo : MonoBehaviour {


	public GameObject[,] regionMap = new GameObject[512,512];
	public GameObject[,] regionTiles = new GameObject[10,10];
	public GameObject[] tileList = new GameObject[6];

	public int regionPositionX;
	public int regionPositionY;
	int prevNum = 0;
	public bool visible;
	public bool drawn;

	void Start ()
	{
		//Types of tiles
		tileList[0] = transform.parent.GetComponent<RegionCreator>().pfbGrassTile;	
		tileList[1] = transform.parent.GetComponent<RegionCreator>().pfbForestTile;
		tileList [2] = transform.parent.GetComponent<RegionCreator> ().pfbHillTile;
		tileList [3] = transform.parent.GetComponent<RegionCreator> ().pfbWaterTile;
		tileList [4] = transform.parent.GetComponent<RegionCreator> ().pfbSandTile;
		tileList [5] = transform.parent.GetComponent<RegionCreator> ().pfbDeepWaterTile;




		//If the x coordinate is less than 10...
		for(int x = 0; x < 10; x++)
		{
			//If the y coordinate is less than 10...
			for(int y = 0; y < 10; y++)
			{
				
				int random = 0;

				if (random < 0) {
					random = 0;
				} else if (random == 4 && prevNum != 3) {
					random = Random.Range (0, 2);
				} else if (random == 5 && prevNum != 5) {
					random = 1;
				} else if (random == 3 && prevNum == 3) {
					random = Random.Range (3, 4);
				} else if (random > tileList.Length) {
					random = tileList.Length;
				} else {
					random = Random.Range (0,tileList.Length);
				}
				regionMap[x,y] = tileList[random];
				prevNum = random;
			}
		}
	}

	void Update()
	{
		if(visible == true && drawn == false)
		{
			Draw();
		}
		else if(visible == false && drawn == true)
		{
			for(int x = 0; x < 10; x++)
			{
				for(int y = 0; y < 10; y++)
				{
					Destroy(regionTiles[x,y]);
				}
			}
			drawn = false;
		}
		if(visible == true && drawn == true)
		{
			CheckWhetherStillUpToDate();
		}
	}

	void Draw()
	{
		for(int x = 0; x < 10; x++)
		{
			for(int y = 0; y < 10; y++)
			{
				var curr = Instantiate(regionMap[x,y], new Vector3(regionPositionX*10+x, regionPositionY*10+y), Quaternion.identity) as GameObject;
				regionTiles[x,y] = curr;
			}
		}
		drawn = true;
	}

	void CheckWhetherStillUpToDate()
	{
		var worldInfo = transform.parent.GetComponent<WorldInfo>();
		if(regionPositionX > worldInfo.currCameraPositionX-2 || regionPositionX < worldInfo.currCameraPositionX+2 || regionPositionY > worldInfo.currCameraPositionY-2 || regionPositionY < worldInfo.currCameraPositionY+2)
		{
			visible = false;
		}
	}
}
