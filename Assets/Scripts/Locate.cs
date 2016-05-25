using UnityEngine;
using System.Collections;

public class Locate : MonoBehaviour
{
	public TextMesh Location_Text;
	// Use this for initialization
	void Start ()
	{
		Input.location.Start ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float latitud = Input.location.lastData.latitude;
		float longuitud = Input.location.lastData.longitude;
		Location_Text.text = "latitud =" + latitud + "\nlonguitud =" + longuitud ;
	
	}
}

