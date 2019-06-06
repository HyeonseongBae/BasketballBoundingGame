using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private float yPos = 10;
    private float lerpYPos;

	void Update () {

        Vector3 ballPos = BallControl.S.transform.position;
        if(ballPos.y > 6)
        {
            lerpYPos = Mathf.Lerp(transform.position.y, ballPos.y + 4, 0.1f);
        }
        else
        {
            lerpYPos = Mathf.Lerp(transform.position.y, yPos, 0.1f);
        }
        ballPos.y = lerpYPos;
        transform.position = ballPos;

	}
}
