using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	private Rect rect;
	private int tileType = -1;
	private GameObject tile = null;

	public Tile() {
		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool setRect(float width, float height, float coordX, float coordY) {
		if (width >= 0 && height >= 0) {
			rect.Set (coordX, coordY, width, height);
			return true;
		}

		return false;
	}

	public bool setRect(Vector2 newDim, Vector2 newCoord) {
		return setRect (newCoord.x, newCoord.y, newDim.x, newDim.y);
	}

	public bool setWidth(float width) {
		if (width >= 0) {
			rect.width = width;
			return true;
		}
		return false;
	}

	public bool setHeight(float height) {
		if (height >= 0) {
			rect.height = height;
			return true;
		}
		return false;
	}

	public bool setSize(float width, float height) {
		if (width >= 0 && height >= 0) {
			rect.width = width;
			rect.height = height;
			return true;
		}
		return false;
	}

	public bool setSize(Vector2 newSize) {
		return setSize (newSize.x, newSize.y);
	}

	public bool setCoord (float coordX, float coordY) {
		rect.x = coordX;
		rect.y = coordY;
		return true;
	}

	public bool setCoord (Vector2 newCoord) {
		return setCoord (newCoord.x, newCoord.y);
	}

	public void setType(int newType) {
		tileType = newType;
	}

	public int getType() {
		return tileType;
	}

	public Rect getRect() {
		return rect;
	}

	public float getWidth() {
		return rect.width;
	}

	public float getHeight() {
		return rect.height;
	}

	public Vector2 getSize() {
		return rect.size;
	}

	public float getX() {
		return rect.x;
	}

	public float getY() {
		return rect.y;
	}

	public Vector2 getPos() {
		return rect.position;
	}

	public void setGameObject(GameObject newTile) {
		tile = newTile;
	}

	public GameObject getGameObject() {
		return tile;
	}
}
