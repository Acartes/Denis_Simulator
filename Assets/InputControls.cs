using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControls : MonoBehaviour {

  public TempDatas TempDatas;
  Vector2 launchStartPos;
  bool slide;
  bool waitNextState;

  // Use this for initialization
  void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
    if (waitNextState)
      return;
    if (Input.GetMouseButton(0) && TempDatas.mouseType != MouseType.Down)
    {
      launchStartPos = Input.mousePosition;
      TempDatas.mouseType = MouseType.Down;
      StopCoroutine(timerSlide());
      StartCoroutine(timerSlide());
    }
    if (!Input.GetMouseButton(0) && TempDatas.mouseType != MouseType.Null)
    {
      if (Vector2.Distance(launchStartPos, Input.mousePosition) > 40 && slide == true)
      {
        TempDatas.mouseType = MouseType.Slide;
        StopCoroutine(resetClick());
        StartCoroutine(resetClick());
      }
      else
      {
        TempDatas.mouseType = MouseType.Click;
        StopCoroutine(resetClick());
        StartCoroutine(resetClick());
      }
    }
    return;
  }

  IEnumerator timerSlide()
  {
    slide = true;
    yield return new WaitForSeconds(0.2f);
    slide = false;
  }
  IEnumerator resetClick()
  {
    waitNextState = true;
    yield return new WaitForEndOfFrame();
    yield return new WaitForEndOfFrame();
    TempDatas.mouseType = MouseType.Null;
    waitNextState = false;
  }
}
