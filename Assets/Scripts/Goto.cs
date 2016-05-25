using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Goto : MonoBehaviour {
	public string level;


	public void onClick(string scene){
		SceneManager.LoadScene (scene);
	}

}
