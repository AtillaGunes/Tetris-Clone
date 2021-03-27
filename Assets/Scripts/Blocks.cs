using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    float fall = 0;
    public float fallSpeed = 1;

    public bool allowRotation = true;
    public bool limitRotation = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckUserInput();
    }

    void CheckUserInput() {

        if(Input.GetKeyDown(KeyCode.D)) {
           transform.position += new Vector3(1, 0, 0);

           if(CheckPosition() ) {

           } else {
               transform.position += new Vector3(-1, 0, 0);
           }

        } else if (Input.GetKeyDown(KeyCode.A)){
           transform.position += new Vector3(-1, 0, 0);
           
           if(CheckPosition() ) {

           }else {
               transform.position += new Vector3(1, 0, 0);
           }

        } else if (Input.GetKeyDown(KeyCode.W)){  
            if(allowRotation) {
                if(limitRotation) {
                    if(transform.rotation.eulerAngles.z >= 90) {
                        transform.Rotate(0, 0,-90);
                    }else {
                        transform.Rotate(0, 0, 90);
                    }
                }
                else {
                    transform.Rotate(0 , 0, 90);
                }
                if(CheckPosition()) {
                
                }else{
                    if(limitRotation){
                     if(transform.rotation.eulerAngles.z >= 90) {
                        transform.Rotate(0, 0, -90);
                     }else{
                        transform.Rotate(0, 0, 90);
                     }
                    }else{
                        transform.Rotate(0, 0, -90);
                    }
                    
                }
             }
                          
                           
                
        } else if (Input.GetKeyDown(KeyCode.S) || Time.time - fall >= fallSpeed){
            transform.position += new Vector3(0, -1, 0);
            if(CheckPosition() ) {

           }else {
               transform.position += new Vector3(0, 1, 0);
               enabled = false;
               FindObjectOfType<Game>().Spawnblock();
           }
            fall = Time.time;
        }

    }
    
    bool CheckPosition() {
        foreach ( Transform block in transform) {
            Vector2 pos = FindObjectOfType<Game>().Round(block.position);
            if( FindObjectOfType<Game>().ChechInside (pos) == false) {
                return false;
            }
        }
        return true;
        }
    } 
  
  

