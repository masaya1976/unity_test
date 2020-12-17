using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TestProgram : MonoBehaviour
{
    public float scale = 1.0f;
    public GameObject refObj;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        System.Type type = refObj.GetType();
        MeshRenderer meshrender = refObj.GetComponent<MeshRenderer>();
        int sizeno = meshrender.materials.GetLength(0);


        MeshFilter meshFilter = refObj.GetComponent<MeshFilter>();
/*
        Mesh mesh = meshFilter.mesh;
        int vtxno = mesh.vertexCount;

        int normalno =  mesh.normals.GetLength(0);

        //サブメッシュ数 
        int submeshno = mesh.subMeshCount;
        for(int i = 0; i < submeshno; i++)
        {
            int [] triangle = mesh.GetTriangles(i);
            int trino = triangle.GetLength(0);
            Debug.Log("trino=" + trino);
        }
        */

        meshrender.materials[0].color = Color.blue;
        

        func test = new func();
        test.dispMessage("test");


        // 書き込み
        string path = Application.persistentDataPath + "/test.txt";

        MyUtility util = new MyUtility();
        util.ResearchMesh(meshFilter);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
