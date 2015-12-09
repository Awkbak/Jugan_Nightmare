using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleScreen : MonoBehaviour {

    public Slider diff;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Game_Environment.setDifficulty(diff.value);
	}

    public void StartGame()
    {
        Application.LoadLevel("Okay");
    }

    public void GoToInstructions()
    {
        Application.LoadLevel("Instruct");
    }
}
