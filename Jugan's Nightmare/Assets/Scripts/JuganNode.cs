﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JuganNode : MonoBehaviour {

    public bool mainBase = false;
    public int team = 0;
    public int attack = 0;
    public int health = 1;
    public int shield = 0;
    List<Unit_Properties> units = new List<Unit_Properties>();
   

	// Use this for initialization
	void Start () {
        units.Add(new Jugan_Hurts());
        units.Add(new Jugan_Hurts());
        units.Add(new Jugan_Average());
        units.Add(new Jugan_Turtle());
        units.Add(new Jugan_Turtle());
        foreach (Unit_Properties s in units)
        {
            attack += s.attack;
            health += s.health;
            shield += s.shield;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}