using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugText : MonoBehaviour
{
    
    public static string str;
    TextMesh tm;

    void Start()
    {
        tm = GetComponent<TextMesh>(); 
        str = "hi";  
    }

    void Update() 
    {
        tm.text = str;
    }

    public void SetFloat(float fl) {
        str = fl.ToString();
    }

}
