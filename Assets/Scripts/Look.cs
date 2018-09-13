using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class Look : MonoBehaviour {
	void Start () {
	}
	
	void Update () {
        Vector2 pan = TobiiAPI.GetGazePoint().Viewport - new Vector2(0.5f, 0.5f);
        transform.localRotation = Quaternion.Euler(Mathf.LerpAngle(transform.localEulerAngles.x, -pan.y * 12, Time.deltaTime * 2), Mathf.LerpAngle(transform.localEulerAngles.y, pan.x*12, Time.deltaTime * 2), transform.localEulerAngles.z);
	}
}
