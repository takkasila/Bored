using UnityEngine;
using System.Collections;

public class PillarGenerator : MonoBehaviour {

	public GameObject pillar;
	public float radius = 8;
	float width, height;
	float rayDept = 10;
	GameObject player;

	void Start () {
		player = GameObject.FindWithTag("Player");
		width = pillar.transform.lossyScale.x;
		height = pillar.transform.lossyScale.z;
		// remember height != tall

		
	}
	
	// Update is called once per frame
	void Update () {

		proceduralMap();

		updateThreshold();
	}

	void proceduralMap()
	{
		Vector3 playerPos = new Vector3(Mathf.Round(player.transform.position.x) , 0, Mathf.Round(player.transform.position.z) );

		for (float z=0; z<= radius * 2; z+= width)
		{
			for(float x=0; x<= radius *2; x+= height)
			{
				Vector3 pillarPos = new Vector3(z - radius,0,x - radius) + playerPos;

				pillarPos.z += width/2f;
				pillarPos.x += height/2f;
				

				if(Vector3.Distance(pillarPos, playerPos) <= radius)
				{
					rayTracePillar(pillarPos);
				}
			}
		}
	}

	void rayTracePillar(Vector3 pos)
	{
		RaycastHit hitInfo;
		pos.y += rayDept;
		
		//Debug.DrawRay(pos, Vector3.down*13, Color.red, 0.2f, true);
		if(Physics.Raycast(pos, Vector3.down, out hitInfo, rayDept+3))
		{

		}
		else
		{
			//hit nothing
			pos.y -= rayDept;
			placePillar(pos);
		}
	}

	void placePillar(Vector3 pos)
	{
		//Todo : communicate with queue object pool
		Instantiate(pillar, pos, Quaternion.identity);

	}

	void updateThreshold()
	{
		if(Input.GetKey(KeyCode.L))
		{
			PillarHightTracker.threshold += 0.1f;

		}
		else if(Input.GetKey(KeyCode.K))
		{
			PillarHightTracker.threshold -= 0.1f;

		}
	}
}
