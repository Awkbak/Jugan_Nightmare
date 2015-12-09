using UnityEngine;
using System.Collections;

public class InstructionsScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoBack()
    {
        Application.LoadLevel("Title");
    }
}
