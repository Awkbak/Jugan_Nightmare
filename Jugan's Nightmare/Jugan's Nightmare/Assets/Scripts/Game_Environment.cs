using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Game_Environment : MonoBehaviour {

    List<Vector3> positions = new List<Vector3>();
    public Transform allNodes;
    public Transform redBase;
    public Transform blueBase;

	void Start () {
        List<GameObject> n = new List<GameObject>();

        positions.Add(new Vector3(0f,0f,-10f));
        positions.Add(new Vector3(-2f, 0f, -8f));
        positions.Add(new Vector3(2f, 0f, -8f));
        positions.Add(new Vector3(0f, 0f, -6f));
        positions.Add(new Vector3(-5f, 0f, -4f));
        positions.Add(new Vector3(5f, 0f, -4f));
        positions.Add(new Vector3(0f, 0f, -2f));
        positions.Add(new Vector3(-8f, 0f, 0f));
        positions.Add(new Vector3(-2f, 0f, 0f));
        positions.Add(new Vector3(2f, 0f, 0f));
        positions.Add(new Vector3(8f, 0f, 0f));
        positions.Add(new Vector3(0f, 0f, 2f));
        positions.Add(new Vector3(-5f, 0f, 4f));
        positions.Add(new Vector3(5f, 0f, 4f));
        positions.Add(new Vector3(0f, 0f, 6f));
        positions.Add(new Vector3(-2f, 0f, 8f));
        positions.Add(new Vector3(2f, 0f, 8f));
        positions.Add(new Vector3(0f, 0f, 10f));

        for (var i = 0; i < 18; i++)
        {
            GameObject idk = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            idk.transform.position = positions[i];
            idk.name = "Node" + i;
            idk.transform.localScale = new Vector3(1f,0.05f,1f);
            idk.transform.SetParent(allNodes);
            n.Add(idk);
        }
        for(var i = 0; i < 18; i++)
        {
            Node s = new Node();
            switch (i)
            {
                case 0:
                    s.f1 = n[1].transform;
                    s.f2 = n[2].transform;
                    break;
                case 1:
                    s.f1 = n[4].transform;
                    s.f2 = n[3].transform;
                    s.b1 = n[0].transform;
                    break;
                case 2:
                    s.f1 = n[3].transform;
                    s.f2 = n[5].transform;
                    s.b1 = n[0].transform;
                    break;
                case 3:
                    s.f1 = n[6].transform;
                    s.b1 = n[1].transform;
                    s.b2 = n[2].transform;
                    break;
                case 4:
                    s.f1 = n[7].transform;
                    s.f2 = n[8].transform;
                    s.b1 = n[1].transform;
                    break;
                case 5:
                    s.f1 = n[9].transform;
                    s.f2 = n[10].transform;
                    s.b1 = n[2].transform;
                    break;
                case 6:
                    s.f1 = n[8].transform;
                    s.f2 = n[9].transform;
                    s.b1 = n[3].transform;
                    break;
                case 7:
                    s.f1 = n[12].transform;
                    s.b1 = n[4].transform;
                    break;
                case 8:
                    s.f1 = n[12].transform;
                    s.f2 = n[11].transform;
                    s.b1 = n[4].transform;
                    s.b2 = n[6].transform;
                    break;
                case 9:
                    s.f1 = n[11].transform;
                    s.f2 = n[13].transform;
                    s.b1 = n[6].transform;
                    s.b2 = n[5].transform;
                    break;
                case 10:
                    s.f1 = n[13].transform;
                    s.b1 = n[5].transform;
                    break;
                case 11:
                    s.f1 = n[14].transform;
                    s.b1 = n[8].transform;
                    s.b2 = n[9].transform;
                    break;
                case 12:
                    s.f1 = n[15].transform;
                    s.b1 = n[7].transform;
                    s.b2 = n[8].transform;
                    break;
                case 13:
                    s.f1 = n[16].transform;
                    s.b1 = n[9].transform;
                    s.b2 = n[10].transform;
                    break;
                case 14:
                    s.f1 = n[15].transform;
                    s.f2 = n[16].transform;
                    s.b1 = n[11].transform;
                    break;
                case 15:
                    s.f1 = n[17].transform;
                    s.b1 = n[12].transform;
                    s.b2 = n[14].transform;
                    break;
                case 16:
                    s.f1 = n[17].transform;
                    s.b1 = n[14].transform;
                    s.b2 = n[13].transform;
                    break;
                case 17:
                    s.b1 = n[15].transform;
                    s.b2 = n[16].transform;
                    break;
                default:
                    break;
            }
            n[i].AddComponent<Node>();
            n[i].GetComponent<Node>().f1 = s.f1;
            n[i].GetComponent<Node>().b1 = s.b1;
            n[i].GetComponent<Node>().f2 = s.f2;
            n[i].GetComponent<Node>().b2 = s.b2;
            redBase = n[17].transform;
            blueBase = n[0].transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
