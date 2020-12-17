using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class func
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void dispMessage(string msg)
    {
        Debug.Log(msg);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}


public class MyUtility

{
    public void ResearchMesh(MeshFilter meshFilter)
    {
        Mesh mesh = meshFilter.mesh;


    }

}
