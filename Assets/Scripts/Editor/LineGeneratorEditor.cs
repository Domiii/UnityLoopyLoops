using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LineGenerator))]
public class LineGeneratorEditor : Editor {
	public override void OnInspectorGUI () {
		base.OnInspectorGUI ();

		if (GUILayout.Button ("Create!")) {
			var generator = (LineGenerator)target;
			generator.Generate();
		}

		if (GUILayout.Button ("Clear!")) {
			var generator = (LineGenerator)target;
			generator.Clear();
		}
	}
}
