using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Drawing using GL Lines
public class GLRay : MonoBehaviour
{
  // Start is called before the first frame update
  public GameObject castPOV;

  public float maxRadius;

  public int maxVertices;


  private GameObject[] circles;
  // private GameObject[] squares;



  void Start () {
    circles = GameObject.FindGameObjectsWithTag("Circle");
    // squares = GameObject.FindGameObjectsWithTag("Square");
  }

  // Update is called once per frame
  void Update () {
    
  }

  void OnPostRender () {
    DrawCircle(castPOV.transform.position, 1f);
  }

  void DrawRay (Vector3 start, Vector3 midPoint, float length) {

  }

  void DrawCircle (Vector3 center, float radius) {
    GL.PushMatrix();
    GL.Begin(GL.LINES);
    for (int i = 0; i < maxVertices; i++) {
      float rotationRatio = i / (float)maxVertices;
      float angle = Mathf.PI * 2 * rotationRatio;
      GL.Vertex3(0, 0, 0);
      GL.Vertex3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
    }
    GL.End();
    GL.PopMatrix();
  }

  float CalculateRadius (Vector3 point) {
    return 0f;
  }

}
