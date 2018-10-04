using UnityEngine;

public class Paddle : MonoBehaviour
{
	public float paddleSpeed = 1f;

	private Vector3 playerPos = new Vector3(0, 3f, 0);
	private AudioSource audio;

	private void Start()
	{
		audio = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (Time.timeScale != 0)
		{
			float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
			playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), 3f, 0f);
			transform.position = playerPos;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		audio.Play();
	}
}
