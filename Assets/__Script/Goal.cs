using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            SoundManager.S.PlayEffectSound(4);
            MapSetting.S.Clear();
            MapSetting.S.MakingMap();
            BallControl.S.Reset();
            TimeManager.S.lifeTime += 20;
            ScoreManager.S.point += 100;
            MapSetting.S.level++;

            if (MapSetting.S.level >= 5)
            {
                if (MapSetting.S.level <= 10)
                {
                    MapSetting.S.windowPersent += 0.2f;
                }
                MapSetting.S.MakingWindow();
            }
            BallControl.S.GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
        }
    }
}
