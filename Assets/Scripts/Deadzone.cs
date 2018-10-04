using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour {

	private void OnTriggerEnter(Collider collision)
	{
		Destroy(GameObject.Find("Ball"));
		GameManager.instance.LoseLife();
	}
}
