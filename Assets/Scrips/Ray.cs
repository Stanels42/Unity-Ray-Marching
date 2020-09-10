using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Ray : MonoBehaviour
{

  public int vertexCount = 4;
  public float radius;
  public float lineWidth;
  public float rayLength;
  public int maxPoints = 1;

  public Color displayColor;
  public GameObject pointObject;

  private LineRenderer lineRenderer;
  private GameObject[] circles;
  private ArrayList points;

  void Start() { 
    lineRenderer = gameObject.GetComponent<LineRenderer>();
    lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
    lineRenderer.startColor = displayColor;
    lineRenderer.endColor = displayColor;

    points = new ArrayList();

    circles = FindCircles();
  }


  void Update() {
    DrawLineThroughMouse();
    DrawSphere(transform.position);
    SphereTrace();
  }


  void DrawLineThroughMouse() {
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector3 slope = mousePosition - transform.position;
    float scale = Distance.pointScaleFactor(slope, rayLength);
    Vector3 endPoint = new Vector3(transform.position.x + slope.x*scale, transform.position.y + slope.y*scale, 0f);
    Debug.DrawLine(transform.position, endPoint, displayColor);
  }


  void SphereTrace () {
    int index = 0;
    float radius = FindClosestCircle(transform.position);
    while (index < maxPoints && (radius > .01f && radius < 100)) {
      GameObject currentPoint; 
      if (index < points.Count) {
        currentPoint = (GameObject)points[index];
      } else {
        currentPoint = Instantiate(pointObject, new Vector3(0, 0, 0), Quaternion.identity);
        points.Add(currentPoint);
      }
      currentPoint.GetComponent<DrawCircle>().radius = radius;
      index++;
    }
  }


  void DrawSphere(Vector3 position) {
    float radius = FindClosestCircle(transform.position);

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


  float FindClosestCircle (Vector3 point) {
    float minDistance = 10000;
    for (int i = 0; i < circles.Length; i++) {
      GameObject currentCircle = circles[i];
      float circleDistance = CalculateCircleDistance(currentCircle, point);
      minDistance = Math.Min(minDistance, circleDistance);
    }
    return minDistance;
  }


  float CalculateCircleDistance(GameObject circle, Vector3 point) {
    Vector3 circlePosition = circle.transform.position;
    float circleRadius = GetCircleRadius(circle);
    float sphereRadius = Distance.DistanceToCircle2D(point, circlePosition, circleRadius);
    return sphereRadius;
  }


  GameObject[] FindCircles () {
    return GameObject.FindGameObjectsWithTag("Circle");
  }


  float GetCircleRadius (GameObject circle) {
    return circle.transform.localScale.x / 2.0f;
  }


  // GameObject[] FindSquares () {
  //   return GameObject.FindGameObjectsWithTag("Square");
  // }

  // float CalculateSquareDistance (GameObject square) {
  //   float xScale = square.transform.localScale.x;
  //   float yScale = square.transform.localScale.y;
  //   Vector3 squareLocation = square.transform.position;

  //   float distanceToCenter = Distance.Pythagoras(transform.position, squareLocation);

  //   float distanceToEdge = distanceToCenter;

  //   return distanceToEdge;
  // }

  // float FindClosestSquare () {
  //   GameObject[] squares = FindSquares();
  //   float minDistance = 10000;
  //   for (int i = 0; i < squares.Length; i++) {
  //     GameObject currentSquare = squares[i];
  //     float squareDistance = CalculateSquareDistance(currentSquare);
  //     minDistance = Math.Min(minDistance, squareDistance);
  //   }
  //   return minDistance;
  // }
}
