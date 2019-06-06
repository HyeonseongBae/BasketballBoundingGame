using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBlockCollider : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Time.timeScale = 1.4f;
            BallControl.S.speedCurTime = 0;
            BallControl.S.speedTime = true;
            GetComponent<ParticleSystem>().Play();
            SoundManager.S.PlayEffectSound(2);
        }   
    }
}
