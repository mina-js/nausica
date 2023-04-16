using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class FlightManager : MonoBehaviour
{
  public float speed = 0.1f;
  public float horizontalRotationSpeed = 1f;
  public float verticalRotationSpeed = 1f;

  public float timeTurning = 0f;
  float yRotation = 0f;
  float xRotation = 0f;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    adjust();
    propel();
  }

  void adjust()
  {
    //just apply constant rotation set from the click callbacks
    if (yRotation != 0f)
    {
      rotateAroundYAxis(Time.deltaTime * yRotation);
    }

    if (xRotation != 0f)
    {
      rotateAroundXAxis(Time.deltaTime * xRotation);
    }
  }

  void propel()
  {
    //move the transform forward by a constant
    transform.position += transform.forward * Time.deltaTime * speed;
  }

  public void GoLeft(CallbackContext ctx)
  {
    if (ctx.started)
    {
      timeTurning = 0f;
      yRotation = -1f * horizontalRotationSpeed;
    }
    else if (ctx.canceled)
    {
      cancelTurning();
      return;
    }
  }

  public void GoRight(CallbackContext ctx)
  {
    if (ctx.started)
    {
      timeTurning = 0f;
      yRotation = horizontalRotationSpeed;
    }
    else if (ctx.canceled)
    {
      cancelTurning();
      return;
    }
  }

  public void GoUp(CallbackContext ctx)
  {
    if (ctx.started)
    {
      timeTurning = 0f;
      xRotation = -1f * verticalRotationSpeed;
    }
    else if (ctx.canceled)
    {
      cancelTurning(true);
      return;
    }
  }

  public void GoDown(CallbackContext ctx)
  {
    if (ctx.started)
    {
      timeTurning = 0f;
      xRotation = verticalRotationSpeed;
    }
    else if (ctx.canceled)
    {
      cancelTurning(true);
      return;
    }
  }

  void cancelTurning(bool isVertical = false)
  {
    timeTurning = 0f;

    if (isVertical)
    {
      xRotation = 0f;
    }
    else
    {
      yRotation = 0f;
    }
  }

  void rotateAroundXAxis(float angle)
  {
    transform.RotateAround(transform.position, transform.right, angle);
  }

  void rotateAroundYAxis(float angle)
  {
    transform.RotateAround(transform.position, transform.up, angle);
  }

}
