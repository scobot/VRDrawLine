/*Unity 3D Codes for "Building Tilt Brush from Scratch" YouTube tutorial by Fuseman
https://www.youtube.com/watch?v=eMJATZI0A7c

He also uses code from Bartek Drozdz so I feel I should mention that (as I don't know who did what, I just transcribed the code!)
http://www.everyday3d.com/blog/index.php/2010/03/15/3-ways-to-draw-3d-lines-in-unity3d/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineManager : MonoBehaviour {

	public Material lMat;

	public SteamVR_TrackedObject trackedObj;

	//private LineRenderer currLine;
	private GraphicsLineRenderer currLine;

	private int numClicks = 0;
	
	// Update is called once per frame
	void Update () {
		SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {
			GameObject go = new GameObject (); 
			//currLine = go.AddComponent<LineRenderer> ();
			go.AddComponent<MeshFilter> ();
			go.AddComponent<MeshRenderer> ();
			currLine = go.AddComponent<GraphicsLineRenderer> ();

			currLine.lmat = lMat;

			//currLine.SetWidth (.1f, .1f);
			currLine.SetWidth (.1f);
			numClicks = 0;

		} else if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			//currLine.SetVertexCount (numClicks + 1);
			//currLine.SetPosition (numClicks, trackedObj.transform.position);

			currLine.AddPoint(trackedObj.transform.position);
			numClicks++;
		}
	}
}
