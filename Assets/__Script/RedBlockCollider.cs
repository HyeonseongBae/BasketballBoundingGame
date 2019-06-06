using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlockCollider : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            ScoreManager.S.point += 50;
            collision.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
            SoundManager.S.PlayEffectSound(3);
            Destroy(this.gameObject);
        }
    }
}
