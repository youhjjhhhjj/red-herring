using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
  private Camera playerCam;

  void Start()
  {
    playerCam = GetComponent<Camera>();
    EventManager.AddListener<FocusEvent>(OnFocus);
  }

  public void OnFocus(FocusEvent evt)
  {
    GameObject target = GameObject.FindGameObjectWithTag(evt.ObjectTag);
    Focus(target);
  }
  void Focus(GameObject target)
  {
    Debug.Log(target);
    playerCam.transform.LookAt(target.transform);
  }
}