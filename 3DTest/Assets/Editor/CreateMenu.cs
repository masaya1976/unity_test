using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


class MyWindow : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    int[] selection;


    [MenuItem("Window/My Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MyWindow));
    }

    void OnGUI()
    {
        //  実際のウィンドウのコードはここに書きます
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();

        if (GUILayout.Button("Research"))
        {
            Research();
            //SaveSelection();
        }

        if (GUILayout.Button("Create"))
        {
            Create();
            //SaveSelection();
        }

        //int length = selection.GetLength(0);
        //if(length > 0)
        //    GUILayout.Label("selection=" + selection[0].ToString(), EditorStyles.boldLabel);

        if (selection != null)
        {
            int length = selection.GetLength(0);
            if(length > 0)
                GUILayout.Label("selection=" + selection[0].ToString(), EditorStyles.boldLabel);

        }

    }

    void OnSelectionChange()
    {
        //selectionIDs = 
        selection = Selection.instanceIDs;
        GameObject obj = Selection.activeGameObject;
        //myString = obj.name;
    }

    public void Create()
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        MeshFilter meshfilter = obj.GetComponent<MeshFilter>();

        Mesh mesh = new Mesh();
        const float vertsize = 5;
        List<Vector3> vert = new List<Vector3>
        {
            new Vector3(0,0),
            new Vector3(0,vertsize),
            new Vector3(vertsize,0),
            new Vector3(vertsize,vertsize)
        };

        List<Vector3> nrm = new List<Vector3>
        {
            new Vector3(0,0,1),
            new Vector3(0,0,1),
            new Vector3(0,0,1),
            new Vector3(0,0,1),
        };

        List<Vector2> uvs = new List<Vector2>
        {
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,0),
            new Vector2(1,1),
        };

        int[] triangle = { 0, 1, 2, 2,  1,3};
        mesh.SetVertices(vert);
        mesh.SetNormals(nrm);
        mesh.SetTriangles(triangle,0);
        mesh.SetUVs(0,uvs);

        meshfilter.mesh = mesh;

        MeshRenderer renderer = obj.GetComponent<MeshRenderer>();

        Material mat = renderer.sharedMaterial;
        mat.color = new Color(0, 1, 0);

        //new Material();
        Shader shader = Shader.Find("Standard");
        Material setmat = new Material(shader);
        renderer.material = setmat;

        Texture2D tex2d = Resources.Load("pipo-enemy002a") as Texture2D;
        setmat.SetTexture("_MainTex", tex2d);

        setmat.SetColor("_Color", new Color(1, 1, 1));
        //Material material = new Material(Shader.Find("Standard"));

        CapsuleCollider capcollider = obj.GetComponent<CapsuleCollider>();
        if(capcollider != null)
        {
            DestroyImmediate(capcollider);
        }



            

    }


    public void Research()
    {
        GameObject obj = Selection.activeGameObject;
        if(obj != null)
        {
            MeshFilter meshfilter = obj.GetComponent<MeshFilter>();
            if(meshfilter != null)
            {
                myString = "meshFilter"; //meshfilter.mesh;
                Mesh mesh = meshfilter.sharedMesh;
                if(mesh!= null)
                {
                    List<Vector3> vert = new List<Vector3>();
                    mesh.GetVertices(vert);
                    myString = "mesh vertcnt=" + vert.Count.ToString();

                    List<Vector3> set_vert = new List<Vector3>();

                    foreach (Vector3 element in vert)
                    {
                        Vector3 vec =  element * 2;
                        set_vert.Add(vec);
                    }
                    //mesh.SetVertices(set_vert);
                    int []triangle = mesh.GetTriangles(0);

                    Debug.Log("trino=" + triangle.GetLength(0).ToString());

                    int[] setindex = new int[triangle.GetLength(0)/2];
                    for(int i=0;i<triangle.GetLength(0) / 2; i++)
                    {
                        setindex[i] = triangle[i];
                    }
                    mesh.SetTriangles(setindex, 0);

                }


            }


        }

    }
}