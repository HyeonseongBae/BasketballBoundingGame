using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSetting : MonoBehaviour {
    static public MapSetting S = null;
    public GameObject ground;

    public List<GameObject> obstaclePrefabs;
    public GameObject windowPrefab;

    public List<GameObject> curObstacles;
    public List<GameObject> windowBlocks;

    int goali;
    int goalj;

    public float windowPersent = 0;

    public int goalX, goalY;
    public int level = 1;

    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        MakingMap();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MakingMap();
        }
        if(level == 30)
        {
            Destroy(ground);
        }
    }

    public void MakingMap()
    {
        float defaultXY = 0.5f;
        GameObject block;
        Vector3 pos;

        // Goal Point Create
        goali = Random.Range(0, 10);
        goalj = Random.Range(0, 10);
        block = Instantiate(obstaclePrefabs[4]);
        pos = new Vector3(defaultXY + goali, block.transform.lossyScale.y / 2 + 0.25f, defaultXY + goalj);
        block.transform.position = pos;
        curObstacles.Add(block);


        float rand;
        int rotation = 0;
        for(int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (i == goalX && j == goalY) continue;
                if (i == goali && j == goalj) continue;
                rotation += 90;
                rand = Random.value;
                if (rand < 0.6f)
                {
                    if (level < 30)
                    {
                        int randInt = Random.Range(0, 2);
                        block = Instantiate(obstaclePrefabs[randInt]);
                    }
                    else
                    {
                        block = Instantiate(obstaclePrefabs[0]);
                    }
                    pos = new Vector3(defaultXY + i, block.transform.lossyScale.y / 2 + 0.25f, defaultXY + j);
                    block.transform.position = pos;
                }
                else if (rand < 0.65f && level >= 20)
                {
                    block = Instantiate(obstaclePrefabs[3]);
                    pos = new Vector3(defaultXY + i, block.transform.lossyScale.y / 2 + 0.25f, defaultXY + j);
                    block.transform.position = pos;
                    Quaternion qua = Quaternion.Euler(0, rotation, 45);
                    block.transform.rotation = qua;
                }
                else if (rand < 0.675f && level >= 5)
                {
                    block = Instantiate(obstaclePrefabs[5]);
                    pos = new Vector3(defaultXY + i, block.transform.lossyScale.y / 2 + 0.25f, defaultXY + j);
                    block.transform.position = pos;
                }
                else if (rand < 0.7f && level >= 10)
                {
                    block = Instantiate(obstaclePrefabs[6]);
                    pos = new Vector3(defaultXY + i, block.transform.lossyScale.y / 2 + 0.25f, defaultXY + j);
                    block.transform.position = pos;
                }
                else if (rand < 0.725f && level >= 15)
                {
                    block = Instantiate(obstaclePrefabs[7]);
                    pos = new Vector3(defaultXY + i, block.transform.lossyScale.y / 2 + 0.25f, defaultXY + j);
                    block.transform.position = pos;
                }
                curObstacles.Add(block);
            }
        }
        rotation = 0;
        goalX = goali;
        goalY = goalj;
    }

    public void Clear()
    {
        foreach(var go in curObstacles)
        {
            Destroy(go);
        }
        foreach (var go in windowBlocks)
        {
            Destroy(go);
        }
        curObstacles.Clear();
        windowBlocks.Clear();
    }


    public void MakingWindow()
    {
        float defaultXY = 0.5f;
        GameObject window;
        Vector3 pos;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if ((goali - 1 <= i && goali +1 >= i) &&
                    (goalj -1 <= j && goalj + 1 >= j))
                {
                    continue;
                }
                if ((goalX - 1 <= i && goalX + 1 >= i) &&
                    (goalY - 1 <= j && goalY + 1 >= j))
                {
                    continue;
                }
                if (Random.value <= windowPersent)
                {
                    window = Instantiate(windowPrefab);
                    pos = new Vector3(defaultXY + i, 4, defaultXY + j);
                    window.transform.position = pos;
                    windowBlocks.Add(window);
                }
            }
        }
    }
}
