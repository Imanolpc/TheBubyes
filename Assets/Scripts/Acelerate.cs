using UnityEngine;
using System.Collections;

public class Acelerate : MonoBehaviour {
	




	static bool gyroBool = true;
	private Gyroscope gyro;
	private Quaternion quatMult;
	private Quaternion quatMap;

	void Awake() {
	/*	// find the current parent of the camera's transform
		var currentParent = transform.parent;
		// instantiate a new transform
		var camParent = new GameObject ("Camera");
		// match the transform to the camera position
		camParent.transform.position = transform.position;
		// make the new transform the parent of the camera transform
		transform.parent = camParent.transform;
		// make the original parent the grandparent of the camera transform
		//camParent.transform.parent = currentParent;
		// instantiate a new transform
		var camGrandparent = new GameObject ("ARCamera");
		// match the transform to the camera position
		camGrandparent.transform.position = transform.position;
		// make the new transform the parent of the camera transform
		camParent.transform.parent = camGrandparent.transform;
		// make the original parent the grandparent of the camera transform
		camGrandparent.transform.parent = currentParent;*/

		// check whether device supports gyroscope
		#if UNITY_3_4
		gyroBool = Input.isGyroAvailable;
		#endif
		#if UNITY_3_5
		gyroBool = SystemInfo.supportsGyroscope;
		#endif

		if (gyroBool) {
			gyro = Input.gyro;
			gyro.enabled = true;
			#if UNITY_IPHONE
			camParent.transform.eulerAngles = Vector3(90,90,0);
			if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
			quatMult = Quaternion(0f,0,0.7071,0.7071);
			} else if (Screen.orientation == ScreenOrientation.LandscapeRight) {
			quatMult = Quaternion(0,0,-0.7071,0.7071);
			} else if (Screen.orientation == ScreenOrientation.Portrait) {
			quatMult = Quaternion(0,0,1,0);
			} else if (Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
			quatMult = new Quaternion(0,0,0,1);
			}
			#endif
			#if UNITY_ANDROID
			//camParent.transform.eulerAngles = Vector3(-90,0,0);
			if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
				quatMult = new Quaternion(0f,0,0.7071f,-0.7071f);
			} else if (Screen.orientation == ScreenOrientation.LandscapeRight) {
				quatMult = new Quaternion(0,0,-0.7071f,-0.7071f);
			} else if (Screen.orientation == ScreenOrientation.Portrait) {
				quatMult = new Quaternion(0,0,0,1);
			} else if (Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
				quatMult = new Quaternion(0,0,1,0);
			}
			#endif
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
		} else {
			#if UNITY_EDITOR
			//print("NO GYRO");
			#endif
		}
	}



	
	// Update is called once per frame
	void Update () {
		if (gyroBool) {
			#if UNITY_IPHONE
			quatMap = gyro.attitude;
			#endif
			#if UNITY_ANDROID
			quatMap = new Quaternion(gyro.attitude.w,gyro.attitude.x,gyro.attitude.y,gyro.attitude.z);
			#endif


			//camera.transform.Rotate(gyro.attitude.x,gyro.attitude.y,gyro.attitude.z);
		} 


		var xrot = Mathf.Atan2(Input.acceleration.z, Input.acceleration.y);
		var yzmag = Mathf.Sqrt(Mathf.Pow(Input.acceleration.y, 2) +                               
			Mathf.Pow(Input.acceleration.z, 2));     
		var zrot = Mathf.Atan2(Input.acceleration.x, yzmag);

		var xangle = xrot * (180 / Mathf.PI) + 180;
		var zangle = -zrot * (180 / Mathf.PI);
		//camera.transform.eulerAngles = new Vector3(xangle, yzmag, zangle);
	
	}

}
