using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidGenerator : MonoBehaviour {
	// brick 的 Prefab
	public MeshRenderer brickPrefab;

	public void Generate () {
		// make sure, brickPrefab has been assigned
		// 確認 brickPrefab 有設定好
		if (brickPrefab == null) {
			Debug.LogError ("Missing Brick Prefab. Make sure to prepare and assign a prefab for the bricks!");
			return;
		}

		// delete existing bricks first
		// 刪除已有的 bricks
		Clear ();

		// get brick size
		var bounds = brickPrefab.bounds;
		var brickH = bounds.extents.y * 2;


		// for every brick: Instantiate, then set position
		var brick = Instantiate (brickPrefab, transform);
		brick.transform.localPosition = new Vector3 (0, 0 * brickH, 0);

		brick = Instantiate (brickPrefab, transform);
		brick.transform.localPosition = new Vector3 (0, 1 * brickH, 0);

		brick = Instantiate (brickPrefab, transform);
		brick.transform.localPosition = new Vector3 (0, 2 * brickH, 0);

		brick = Instantiate (brickPrefab, transform);
		brick.transform.localPosition = new Vector3 (0, 3 * brickH, 0);

		brick = Instantiate (brickPrefab, transform);
		brick.transform.localPosition = new Vector3 (0, 4 * brickH, 0);

		brick = Instantiate (brickPrefab, transform);
		brick.transform.localPosition = new Vector3 (0, 5 * brickH, 0);

		brick = Instantiate (brickPrefab, transform);
		brick.transform.localPosition = new Vector3 (0, 6 * brickH, 0);

		brick = Instantiate (brickPrefab, transform);
		brick.transform.localPosition = new Vector3 (0, 7 * brickH, 0);

		brick = Instantiate (brickPrefab, transform);
		brick.transform.localPosition = new Vector3 (0, 8 * brickH, 0);

		brick = Instantiate (brickPrefab, transform);
		brick.transform.localPosition = new Vector3 (0, 9 * brickH, 0);
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
