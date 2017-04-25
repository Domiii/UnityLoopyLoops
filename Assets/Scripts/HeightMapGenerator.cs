using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightMapGenerator : MonoBehaviour {
	// 兩個地形，這個數值如果是一樣的話，會看到的樣子也是一樣的
	public int seed = 1;

	// length或長度或解析度，也就是 x 與 z 緯度有幾個格子
	public int length = 65;

	// 最高的高度
	public float height = 50;

	// 頻率
	public float frequency = 2f;

	public float[] layers = new float[] { 2, 4, 8, 16 };

	void Reset () {
		RandomizeSeed ();
		Clear ();
	}

	public void Generate () {
		// 首先清掉～
		Clear();

		// 取得地形的資料
		var terrain = GetComponent<Terrain> ();
		var terrainData = terrain.terrainData;

		// 我們用 heightMap 來存 length x length 個高度
		var heightMap = new float[length, length];

		// 開始算 length x length 個高度
		for (int x = 0; x < length; x++) {
			for (int z = 0; z < length; z++) {
				float worldX = transform.position.x + x;
				float worldZ = transform.position.z + z;

				heightMap [z, x] = GenerateHeight (worldX/length, worldZ/length);
			}
		}

		terrainData.SetHeights (0, 0, heightMap);
	}

	/// <summary>
	/// Generates the height at fractions of x and z.
	/// "Normalized" in this case means: That the smallest and biggest values of x should ideally have a distance of 1, and not more than 1
	/// Same goes for z.
	/// Example: If you want to create terrain from real-world coordinates x=1 to x=10, then you want to normalize in such a way that x=1 becomes 0 and 
	/// </summary>
	float GenerateHeight (float xFraction, float zFraction) {
		var h = 0.0f;

		for (int i = 0; i < layers.Length; i++) {
			var gain = layers [i];
			h += Mathf.PerlinNoise (seed + xFraction * gain * frequency, seed + zFraction * gain * frequency) * 1 / gain;
		}
		return h;
	}

	public void Clear () {
		// sanity checks!
		if (!Mathf.IsPowerOfTwo (length - 1)) {
			print("Height map size must equal: 1 + (a power of 2) - e.g. 33, 65, 127, 255, 511 etc.");
			length = Mathf.ClosestPowerOfTwo (length) + 1;
		}

		var terrainData = GetComponent<Terrain>().terrainData;
		terrainData.size = new Vector3 (length, height, length);
		terrainData.heightmapResolution = length;
	}

	public void RandomizeSeed () {
		seed = Random.Range (1, (int)1e5);
	}
}


