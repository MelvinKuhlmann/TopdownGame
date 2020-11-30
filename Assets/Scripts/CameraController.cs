using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private float interpVelocity;
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
		interpVelocity = targetDirection.magnitude * 5f;
		targetPosition = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
		transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed);
	}

	public void SetPlayer(PlayerController player)
	{
		this.player = player;
	}
}
