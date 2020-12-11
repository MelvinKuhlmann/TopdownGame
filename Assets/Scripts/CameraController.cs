using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
	private float interpolateVelocity; // Possible elastic effect when camera moves with player
	private float cameraSpeed;
	private Vector3 targetPosition;

	public Tilemap map;
	private Vector3 bottomLeftLimit;
	private Vector3 topRightLimit;

	private float halfHeight;
	private float halfWidth;

	public PlayerController player;

	public bool isFollowing { get; set; }

	private void Start()
	{
		targetPosition = transform.position;
		cameraSpeed = 1f;
		isFollowing = false;

		halfHeight = Camera.main.orthographicSize;
		halfWidth = halfHeight * Camera.main.aspect;

		if (map)
		{
			bottomLeftLimit = map.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
			topRightLimit = map.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);
		}

		SetPlayer();
	}

	private void FixedUpdate()
	{
		if (!player) return;
		if (!isFollowing) return;
		if (!map) return;

		Vector3 position = transform.position;
		position.z = player.transform.position.z;

		Vector3 targetDirection = (player.transform.position - position);
		interpolateVelocity = targetDirection.magnitude * 5f;
		targetPosition = transform.position + (targetDirection.normalized * interpolateVelocity * Time.deltaTime);
		transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed);

		//Keep camera inside the bounds
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
	}

	public void SetPlayer()
	{
		// prevents that the camera will jump to the player
		isFollowing = true;

		Debug.Log(player);
		//set the boundaries of the map to the player
		player.SetBoundaries(map.localBounds.min, map.localBounds.max);
	}
}
