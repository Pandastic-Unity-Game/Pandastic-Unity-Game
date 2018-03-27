using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class Skidmarks : MonoBehaviour {

    public float markWidth;
    private int skidding;
    private Vector3[] lastPos = new Vector3[2];

    public bool isEnemy;

    public Material SkidmarkMaterial;

    private GameObject parent;
    private GameObject PlayerPauseMenu;

    private Renderer Mesh;
    private UnityStandardAssets.Vehicles.Car.CarController Player;


    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Vehicles.Car.CarController>();

    }
	
	// Update is called once per frame
    void Update()
    {
        if (Player.IsDrifting)
        {
            SkidMesh();
        }
        else
        {
            skidding = 0;
        }
    }

    void SkidMesh()
    {
        var mark = new GameObject("Mark");
        var filter = mark.AddComponent<MeshFilter>();
        mark.AddComponent<MeshRenderer>();
        var markMesh = new Mesh();
        var vertices = new Vector3[4];
        var triangles = new int[6];

        if (skidding == 0)
        {
            vertices[0] = transform.position + Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z) * new Vector3(markWidth, 0.01f, 0);
            vertices[1] = transform.position + Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z) * new Vector3(-markWidth, 0.01f, 0);
            vertices[2] = transform.position + Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z) * new Vector3(-markWidth, 0.01f, 0);
            vertices[3] = transform.position + Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z) * new Vector3(markWidth, 0.01f, 0);
            lastPos[0] = vertices[2];
            lastPos[1] = vertices[3];
            skidding = 1;
        }
        else
        {
            vertices[1] = lastPos[0];
            vertices[0] = lastPos[1];
            vertices[2] = transform.position + Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z) * new Vector3(-markWidth, 0.01f, 0);
            vertices[3] = transform.position + Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z) * new Vector3(markWidth, 0.01f, 0);
            lastPos[0] = vertices[2];
            lastPos[1] = vertices[3];
        }
        triangles = new int[] { 0, 1, 2, 2, 3, 0 };
        markMesh.vertices = vertices;
        markMesh.triangles = triangles;
        markMesh.RecalculateNormals();
        var uvm = new Vector2[markMesh.vertices.Length];
        for (int i = 0; i < uvm.Length; i++)
        {
            uvm[i] = new Vector2(markMesh.vertices[i].x, markMesh.vertices[i].z);
        }
        markMesh.uv = uvm;
        filter.mesh = markMesh;
        mark.GetComponent<Renderer>().material = SkidmarkMaterial;
        mark.GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.Off;
        Destroy(mark,3);
    }
}
