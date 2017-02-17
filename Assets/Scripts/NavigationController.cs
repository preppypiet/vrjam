using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour {

	public Joystick Joystick;
	public GameObject Cockpit;
	// meters/second
	public float PlayerMoveSpeed = 15.0f;

	// Use this for initialization
	void Start () {
		
		Joystick.OnMove += OnPlayerMoved;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnPlayerMoved(Vector3 direction) {
		Cockpit.transform.position += direction * PlayerMoveSpeed * Time.deltaTime;
	}
}
