using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGetObj : MonoBehaviour
{

  public TempDatas TempDatas;
  public float getObjDistance = 1f;
  public float objGotOffset = 0f;
  float finalObjOffset = 0f;
  public bool launchReady;
  public Vector2 launchStartPos;
  // Use this for initialization
  void Start()
  {
    finalObjOffset = GetComponent<SphereCollider>().radius;
  }

  // Update is called once per frame
  void Update()
  {
    if (TempDatas.selectedObj)
    {
      TempDatas.moveTarget = TempDatas.selectedObj.transform.position;
      if (Vector3.Distance(TempDatas.selectedObj.position, TempDatas.playerPos) < 1 && TempDatas.selectedObj.tag == "Objet")
      {
        TempDatas.takenObj = TempDatas.selectedObj.transform;
        TempDatas.takenObj.GetComponent<Rigidbody>().useGravity = false;
        TempDatas.gotObj = true;
        TempDatas.moveTarget = Vector3.zero;
      }
    }

    if (TempDatas.gotObj)
    {
      TempDatas.takenObj.transform.position = (transform.position + transform.forward * finalObjOffset);
      if (TempDatas.mouseType == MouseType.Slide && TempDatas.moveTarget != TempDatas.playerPos)
      {
        if (TempDatas.takenObj.transform.name.Contains("Ballon"))
        {
          TempDatas.takenObj.GetComponent<Rigidbody>().AddForce((Vector3.up + TempDatas.takenObj.position - transform.position) * 5, ForceMode.VelocityChange);
        }
        if (TempDatas.takenObj.transform.name.Contains("Cube"))
        {
          TempDatas.takenObj.GetComponent<Rigidbody>().AddExplosionForce(180, TempDatas.playerPos - Vector3.up, 1);
        }
        LacheObj();
      }
    }
    else if (TempDatas.takenObj)
      LacheObj();

  }
  void LacheObj()
  {
    TempDatas.gotObj = false;
    TempDatas.takenObj.GetComponent<Rigidbody>().useGravity = true;
    TempDatas.takenObj = null;
    launchReady = false;
  }
}
