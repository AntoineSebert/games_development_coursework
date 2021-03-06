﻿using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;       //Public variable to store a reference to the player game object
	private Vector3 offset;         //Private variable to store the offset distance between the player and camera
	private Vector3 player_initial_position;
	public ParticleSystem ps;

	// Use this for initialization
	private void Start() {
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		player_initial_position = player.transform.position;
		offset = transform.position - player.transform.position;
	}

	// LateUpdate is called after Update each frame
	private void LateUpdate() {
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = player.transform.position + offset;

		if(player.transform.position.y < -40)
			reset_game();
	}

	private void reset_game() {
		player.transform.position = player_initial_position;
		transform.position = player.transform.position + offset;
		ps.Clear();
		ps.Play();
	}
}
