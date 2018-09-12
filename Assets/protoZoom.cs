using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class protoZoom : MonoBehaviour {

	public float zoomSpeed;


	private Vector2 focusPoint;
	private Vector2 lastFocus;
	private float zoomAmount;
	private Camera cam;

	// Use this for initialization
	void Awake () {
		cam = GetComponent<Camera>();
		zoomAmount = cam.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		lastFocus = focusPoint;
		focusPoint = TobiiAPI.GetGazePoint().Viewport;
		if (Vector2.Distance(focusPoint,lastFocus)>.5f){
			zoomAmount=50;
		}else if (zoomAmount>5){
			zoomAmount-=Time.deltaTime*zoomSpeed;
		}
		cam.fieldOfView = Mathf.Lerp(cam.fieldOfView,zoomAmount,.2f);
	}
}
