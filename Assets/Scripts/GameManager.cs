using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int lives = 3;
	public int bricks = 36;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public GameObject menu;

	public static GameManager instance = null;
	private GameObject clonePaddle;
	private bool menuActive;
	private float time;

	// Use this for initialization
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		Setup();
	}

	private void Update()
	{
		menuActive = menu.active;
		if (Input.GetButtonUp("Cancel") && menuActive == false)
		{
			time = Time.timeScale;
			Time.timeScale = 0.0f;
			menu.SetActive(true);
			menuActive = true;
		} else if (Input.GetButtonUp("Cancel") && menuActive == true) {
			menu.SetActive(false);
			menuActive = false;
			Time.timeScale = time;
		}
	}

	public void Setup()
	{
		clonePaddle = Instantiate(paddle, new Vector3(0f, 3f, 0f), Quaternion.identity) as GameObject;
		Instantiate(bricksPrefab, new Vector3(0f, 34f, 0f), Quaternion.identity);
	}

	void CheckGameOver()
	{
		if (bricks < 1)
		{
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke("Reset", resetDelay);
		}

		if (lives < 1)
		{
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke("Reset", resetDelay);
		}

	}

	void Reset()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Main");
	}

	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		//Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke("SetupPaddle", resetDelay);
		CheckGameOver();
	}

	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}

	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver();
	}
}