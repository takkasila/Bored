using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	GameObject player;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		offset = transform.position - player.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
	
	}
}
