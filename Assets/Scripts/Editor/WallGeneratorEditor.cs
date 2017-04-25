using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WallGenerator))]
public class WallGeneratorEditor : Editor {
	public override void OnInspectorGUI () {
		base.OnInspectorGUI ();

		if (GUILayout.Button ("Create!")) {
			var generator = (WallGenerator)target;
			generator.Generate();
		}

		if (GUILayout.Button ("Clear!")) {
			var generator = (WallGenerator)target;
			generator.Clear();
		}
	}
}
