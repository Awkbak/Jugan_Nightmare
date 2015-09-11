using UnityEngine;
using System.Collections;

public class JuganNode : MonoBehaviour {

    public bool mainBase = false;
    public int team = 0;
    public int attack = 0;
    public int health = 1;
    public int shield = 0;
    public ArrayList JuganNodes = new ArrayList();
   

	// Use this for initialization
	void Start () {
        JuganNodes.Add(new JuganNode());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
