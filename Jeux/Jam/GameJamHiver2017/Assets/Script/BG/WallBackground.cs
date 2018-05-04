using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class WallBackground : MonoBehaviour
{
	[SerializeField]
	private GameObject[] wallObjectHazard;
	private GameObject wallObject;
	private BoxCollider2D canvasCollider;

	void Start()
	{
		canvasCollider = GetComponent<BoxCollider2D>();
		DrawTiledBackground();
	}

	void DrawTiledBackground()
	{
		wallObject = wallObjectHazard[0];
		Vector2 canvasSize = canvasCollider.bounds.size;

		// instantiate one tile to measure its size, then destroy it
		Vector3 chose = new Vector3(0,0,10);
		var templateTile = Instantiate(wallObject, chose, Quaternion.identity) as GameObject;
		Vector3 tileSize = templateTile.GetComponent<Renderer>().bounds.size;

		float tilesX = 0;
		float tilesY = canvasSize.y / tileSize.y;
		Destroy(templateTile);

		// start placing tiles from the bottom left
		Vector3 bottomLeft = new Vector3(canvasCollider.transform.position.x - (canvasSize.x / 2), canvasCollider.transform.position.y - (canvasSize.y / 2),9);

		for (int i = 0; i <= tilesX; i++)
		{
			for (int j = 0; j <= tilesY; j++)
			{
				wallObject = wallObjectHazard[Random.Range (0, wallObjectHazard.Length)];
				var newTilePos = new Vector3(bottomLeft.x + tileSize.x, bottomLeft.y + tileSize.y * j, 9);
				var newTile = Instantiate(wallObject, newTilePos, Quaternion.identity) as GameObject;
				newTile.transform.parent = transform;
			}
		}
	}
}