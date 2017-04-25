using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FunctionGenerator))]
public class FunctionGeneratorEditor : Editor {
	public override void OnInspectorGUI () {
		base.OnInspectorGUI ();

		if (GUILayout.Button ("Create!")) {
			var generator = (FunctionGenerator)target;
			generator.Generate();
		}

		if (GUILayout.Button ("Clear!")) {
			var generator = (FunctionGenerator)target;
			generator.Clear();
		}
	}
}
