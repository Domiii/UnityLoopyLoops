using UnityEngine;
using System.Collections;

public class LineGenerator : MonoBehaviour {
	// amount
	public int n = 10;

	// 每兩個 brick 之間的距離
	public float gap = 0.1f;

	// brick 的 Prefab
	public MeshRenderer brickPrefab;

	public void Generate() {
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
		var brickW = bounds.extents.x * 2;

		// add a bunch of bricks
		for (var i = 0; i < n; ++i) {
			// create brick
			var brick = Instantiate (brickPrefab, transform);

			// set position
			var x = i * (brickW + gap) + gap;
			var pos = new Vector3 (x, 0, 0);
			brick.transform.localPosition = pos;
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