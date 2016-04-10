using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {

	List<Tile> tiles = new List<Tile> ();

	Rect area;

	public Map() {
		/*tileData = newTile;*/

		/*float left = float.MaxValue;
		float right = float.MinValue;
		float top = float.MaxValue;
		float bottom = float.MinValue;

		for (int i = 0; i < tileSet.Count; i++) {
			Tile tile = tileSet [i];

		}*/
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public float getWidth() {
		return area.width;
	}

	public float getHeight() {
		return area.height;
	}

	public List<Tile> getMap() {
		return tiles;
	}

	public void addTile (float[] data) {	

		Tile newTile = gameObject.AddComponent<Tile> ();

		float posX = data [0];
		float posY = data [1];
		float width = data [2];
		float height = data [3];
		int tileType = (int)data [4];

		newTile.setRect (
			posX,
			posY,
			width,
			height
		);

		newTile.setType (tileType);

		GameObject tileObject = (GameObject)Instantiate(Resources.Load("Prefabs/Cube"));
		tileObject.transform.position = new Vector2 (
			posX, posY
		);

		tileObject.transform.localScale = new Vector3 (
			width, height, 1
		);
		newTile.setGameObject (tileObject);

		tiles.Add (newTile);
	}

	public void refreshTiles() {
		for (int i = 0; i < tiles.Count; i++) {
			
		}
	}

	/*public bool removeTile(Tile deadTile) {
		return tiles.Remove (deadTile);
	}*/
}
