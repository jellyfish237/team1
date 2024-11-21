using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int moolah;//int = whole number
    public float moolahChange;//float = decimal
    public string monkeys; //string = dialog or words
    public char a;//char = single character
    public bool enemyIsDeceased; //bool = true or false
    public Vector2 playerPos; // Vector2 = 2d position of x and y, scale, rotation, Vector 3 is 3d. Vector 4 is 4d
    
    
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(monkeys + " We love Monkey timmmeee let's go " + monkeys); 
        if (enemyIsDeceased) //Only does this stuff if the if statement is true. Obviously that's how it works it's in the name
        {
            Debug.Log("HAH get fucked");
        }
        else //Only does the code below if the if statement is false "if this is true it does this, else it does this if not"
        {
            Debug.Log("Hippity hasy your flesh lookin tasty");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
