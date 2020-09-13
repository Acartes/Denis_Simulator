using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjHit : MonoBehaviour
{
  public TempDatas TempDatas;

  void OnCollisionEnter(Collision collision)
  {
    if(TempDatas.takenObj == transform && collision.transform.name != "Player")
    {
      TempDatas.gotObj = false;
    }
  }
}
