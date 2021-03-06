﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {
    public int attack;
    public int health;
    public int shield;
    public int team = 0; //0 = neutral, 1 = blue, 2 = red.
    public bool mainbase = false;
    public Node f1, f2, b1, b2;
    public List<Transform> allUnits = new List<Transform>();
    float heuristic;

    public void addUnit(int t, Transform s)
    {
        if(t == team)
        {
            allUnits.Add(s);
        }else if(t == 0)
        {
            allUnits.Add(s);
            team = t;
        }

        updateMan();
    }

    public float getHeuristic()
    {
        //Use Attack, Defense, Health of node and ajacent nodes to calculate heurisitc
        return -1;
    }

    public void updateMan()
    {
        attack = 0;
        health = 0;
        shield = 0;

        foreach (Transform s in allUnits)
        {
            Unit k = s.GetComponent<Unit>();
            attack += k.attack;
            health += k.health;
            shield += k.defense;
        }
    }

    // Use this for initialization
    void Start () {
        attack = 0;
        health = 0;
        shield = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
