using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StupidGenerator))]
public class StupidGeneratorEditor : Editor {
	public override void OnInspectorGUI () {
		base.OnInspectorGUI ();

		if (GUILayout.Button ("Create!")) {
			var generator = (StupidGenerator)target;
			generator.Generate();
		}

		if (GUILayout.Button ("Clear!")) {
			var generator = (StupidGenerator)target;
			generator.Clear();
		}
	}
}
