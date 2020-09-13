using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

  public TempDatas TempDatas;
	public float rotateSpeed = 0.1f;
  public GameObject StunState;
  Rigidbody rb;
  bool moving;
  bool stun;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void FixedUpdate () {
    if (TempDatas.moveTarget != Vector3.zero && TempDatas.moveTarget != transform.position && rb && !stun)
    {
      if (Vector3.Distance(transform.position, new Vector3(TempDatas.moveTarget.x, transform.position.y, TempDatas.moveTarget.z)) < 0.1f)
      {
        moving = false;
        return ;
      }
      else
        moving = true;

      //transform.position = TempDatas.moveTarget + Vector3.up;
      transform.LookAt(new Vector3(TempDatas.moveTarget.x, transform.position.y, TempDatas.moveTarget.z));
      transform.Rotate(Vector3.zero);
      rb.MovePosition(transform.position + transform.forward / 40);
    }
    TempDatas.playerPos = transform.position;
  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.transform.tag == ("Obstacle") && moving)
    {
      TempDatas.moveTarget = Vector3.zero;
      rb.MovePosition(transform.position -collision.contacts[0].point * Time.deltaTime * 2);
      TempDatas.selectedObj = null;
      StartCoroutine(stunned());
    }
  }
  IEnumerator stunned()
  {
    StunState.SetActive(true);
    stun = true;
    yield return new WaitForSeconds(1);
    TempDatas.moveTarget = Vector3.zero;
    stun = false;
    StunState.SetActive(false);
  }

}
