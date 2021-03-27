using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour

{
    public static int gridWidth = 10;
    public static int gridHeight = 20;
    public static Transform[,] grid = new Transform[gridWidth,gridHeight];
    void Start()
    {
        Spawnblock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Spawnblock() {
         GameObject nextBlock =(GameObject)Instantiate(Resources.Load(GetRandomBlock(), typeof(GameObject)), new Vector2(5.0f, 15.0f), Quaternion.identity);
    }
    public bool ChechInside(Vector2 pos){
        return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0);
    }
    public Vector2 Round (Vector2 pos) {
        return new Vector2(Mathf.Round(pos.x),Mathf.Round(pos.y));
    }
    string GetRandomBlock() {
        int randomBlock = Random.Range(1,8);
        string RandomBlockName = "Prefabs/I";
        switch (randomBlock) {

        case 1:
        RandomBlockName = "Prefabs/I";
        break;

        case 2:
        RandomBlockName = "Prefabs/J";
        break;

        case 3:
        RandomBlockName = "Prefabs/L";
        break;

        case 4:
        RandomBlockName = "Prefabs/S";
        break;

        case 5:
        RandomBlockName = "Prefabs/square";
        break;

        case 6:
        RandomBlockName = "Prefabs/T";
        break;

        case 7:
        RandomBlockName = "Prefabs/Z";
        break;
        } 
        return RandomBlockName;
    }
}
