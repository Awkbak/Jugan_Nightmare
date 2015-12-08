using UnityEngine;
using System.Collections.Generic;

public class Computer : MonoBehaviour {
    public Node mainBase;
    public bool myturn;
    public List<Node> allNodes = new List<Node>();
    public Game_Environment environment;
    public Transform dan0;
    public Transform dan1;
    public Transform dan2;
    public int available;
    public float difficulty;
    private Transform select1;
    private Transform select2;
    private int availablemoves;
    float needAttack;
    float needDefense;

    void Start () {
        myturn = false;
        available = 3;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if it is my turn
        //add units to board until none are available
        //find the best move possible, use difficulty to change heuristic
        //move units according to best move
        //end turn
       if(myturn)
        {
            addUnit();
            while (availablemoves > 0)
            {   
                findbestmove();
                move();
            }
        }
	}

    public void StartTurn()
    {
        available += 2;
    }

    void findbestmove()
    {
        float heuristic = 1000f;

        foreach(Node ok in allNodes)
        {
            
        }
        //get heuristic of each node ignore if 0
        //determine best move for PC and worst move for player
        //change select1 and select2 according to best move
    }
    void move()
    {
        select2.GetComponent<Node>().allUnits.AddRange(select1.GetComponent<Node>().allUnits);
        select1.GetComponent<Node>().allUnits.Clear();
        int j = 1;
        foreach (Transform i in select2.GetComponent<Node>().allUnits)
        {
            i.parent = select2;
            i.position = new Vector3(select2.position.x, 0.1f + 0.1f * j, select2.position.z);
            j++;
        }
        select1 = null;
        select2 = null;
    }
    void selectUnit()
    {

    }
    void selectNode()
    {

    }
    void addUnit()
    {
        int x = mainBase.allUnits.Count;
        if (available > 0)
        {
            Transform t = mainBase.transform;
            if (needAttack - needDefense <  -0.2)
            {
                Transform unit = Instantiate(dan0, new Vector3(t.position.x, 0.1f + 0.1f * x, t.position.z), transform.rotation) as Transform;
                unit.transform.SetParent(mainBase.transform);
                mainBase.addUnit(1, unit);
            }
            else if (needAttack - needDefense > 0.2)
            {
                Transform unit = Instantiate(dan1, new Vector3(t.position.x, 0.1f + 0.1f * x, t.position.z), transform.rotation) as Transform;
                unit.transform.SetParent(mainBase.transform);
                mainBase.addUnit(1, unit);
            }
            else
            {
                Transform unit = Instantiate(dan2, new Vector3(t.position.x, 0.1f + 0.1f * x, t.position.z), transform.rotation) as Transform;
                unit.transform.SetParent(mainBase.transform);
                mainBase.addUnit(1, unit);
            }
            available -= 1;
        }
    }
}
