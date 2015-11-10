using UnityEngine;
using System.Collections.Generic;

public class Unit : MonoBehaviour {
    public int type;
    public bool isMoved = false;

    public int[] getAttributes()
    {
        if (type == 0)
            return new int[] { 1, 1, 1 };
        else if(type == 1)
            return new int[] { 2, 1, 1 };
        else
            return new int[] { 0, 2, 2 };
    }
	// BLEIGHHHHH
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
