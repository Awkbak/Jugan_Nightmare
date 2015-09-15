using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public int availablePieces;
    public List<JuganNode> ownedNodes;
    public List<Unit_Properties> ownedUnits;
    public JuganNode mainBase;

    public Player()
    {
        availablePieces = 3;
        ownedNodes = new List<JuganNode>();
        ownedUnits = new List<Unit_Properties>();
        mainBase = new JuganNode();
    }

    public bool CheckMoved()
    {
        bool moveAll = true;
        
        ownedUnits.ForEach(delegate(Unit_Properties x)
        {
            if (x.moved == false)
            {
                moveAll = false;
            }
        });

        return moveAll;
    }

    public void assignTurtle()
    {
        if (availablePieces > 0)
        {
            Jugan_Turtle temp = new Jugan_Turtle();
            ownedUnits.Add(temp);
            mainBase.units.Add(temp);
            mainBase.attack = 0;
            mainBase.health = 0;
            mainBase.shield = 0;
            foreach (Unit_Properties s in mainBase.units)
            {
                mainBase.attack += s.attack;
                mainBase.health += s.health;
                mainBase.shield += s.shield;
            }
            availablePieces -= 1;
        }
    }

    public void assignDan()
    {
        if (availablePieces > 0)
        {
            Jugan_Average temp = new Jugan_Average();
            ownedUnits.Add(temp);
            mainBase.units.Add(temp); 
            mainBase.attack = 0;
            mainBase.health = 0;
            mainBase.shield = 0;
            foreach (Unit_Properties s in mainBase.units)
            {
                mainBase.attack += s.attack;
                mainBase.health += s.health;
                mainBase.shield += s.shield;
            }
            availablePieces -= 1;
        }
    }

    public void assignCheetah()
    {
        if (availablePieces > 0)
        {
            Jugan_Hurts temp = new Jugan_Hurts();
            ownedUnits.Add(temp);
            mainBase.units.Add(temp);
            mainBase.attack = 0;
            mainBase.health = 0;
            mainBase.shield = 0;
            foreach (Unit_Properties s in mainBase.units)
            {
                mainBase.attack += s.attack;
                mainBase.health += s.health;
                mainBase.shield += s.shield;
            }
            availablePieces -= 1;
        }
    }
}
