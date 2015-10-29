using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    public List<Transform> allNodes = new List<Transform>();
    public Transform environment;
    public Transform mainBase;
    public Transform selection;
    public Transform dan0;
    public Transform dan1;
    public Transform dan2;
    public Transform eff;
    public int available;
    private Transform select1;
    private Transform select2;

	// Use this for initialization
	void Start () {
        mainBase = environment.GetComponent<Game_Environment>().blueBase;
        selection = mainBase;
        available = 3;
        eff.transform.position = mainBase.transform.position;
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
                if(select1 != null)
                {
                    select2 = selection;
                    select2.GetComponent<Node>().allUnits.AddRange(select1.GetComponent<Node>().allUnits);
                    select1.GetComponent<Node>().allUnits.Clear();
                    int j = 1;
                    foreach(Transform i in select2.GetComponent<Node>().allUnits)
                    {
                        i.parent = select2;
                        i.position = new Vector3(select2.position.x, 0.1f + 0.1f * j, select2.position.z);
                        j++;
                    }
                    select1 = null;
                    select2 = null;
                }
                else
                {
                    select1 = selection;
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
        int x = mainBase.GetComponent<Node>().allUnits.Count;
        if (available > 0)
        {
            if (ID == 0)
            {
                Transform unit = Instantiate(dan0, new Vector3(mainBase.position.x, 0.1f + 0.1f * x, mainBase.position.z), transform.rotation) as Transform;
                unit.transform.SetParent(mainBase);
                mainBase.GetComponent<Node>().allUnits.Add(unit.transform);
            }
            else if (ID == 1)
            {
                Transform unit = Instantiate(dan1, new Vector3(mainBase.position.x, 0.1f + 0.1f * x, mainBase.position.z), transform.rotation) as Transform;
                unit.transform.SetParent(mainBase);
                mainBase.GetComponent<Node>().allUnits.Add(unit.transform);
            }
            else
            {
                Transform unit = Instantiate(dan2, new Vector3(mainBase.position.x, 0.1f + 0.1f * x, mainBase.position.z), transform.rotation) as Transform;
                unit.transform.SetParent(mainBase);
                mainBase.GetComponent<Node>().allUnits.Add(unit.transform);
            }
            available -= 1;
        }
    }
}

    