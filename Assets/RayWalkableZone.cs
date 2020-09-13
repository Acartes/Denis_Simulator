using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayWalkableZone : MonoBehaviour
{

  public TempDatas TempDatas;

  // Update is called once per frame
  void FixedUpdate()
  {
    Raycast();
  }

  void Raycast()
  {
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    if (Physics.Raycast(ray, out hit))
    {
      if (TempDatas.mouseType == MouseType.Click)
      {
        if (hit.collider.isTrigger)
        {
          TempDatas.selectedObj = hit.transform;
        }
        else
        {
          TempDatas.hoveredObj = null;
          TempDatas.selectedObj = null;
          TempDatas.moveTarget = hit.point;
        }
      }
      else if (TempDatas.mouseType == MouseType.Down)
      {
        if (hit.transform.name.Contains("Player"))
        {
          TempDatas.moveTarget = TempDatas.playerPos;
        }
        else if (hit.collider.isTrigger)
        {
          TempDatas.hoveredObj = hit.transform;
          TempDatas.moveTarget = hit.point;
        }
        else
        {
          TempDatas.hoveredObj = null;
          TempDatas.selectedObj = null;
          TempDatas.moveTarget = hit.point;
        }
      }
      else if (TempDatas.mouseType == MouseType.Null)
      {
        // hover
      }
      else if (TempDatas.mouseType == MouseType.Slide)
      {
        TempDatas.moveTarget = Vector3.zero;
      }

      // Do something with the object that was hit by the raycast.
    }
  }
}
