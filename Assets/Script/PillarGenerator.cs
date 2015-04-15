using UnityEngine;
using System.Collections;

public class PillarGenerator : MonoBehaviour {

	public GameObject pillar;
	public float radius = 8;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");

		// z
		for (int f1=1; f1<= radius * 2; f1++)
		{
			// x
			for(int f2=1; f2<= radius *2; f2++)
			{
				Vector3 playerPos = new Vector3(Mathf.Floor(player.transform.position.x) , 0, Mathf.Floor(player.transform.position.z) );
				Vector3 blockPos = new Vector3(f1 - radius,0,f2 - radius) + playerPos;

				if(Vector3.Distance(blockPos, playerPos) <= radius)
				{
					Instantiate(pillar, blockPos, Quaternion.identity);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {


	}
}
