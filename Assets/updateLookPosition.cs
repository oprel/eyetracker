using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class updateLookPosition : MonoBehaviour {

	public Material[] dissolveMaterials;
	private Vector2 lastFocus;
	private Camera cam;
	// Use this for initialization
	
	private void Awake () {
		cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 focus = TobiiAPI.GetGazePoint().Screen;
		if (focus!=lastFocus){
			lastFocus = focus;
			Ray ray = cam.ScreenPointToRay(focus);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity)){
				Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
				foreach(Material m in dissolveMaterials){
					m.SetVector("_Center",hit.point);
				}
			}
            
		}
	}
}
