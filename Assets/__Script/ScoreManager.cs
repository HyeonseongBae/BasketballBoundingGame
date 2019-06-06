using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    static public ScoreManager S = null;

    public Text pointText;
    public Text maxPointText;
    public Text levelText;

    public int point = 0;
    public int maxPoint = 0;

    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        maxPoint = PlayerPrefs.GetInt("MaxPoint");
        maxPointText.text = maxPoint.ToString();
    }

    private void Update()
    {
        pointText.text = point.ToString();
        levelText.text = "Lv." + MapSetting.S.level;
        if(point > maxPoint)
        {
            maxPointText.text = point.ToString();
        }
    }
}
