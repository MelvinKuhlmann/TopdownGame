using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private float interpolateVelocity; // Possible elastic effect when camera moves with player
	private float cameraSpeed;
	private PlayerController player;
	private Vector3 targetPosition;

	public bool isFollowing { get; set; }

	private void Start()
	{
		targetPosition = transform.position;
		cameraSpeed = 1f;
		isFollowing = true;
	}

	private void FixedUpdate()
	{
		if (!player) return;
		if (!isFollowing) return;

		Vector3 position = transform.position;
		position.z = player.transform.position.z;

		Vector3 targetDirection = (player.transform.position - position);
		interpolateVelocity = targetDirection.magnitude * 5f;
		targetPosition = transform.position + (targetDirection.normalized * interpolateVelocity * Time.deltaTime);
		transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed);
	}

	public void SetPlayer(PlayerController player)
	{
		this.player = player;
	}
}
