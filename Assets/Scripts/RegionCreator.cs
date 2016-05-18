using UnityEngine;
using System.Collections;
using System.IO;

public class RegionCreator : MonoBehaviour {

	public GameObject pfbGrassTile;
	public GameObject pfbForestTile;
	public GameObject pfbGrainTile;
	public GameObject pfbCenterTile;
	public GameObject pfbHouseTile;
	public GameObject pfbWaterTile;
	public GameObject pfbHillTile;
	public GameObject pfbSandTile;
	public GameObject pfbDeepWaterTile;



	private int numberOfRegions = 625;



	void Start () 
	{
		CreateRegions();
	}
	
	void CreateRegions()
	{
		for(int i = 0; i < numberOfRegions; i++)
		{
			var currRegion = new GameObject("Region" + i);
			currRegion.transform.SetParent(transform);
			currRegion.AddComponent<RegionInfo>();
			currRegion.GetComponent<RegionInfo>().regionPositionX = Mathf.FloorToInt(i%(Mathf.Sqrt(numberOfRegions)));
			currRegion.GetComponent<RegionInfo>().regionPositionY = Mathf.FloorToInt(i/(Mathf.Sqrt(numberOfRegions)));
			GetComponent<WorldInfo>().regionCoords[Mathf.FloorToInt(i%(Mathf.Sqrt(numberOfRegions))), Mathf.FloorToInt(i/(Mathf.Sqrt(numberOfRegions)))] = currRegion;
		}
	}
}
