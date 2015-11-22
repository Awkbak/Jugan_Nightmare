using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    public List<Transform> allNodes = new List<Transform>();
    public Game_Environment environment;
    public Node mainBase;
    public Transform selection;
    public Transform dan0;
    public Transform dan1;
    public Transform dan2;
    public Transform eff;
    public int available;
    private Transform select1;
    private Transform select2;
    private int moves;

	// Use this for initialization
	void Start () { 
        mainBase = environment.blueBase.GetComponent<Node>();
        selection = mainBase.transform;
        available = 3;
        eff.transform.position = mainBase.transform.position;
        moves = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("w"))
        {
            if(selection.GetComponent<Node>().f1 != null)
            {
                selection = selection.GetComponent<Node>().f1;
                eff.transform.position = selection.position;
            }
        }
        else if(Input.GetKeyDown("s"))
        {
            if(selection.GetComponent<Node>().f2 != null)
            {
                selection = selection.GetComponent<Node>().f2;
                eff.transform.position = selection.position;
            }
        }
        else if (Input.GetKeyDown("q"))
        {
            if (selection.GetComponent<Node>().b1 != null)
            {
                selection = selection.GetComponent<Node>().b1;
                eff.transform.position = selection.position;
            }
        }
        else if (Input.GetKeyDown("a"))
        {
            if (selection.GetComponent<Node>().b2 != null)
            {
                selection = selection.GetComponent<Node>().b2;
                eff.transform.position = selection.position;
            }
        }
        else if (Input.GetKeyDown("space"))
        {
            if(selection != null)
            {
                if (selection.childCount > 0)
                {
                    foreach(Transform i in selection.GetComponent<Node>().allUnits)
                    {
                        if (i.GetComponent<Unit>().isMoved == false)
                        {
                            moves++;
                            break;
                        }
                    }
                }

                if (moves > 0)
                {
                    if (select1 != null)
                    {
                        select2 = selection;
                        select2.GetComponent<Node>().allUnits.AddRange(select1.GetComponent<Node>().allUnits);
                        select1.GetComponent<Node>().allUnits.Clear();
                        int j = 1;
                        foreach (Transform i in select2.GetComponent<Node>().allUnits)
                        {
                            i.parent = select2;
                            i.position = new Vector3(select2.position.x, 0.1f + 0.1f * j, select2.position.z);
                            j++;
                            i.GetComponent<Unit>().isMoved = true;
                        }
                        select1 = null;
                        select2 = null;
                        moves--;
                    }
                    else
                    {
                        select1 = selection;
                    }

                    moves = 0;
                }
            }
        }
    }

    void move(Transform o, Transform n)
    {
        for(int i = 0; i < o.childCount; i++)
        {
            o.GetChild(i).SetParent(n);
        }
        n.GetComponent<Node>().allUnits = o.GetComponent<Node>().allUnits;
        o.GetComponent<Node>().allUnits.Clear();
    }

    void attack()
    {

    }

    public void assign(int ID) //LADIES AND GENTLEMEN, STEP RIGHT UP, CHOOSE YOUR UNITS. 0 for Balance, 1 for Offense, and last but NOT least, 2 for defense!
    {
        int x = mainBase.allUnits.Count;
        if (available > 0)
        {
            Transform t = mainBase.transform;
            if (ID == 0)
            {
                Transform unit = Instantiate(dan0, new Vector3(t.position.x, 0.1f + 0.1f * x, t.position.z), transform.rotation) as Transform;
                unit.transform.SetParent(mainBase.transform);
                mainBase.allUnits.Add(unit.transform);
            }
            else if (ID == 1)
            {
                Transform unit = Instantiate(dan1, new Vector3(t.position.x, 0.1f + 0.1f * x, t.position.z), transform.rotation) as Transform;
                unit.transform.SetParent(mainBase.transform);
                mainBase.allUnits.Add(unit.transform);
            }
            else
            {
                Transform unit = Instantiate(dan2, new Vector3(t.position.x, 0.1f + 0.1f * x, t.position.z), transform.rotation) as Transform;
                unit.transform.SetParent(mainBase.transform);
                mainBase.allUnits.Add(unit.transform);
            }
            available -= 1;
        }
    }
}

    