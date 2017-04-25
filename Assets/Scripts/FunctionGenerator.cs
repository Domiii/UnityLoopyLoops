using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// see: https://github.com/mariuszgromada/MathParser.org-mXparser
using org.mariuszgromada.math.mxparser;

[RequireComponent(typeof(LineRenderer))]
public class FunctionGenerator : MonoBehaviour {
	public string y = "sin(x^2)*x^2 / 10";
	public float xStart = -10;
	public float xEnd = 10;
	public float xStep = 0.01f;
	public float thickness = 0.1f;

	public void Generate () {
		// LineRenderer 
		var lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.widthMultiplier = thickness;
		lineRenderer.numPositions = Mathf.FloorToInt((xEnd - xStart) / xStep)+1;

		Function f = new Function("f(x) = " + y);
		var isValid = true;
		for (var i = 0; i < lineRenderer.numPositions; ++i) {
			var x = xStart + i * xStep;

			var height = (float)f.calculate(x);
			if (float.IsPositiveInfinity (height)) {
				// just make it very large
				height = 1e6f;
			} else if (float.IsNegativeInfinity (height)) {
				// just make it very small
				height = -1e6f;
			}

			if (float.IsNaN (height)) {
				isValid = false;
				lineRenderer.SetPosition (i, new Vector3 (x, 0, 0));
			} else {
				lineRenderer.SetPosition (i, new Vector3 (x, height, 0));
			}
		}

		if (!isValid) {
			print ("Could not evaluate function for all values of x. Make sure that your function expression is valid.");
		}
		//print (lineRenderer.numPositions - i);
	}

	/// <summary>
	/// Delete all children (bricks).
	/// 把所有的小孩都　｢清掉｣.
	/// </summary>
	public void Clear() {
		GetComponent<LineRenderer> ().numPositions = 0;
	}
}
