using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIController : MonoBehaviour {

    public Game_Environment GE;
    public Player P;

    //holders
    private int pieces;
    private int health;
    private int attack;
    private int defense;

    //ui handling
    public Text piecesText;
    public Text healthText;
    public Text attackText;
    public Text defText;

    // Use this for initialization
    void Start () {
        pieces = 0;
        health = 0;
        attack = 0;
        defense = 0;

        toGUI();
	}
	
	// Update is called once per frame
	void Update () {

        Node s = P.selection.GetComponent<Node>();

        pieces = s.allUnits.Count;
        health = s.health;
        attack = s.attack;
        defense = s.shield;

        toGUI();
    }

    void toGUI()
    {
        //displaying to the ui
        piecesText.text = "Pieces: " + pieces.ToString();
        healthText.text = "Health: " + health.ToString();
        attackText.text = "Attack: " + attack.ToString();
        defText.text = "Defense: " + defense.ToString();
    }
}
