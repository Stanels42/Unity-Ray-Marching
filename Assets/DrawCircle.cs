using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
  public float radius;
  public int vertexCount;
  public float lineWidth;

  private LineRenderer lineRenderer;
  private Color displayColor;
  // Start is called before the first frame update
  void Start () {
    displayColor = Color.white;
    lineRenderer = gameObject.GetComponent<LineRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
    Draw();
  }

  void Draw() {
    Vector3 position = transform.position;
    lineRenderer.widthMultiplier = lineWidth;

    float deltaTheta = (2f * Mathf.PI) / vertexCount;
    float theta = 0f;

    // Need extra point to return to start
    lineRenderer.positionCount = vertexCount + 1;
    for (int i = 0; i <= vertexCount; i++) {
      Vector3 pos = new Vector3((radius * Mathf.Cos(theta)) + position.x, (radius * Mathf.Sin(theta)) + position.y, 0f);
      lineRenderer.SetPosition(i, pos);
      theta += deltaTheta;
    }
  }
}
