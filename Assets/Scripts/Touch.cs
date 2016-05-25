using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {
	public float speed = 0.1f;
	public TextMesh text;
	public Sprite spriteChange;
	// Use this for initialization
	void Start () {


	}
	protected void OnGUI()
	{
		
		text.text ="MultiTouchSupport: " + Input.multiTouchEnabled + "touch(es) detectados: " + Input.touchCount;


	}

	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			transform.Translate (2000, 2000, 0);
			GetComponent<SpriteRenderer>().sprite = spriteChange;

		}
	}
}
