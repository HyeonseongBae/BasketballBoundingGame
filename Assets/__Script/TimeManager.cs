using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {

    static public TimeManager S = null;
    public Text text;
    public float lifeTime = 30.0f;
    int time = 0;


    private void Update()
    {
        lifeTime -= Time.deltaTime;
        time = Mathf.FloorToInt(lifeTime);
        text.text = time.ToString();
        if(lifeTime <= 0)
        {
            SceneManager.LoadScene(2);
            if (ScoreManager.S.point > ScoreManager.S.maxPoint)
            {
                PlayerPrefs.SetInt("MaxPoint", ScoreManager.S.point);
                PlayerPrefs.Save();
            }
        }
    }


    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
    }
}
