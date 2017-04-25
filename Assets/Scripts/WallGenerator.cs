using UnityEngine;
using System.Collections;

public class WallGenerator : MonoBehaviour {
	public int nx = 10;
	public int ny = 10;
	public float Gap = 0.1f;
	public MeshRenderer brickPrefab;

	// Use this for initialization
	void Start () {
		if (transform.childCount == 0) {
			// create when starting, if no bricks have been added yet
			Generate ();
		}
	}

	public void Generate() {
		if (brickPrefab == null) {
			Debug.LogError ("Missing Brick Prefab. Make sure to prepare and assign a prefab for the bricks!");
			return;
		}

		// delete existing bricks first
		Clear ();

		// get brick size
		var bounds = brickPrefab.bounds;
		var brickW = bounds.extents.x * 2;
		var brickH = bounds.extents.y * 2;

		// build a bunch of bricks!
		for (var j = 0; j < ny; ++j) {
			for (var i = 0; i < nx; ++i) {
				// create brick
				var brick = Instantiate (brickPrefab, transform);

				// set position
				var x = i * (brickW + Gap) + Gap;
				var y = j * (brickH + Gap) + Gap;
				var pos = new Vector3 (x, y, 0);
				brick.transform.localPosition = pos;
			}
		}
	}

	/// <summary>
	/// Delete all children (bricks).
	/// 把所有的小孩都　｢清掉｣.
	/// </summary>
	public void Clear() {
		for (var i = transform.childCount-1; i >= 0; --i){
			DestroyImmediate(transform.GetChild(0).gameObject);
		}
	}
}