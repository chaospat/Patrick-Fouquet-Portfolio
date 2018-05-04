using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class PoliceTiles : MonoBehaviour
{
	[SerializeField]
	private GameObject[] tileObjectHazard;
	private GameObject tileObject;
	private BoxCollider2D canvasCollider;

	void Start()
	{
		canvasCollider = GetComponent<BoxCollider2D>();
		DrawTiledBackground();
	}

	void DrawTiledBackground()
	{
		tileObject = tileObjectHazard[Random.Range (0, tileObjectHazard.Length)];
		Vector2 canvasSize = canvasCollider.bounds.size;

		// instantiate one tile to measure its size, then destroy it
		Vector3 chose = new Vector3(0,0,10);
		var templateTile = Instantiate(tileObject, chose, Quaternion.identity) as GameObject;
		Vector3 tileSize = templateTile.GetComponent<Renderer>().bounds.size;

		float tilesX = canvasSize.x / tileSize.x;
		float tilesY = canvasSize.y / tileSize.y;
		Destroy(templateTile);

		// start placing tiles from the bottom left
		Vector3 bottomLeft = new Vector3(canvasCollider.transform.position.x - (canvasSize.x / 2), canvasCollider.transform.position.y - (canvasSize.y / 2),1);
		bool impair = false;
		float xModif = 0;
		for (int i=0; i <= tilesX; i++)
		{
			
			for (int j=0; j <= tilesY; j++)
			{
				if (impair)
					xModif = 0.3f;
				else
					xModif = 0f;
					
				impair = !impair;

				var newTilePos = new Vector3(xModif + bottomLeft.x + i * tileSize.x, bottomLeft.y + tileSize.y * j, 1.35f);
				var newTile = Instantiate(tileObject, newTilePos, Quaternion.identity) as GameObject;
				newTile.transform.parent = transform;
			}
		}
	}
}