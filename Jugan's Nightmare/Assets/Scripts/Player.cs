using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public int availablePieces;
    public List<JuganNode> ownedNodes;
    public List<Unit_Properties> ownedUnits;
    public List<GameObject> moveUnits;
    public JuganNode mainBase;
    public Transform click1;
    public Transform click2;

    public Player()
    {
        availablePieces = 3;
        ownedNodes = new List<JuganNode>();
        ownedUnits = new List<Unit_Properties>();
        moveUnits = new List<GameObject>();
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
            GameObject a = Instantiate(GameObject.Find("Block Jugan"));
            
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

            stacking(a);
        }
    }

    public void assignDan()
    {
        
        
        if (availablePieces > 0)
        {
            GameObject a = Instantiate(GameObject.Find("Jugan"));
            
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

            stacking(a);
        }
    }

    public void assignCheetah()
    {
        
        
        if (availablePieces > 0)
        {
            GameObject a = Instantiate(GameObject.Find("Attack Jugan"));
            
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

            stacking(a);
        }
    }

    public void stacking(GameObject obj)
    {
        float height = ownedUnits.Count * .06f;
        moveUnits.Add(obj);
        obj.transform.position = new Vector3(mainBase.transform.position.x, height + .05f, mainBase.transform.position.z);
    }

    public void selectNode()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            Transform choose = GameObject.FindWithTag("select").transform;

            if (Physics.Raycast (ray, out hit, 100.0f))
            {
                if (hit.transform.gameObject.tag == "select")
                {
                    if (click1 != null)
                    {
                        click2 = hit.transform.gameObject.transform;
                    }
                    else
                    {
                        click1 = hit.transform.gameObject.transform;
                    }
                }
            }
        }
    }

    public void moving(Transform node1, Transform node2)
    {
        Transform[] moveKids = click1.GetComponentsInChildren<Transform>();

        for (int i = 0; i < moveKids.Length; i++)
        {
            moveKids[i].transform.parent = click2;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        selectNode();

        if (click2 != null)
        {
            moving(click1, click2);

            click1 = null;
            click2 = null;
        }
    }
}
