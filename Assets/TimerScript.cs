using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public int secondsToWin;
    public TMPro.TMP_Text timer;
    public DataBase dataBase;
    private float secondsLeft;
    private bool boolControler;
    public float time;
    void Start()
    {
        boolControler = true;

    }

    void Update()
    {
        time = Time.timeSinceLevelLoad;
        secondsLeft = secondsToWin - time;
        if (secondsLeft > 0)
        {
            timer.text = Mathf.Floor(secondsLeft / 60).ToString() + ":" + ZeroFill(Mathf.Floor(secondsLeft % 60).ToString(), 2);
        }
        else
        {
            timer.text = "";
            if (boolControler)
            {
                dataBase.Win();
                boolControler = false;
            }
        }
    }

    string ZeroFill(string text, int length)
    {
        string result = text;
        for (int i = text.Length; i < length; i++)
        {
            result = "0" + result;
        }
        return result;
    }
}
