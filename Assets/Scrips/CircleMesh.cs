using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMesh : MonoBehaviour
{
  public int vertexCount;
  public float radius;

  private Vector3 center = new Vector3(0,0,0);
  private Vector3[] vertices;
  private int[] triangles;
  
  Mesh mesh;

  // Start is called before the first frame update
  void Start () {
    mesh = new Mesh();
    GetComponent<MeshFilter>().mesh = mesh;
    DrawCircle();
  }

  // Update is called once per frame
  void Update () {
    UpdateMesh();
  }

  void DrawCircle () {
    vertices = new Vector3[vertexCount];
    triangles = new int[]{0,1,2};

    float deltaTheta = (2f * Mathf.PI) / vertexCount;
    float theta = 0f;

    for (int i = 0; i < vertexCount; i++) {
      Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
      vertices[i] = pos;
      theta += deltaTheta;
    }
  }

  void UpdateMesh () {
    mesh.Clear();

    mesh.vertices = vertices;
    mesh.triangles = triangles;
  }


}
