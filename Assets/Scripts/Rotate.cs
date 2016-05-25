using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public TextMesh RotationText;
	public float speed = 10.0F;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var xrot = Mathf.Atan2(Input.acceleration.z, Input.acceleration.y);
		var yzmag = Mathf.Sqrt(Mathf.Pow(Input.acceleration.y, 2) +                               
			Mathf.Pow(Input.acceleration.z, 2));     
		var zrot = Mathf.Atan2(Input.acceleration.x, yzmag);

		var xangle = xrot * (180 / Mathf.PI) + 180;
		var zangle = -zrot * (180 / Mathf.PI);
		transform.eulerAngles = new Vector3(xangle, 0, zangle);

		Vector3 dir = Vector3.zero;
		dir.x = -Input.acceleration.y;
		dir.z = Input.acceleration.x;
		if (dir.sqrMagnitude > 1)
			dir.Normalize();

		RotationText.text = "Rotation: " + string.Format("{0:0.00},{1:0.00}", xangle, zangle);
	}
}
