﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Game_Environment : MonoBehaviour {

    List<Vector3> positions = new List<Vector3>();
    public Transform allNodes;
    public Transform redBase;
    public Transform blueBase;
    public Computer AI;


	void Start () {
        List<Node> n = new List<Node>();

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

        foreach(Node no in n)
        {
            GameObject idk = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            idk.transform.localScale = new Vector3(1f,0.05f,1f);
            idk.transform.SetParent(allNodes);
            idk.AddComponent<Node>();
        }

        for(var i = 0; i < 18; i++)
        {
            Node s = n[i].GetComponent<Node>();
            switch (i)
            {
                case 0:
                    s.f1 = n[1];
                    s.f2 = n[2];
                    break;
                case 1:
                    s.f1 = n[4];
                    s.f2 = n[3];
                    s.b1 = n[0];
                    break;
                case 2:
                    s.f1 = n[3];
                    s.f2 = n[5];
                    s.b1 = n[0];
                    break;
                case 3:
                    s.f1 = n[6];
                    s.b1 = n[1];
                    s.b2 = n[2];
                    break;
                case 4:
                    s.f1 = n[7];
                    s.f2 = n[8];
                    s.b1 = n[1];
                    break;
                case 5:
                    s.f1 = n[9];
                    s.f2 = n[10];
                    s.b1 = n[2];
                    break;
                case 6:
                    s.f1 = n[8];
                    s.f2 = n[9];
                    s.b1 = n[3];
                    break;
                case 7:
                    s.f1 = n[12];
                    s.b1 = n[4];
                    break;
                case 8:
                    s.f1 = n[12];
                    s.f2 = n[11];
                    s.b1 = n[4];
                    s.b2 = n[6];
                    break;
                case 9:
                    s.f1 = n[11];
                    s.f2 = n[13];
                    s.b1 = n[6];
                    s.b2 = n[5];
                    break;
                case 10:
                    s.f1 = n[13];
                    s.b1 = n[5];
                    break;
                case 11:
                    s.f1 = n[14];
                    s.b1 = n[8];
                    s.b2 = n[9];
                    break;
                case 12:
                    s.f1 = n[15];
                    s.b1 = n[7];
                    s.b2 = n[8];
                    break;
                case 13:
                    s.f1 = n[16];
                    s.b1 = n[9];
                    s.b2 = n[10];
                    break;
                case 14:
                    s.f1 = n[15];
                    s.f2 = n[16];
                    s.b1 = n[11];
                    break;
                case 15:
                    s.f1 = n[17];
                    s.b1 = n[12];
                    s.b2 = n[14];
                    break;
                case 16:
                    s.f1 = n[17];
                    s.b1 = n[14];
                    s.b2 = n[13];
                    break;
                case 17:
                    s.b1 = n[15];
                    s.b2 = n[16];
                    break;
                default:
                    break;
            }

            n[i].GetComponent<Node>().f1 = s.f1;
            n[i].GetComponent<Node>().b1 = s.b1;
            n[i].GetComponent<Node>().f2 = s.f2;
            n[i].GetComponent<Node>().b2 = s.b2;
            redBase = n[17].transform;
            blueBase = n[0].transform;
        }
	}

    // Update is called once per frame
    public void endturn()
    {
        AI.myturn = !AI.myturn;
    }
	void Update () {
	
	}
}
