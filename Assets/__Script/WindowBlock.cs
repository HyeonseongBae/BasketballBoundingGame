using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBlock : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            ScoreManager.S.point += 50;
            SoundManager.S.PlayEffectSound(0);
            Destroy(this.gameObject);
        }
    }
}
