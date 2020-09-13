using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfTriggeredObjChangeMaterial : MonoBehaviour
{
  public TempDatas TempDatas;
  public Material mouseInteractableMaterial;
  public Material mouseSelectedMaterial;
  Material startMaterial;
  MeshRenderer MeshRenderer;

  // Use this for initialization
  void Start()
  {
    MeshRenderer = GetComponent<MeshRenderer>();
    startMaterial = MeshRenderer.material;
  }

  // Update is called once per frame
  void Update()
  {
    if (TempDatas.takenObj && TempDatas.takenObj == transform)
    {
      MeshRenderer.material = startMaterial;
      return;
    }

    if (TempDatas.hoveredObj == transform)
    {
      MeshRenderer.material = mouseSelectedMaterial;
    }
    if (TempDatas.selectedObj == transform)
    {
      MeshRenderer.material = mouseSelectedMaterial;
    }
    else if (Vector3.Distance(TempDatas.playerPos, transform.position) < 1)
    {
        MeshRenderer.material = mouseInteractableMaterial;
    }
    else
      MeshRenderer.material = startMaterial;
  }
}
