using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public GameObject breakParticle;
	private AudioSource audio;

	private void Start()
	{
		audio = GetComponentInParent<AudioSource>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		audio.Play();
		Instantiate(breakParticle, transform.position, Quaternion.identity);
		GameManager.instance.DestroyBrick();
		Destroy(gameObject);
	}
}
