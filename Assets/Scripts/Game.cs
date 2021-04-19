using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour

{
    public static int gridWidth = 10;
    public static int gridHeight = 15;
    public static Transform[,] grid = new Transform[gridWidth,gridHeight];
    void Start()
    {
        Spawnblock();
    }

    public bool CheckIsAbove (Blocks blocks) {
        for (int x = 0; x < gridWidth; ++x){
            foreach (Transform block in blocks.transform){
                Vector2 pos = Round (block.position);
                if(pos.y > gridHeight-1) {
                    return true;
                }
            }
        }
        return false;
    }
    
    public bool IsFullRow (int y) {
        for (int x = 0; x < gridWidth; ++x) {
            if(grid[x,y] == null){
                return false;
            }
        }
        return true;
    }
    public void DeleteBlocks (int y) {
        for (int x = 0; x < gridWidth; ++x) {
            Destroy (grid[x,y].gameObject);
            grid[x,y] = null;
        } 
    }

    public void MoveDown (int y){
        for(int x = 0; x < gridWidth; ++x){
            if (grid[x,y] != null) {
                grid[x,y -1] = grid[x,y];
                grid[x,y] = null;
                grid[x,y-1].position += new Vector3(0, -1, 0);
            }
        }
    }

public void MoveAllDown (int y) {
    for (int i = y; 1 < gridHeight; ++i){
        MoveDown(i);
    }
}

public void DeleteRow() {
    for (int y = 0; y < gridHeight; ++y){
        if (IsFullRow(y)) {
            DeleteBlocks(y);
            MoveAllDown(y+1);
            --y;
        }
    }
}
    public void UpdateGrid (Blocks blocks){

        for (int y= 0; y < gridHeight; ++y){
            for(int x = 0; x < gridWidth; ++x){
                if(grid[x,y] !=null) {
                    if (grid[x,y].parent == blocks.transform){
                        grid[x,y] = null;
                    }
                }
            }
        }
        foreach (Transform block in blocks.transform){
            Vector2 pos = Round (block.position);
            if(pos.y < gridHeight) {
                grid[(int)pos.x, (int)pos.y] = block;
            }
        }
    }
    public Transform GetTransform (Vector2 pos) {
        if (pos.y > gridHeight -1){
            return null;
        }else {
            return grid[(int)pos.x, (int)pos.y];
        }

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
    public void GameOver(){
        Application.LoadLevel("GameOver");
    }
}
