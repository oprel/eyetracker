using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class ObjectLook : MonoBehaviour {

    private GazeAware aware;

    private Vector3 baseScale;
    private Color baseCol;

	void Start () {
        aware = GetComponent<GazeAware>();
        baseScale = transform.localScale;
        baseCol = GetComponent<MeshRenderer>().material.color;
    }
	
	void Update () {
		if(aware.HasGazeFocus) {
            transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, baseScale.x * 2, Time.deltaTime * 2), Mathf.Lerp(transform.localScale.y, baseScale.y * 2, Time.deltaTime * 2), Mathf.Lerp(transform.localScale.z, baseScale.z * 2, Time.deltaTime * 2));
            GetComponent<MeshRenderer>().material.color = new Color(Mathf.Lerp(GetComponent<MeshRenderer>().material.color.r, baseCol.g, Time.deltaTime * 2), Mathf.Lerp(GetComponent<MeshRenderer>().material.color.g, baseCol.r, Time.deltaTime * 2), Mathf.Lerp(GetComponent<MeshRenderer>().material.color.b, baseCol.b, Time.deltaTime * 2));
        }
        else {
            transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, baseScale.x, Time.deltaTime * 2), Mathf.Lerp(transform.localScale.y, baseScale.y, Time.deltaTime * 2), Mathf.Lerp(transform.localScale.z, baseScale.z, Time.deltaTime * 2));
            GetComponent<MeshRenderer>().material.color = new Color(Mathf.Lerp(GetComponent<MeshRenderer>().material.color.r, baseCol.r, Time.deltaTime * 2), Mathf.Lerp(GetComponent<MeshRenderer>().material.color.g, baseCol.g, Time.deltaTime * 2), Mathf.Lerp(GetComponent<MeshRenderer>().material.color.b, baseCol.b, Time.deltaTime * 2));
        }
	}
}
