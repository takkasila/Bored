using UnityEngine;
using System.Collections;

public class PillarHightTracker : MonoBehaviour {

	public float maxHeight = 5;
	public static float threshold = 1;
	public float factor = 0.01f;


	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = new Vector3(player.transform.position.x , 0, player.transform.position.z);
		
		float distance = Vector3.Distance(transform.position, playerPos);

		if(distance >= threshold)
		{
			transform.position = new Vector3(transform.position.x, factor*Mathf.Pow(distance - threshold, 2), transform.position.z);
			if(transform.position.y >= maxHeight)

				transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
		}
		else
		{
			transform.position = new Vector3(transform.position.x, 0, transform.position.z);

		}
	
	}
}
