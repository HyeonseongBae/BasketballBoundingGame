using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerControl : MonoBehaviour {
    public FingerControl S = null;
   
    private Vector2 mousePos;


    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
    }

    private void Update()
    {
        TouchEvent();
    }

    void TouchEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Input.mousePosition;
            mouse.z = Camera.main.transform.position.z;
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(mouse);
            clickPos.y = Camera.main.transform.position.y;
            Vector3 power = clickPos - BallControl.S.transform.position;
            power.y = 0;
            BallControl.S.transform.GetComponent<Rigidbody>().AddForce(-power * 50);
            BallControl.S.transform.GetComponent<Rigidbody>().AddForce(Vector3.down * 200);
        }
    }
}
