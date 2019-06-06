using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour {
    static public BallControl S = null;

    //Speed Block Effect Value
    public float speedMaxTime = 5f;
    public bool speedTime = false;
    public float speedCurTime = 0;


    private void Awake()
    {
        if(S == null)
        {
            S = this;
        }
        Time.timeScale = 0.7f;
    }

    private void Update()
    {
        if (speedTime)
        {
            if (speedCurTime > speedMaxTime)
            {
                Time.timeScale = 0.7f;
                speedCurTime = 0;
                speedTime = false;
            }
            speedCurTime += Time.deltaTime;
        }

        if(transform.position.y < -50f)
        {
            if (ScoreManager.S.point > ScoreManager.S.maxPoint)
            {
                PlayerPrefs.SetInt("MaxPoint", ScoreManager.S.point);
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene(2);
        }
    }

    public void Reset()
    {
        speedTime = false;
        speedCurTime = 0;
        Time.timeScale = 0.7f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            transform.GetComponent<Rigidbody>().velocity *= 0.9f;
            ScoreManager.S.point += 10;
            transform.GetComponent<AudioSource>().Play();
            GetComponent<ParticleSystem>().Play();
        }
    }
}