using UnityEngine;
using System.Collections.Generic;

public class Computer : MonoBehaviour {
    public Transform mainBase;
    public bool myturn;
    public List<Node> allNodes = new List<Node>();
    public Transform environment;
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
        mainBase = environment.GetComponent<Game_Environment>().redBase;
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
       if(myturn == true)
        {
            addUnit();
            while (availablemoves > 0)
            {   
                findbestmove();
                move();
            }
        }
	
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
        while (available > 0)
        {
            int x = mainBase.GetComponent<Node>().allUnits.Count;
            if (Mathf.Abs(needAttack - needDefense) < 0.2)
            {
                Transform unit = Instantiate(dan0, new Vector3(mainBase.position.x, 0.1f + 0.1f * x, mainBase.position.z), transform.rotation) as Transform;
                unit.transform.SetParent(mainBase);
                mainBase.GetComponent<Node>().allUnits.Add(unit.transform);
            }
            else if (needAttack - needDefense > 0.2)
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
        }
    }

}
