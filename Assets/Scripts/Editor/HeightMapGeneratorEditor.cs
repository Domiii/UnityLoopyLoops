using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HeightMapGenerator))]
public class HeightMapGeneratorEditor : Editor {
	public override void OnInspectorGUI () {
		base.OnInspectorGUI ();

		if (GUILayout.Button ("Create!")) {
			var generator = (HeightMapGenerator)target;
			generator.Generate();
		}

		if (GUILayout.Button ("Randomize + Create!")) {
			// pick new random seed and generate
			var generator = (HeightMapGenerator)target;
			generator.RandomizeSeed ();
			generator.Generate();
		}

		if (GUILayout.Button ("Clear!")) {
			var generator = (HeightMapGenerator)target;
			generator.Clear();
		}
	}
}
