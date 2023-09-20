using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private void Start()
    {
        CreateGrid();
    }
    public void CreateGrid()
    {
        GameObject go = new GameObject();

        go.AddComponent<BoxCollider2D>();

        go.GetComponent<BoxCollider2D>().size = new Vector2(75f, 90f);

        go.transform.position = transform.position;


        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 5; j++)
            {

                GameObject tmp = Instantiate(go);

                tmp.tag = "Land";

                tmp.transform.position = transform.position + new Vector3(82f * i, 97f * j, 0);

                tmp.name = i + "_" + j;
            }

        }

    }
}
