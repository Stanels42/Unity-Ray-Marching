using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Distance : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    
  }

  public static float Pythagoras(Vector2 sides) {
    return (float)Math.Sqrt(sides.x*sides.x + sides.y*sides.y);
  }

  public static float Pythagoras(Vector3 pointOne, Vector3 pointTwo) {
    Vector2 difference = new Vector2();
    difference.x = pointOne.x - pointTwo.x;
    difference.y = pointOne.y - pointTwo.y;
    return Pythagoras(difference);
  }


  public static float DistanceToCircle2D (Vector3 point, Vector3 circleOrigin, float radius) {
    return Pythagoras(point, circleOrigin) - radius;
  }


  // float2 PointOnCircle(Vector2 a, Vector2 c, float radius) {
    // float val = (c.x - a.x)/ (Pythagoras());
    // val = val * radius;
    // return 0;
  // }

  public static float pointScaleFactor (Vector3 slope, float distance) {
    float numerator = distance * distance;
    float denomerator = (slope.x * slope.x) + (slope.y * slope.y);
    return Mathf.Sqrt(numerator/denomerator);
  }


  public static float DistanceToCube2D (Vector3 point, Vector3 squareOrigin, float2 scale) {
    Vector3 offset;
    return 0f;
  }
}
