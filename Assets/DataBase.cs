using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public bool tumblerLeft = false;
    public bool tumblerRight = false;
    public int polzunokLeft = 2;
    public int polzunokRight = 2;
    public int krugLeft = 2;
    public bool buttonLeft = false;

    [SerializeField]
    CalculationFormulas calculationFormulas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (polzunokLeft == 1)
        {
            calculationFormulas.tempReactor -= 0.2f;
            transform.Find("Ползунок(гл. ч.)").transform.localPosition = new Vector3(5.57000017f, 3.79854393f, 0.100000001f);
        }
        if (polzunokLeft == 2)
        {
            transform.Find("Ползунок(гл. ч.)").transform.localPosition = new Vector3(4.98600006f, 3.79854393f, -0.237000003f);
        }
        if (polzunokLeft == 3)
        {
            calculationFormulas.tempReactor += 0.2f;
            transform.Find("Ползунок(гл. ч.)").transform.localPosition = new Vector3(4.3579998f, 3.79854393f, -0.600000024f);
        }

        if (polzunokRight == 1)
        {
            transform.Find("Ползунок(гл. ч.).001").transform.localPosition = new Vector3(-4.80600023f, 3.74650908f, -0.456f);
        }
        if (polzunokRight == 2)
        {
            transform.Find("Ползунок(гл. ч.).001").transform.localPosition = new Vector3(-5.40779352f, 3.74650908f, -0.108942963f);
        }
        if (polzunokRight == 3)
        {
            transform.Find("Ползунок(гл. ч.).001").transform.localPosition = new Vector3(-6.00699997f, 3.74650908f, 0.237000003f);
        }

        if (krugLeft == 1)
        {
            transform.Find("Ручка").transform.rotation = new Quaternion(0.0432651006f, -0.609830499f, -0.790297806f, 0.0407955013f);
        }
        if (krugLeft == 2)
        {
            transform.Find("Ручка").transform.rotation = new Quaternion(-0.577853203f, -0.199626684f, -0.165138766f, 0.773927689f);
        }
        if (krugLeft == 3)
        {
            transform.Find("Ручка").transform.rotation = new Quaternion(-0.342384368f, 0.506495833f, 0.704815447f, 0.359819621f);
        }

        if(tumblerLeft)
        {
            calculationFormulas.poolVolume += 0.4f;

            GameObject.FindWithTag("ROSATOMroom").transform.Find("Тумблер").transform.rotation = new Quaternion(-0.608761549f, -0.396676511f, -1.04308128e-07f, 0.687064171f);
        }
        else
        {
            GameObject.FindWithTag("ROSATOMroom").transform.Find("Тумблер").transform.rotation = new Quaternion(-0.527202964f, -1.52736888e-07f, -0.304380655f, 0.793353319f);
        }
        if (tumblerRight)
        {
            GameObject.FindWithTag("ROSATOMroom").transform.Find("Тумблер.001").transform.rotation = new Quaternion(0.345815271f, 0.776155889f, -0.372770309f, 0.372875601f);
        }
        else
        {
            GameObject.FindWithTag("ROSATOMroom").transform.Find("Тумблер.001").transform.rotation = new Quaternion(0.485922545f, 0.485785812f, -0.710906267f, 0.150012299f);
        }

        if (buttonLeft)
        {
            GameObject.FindWithTag("ROSATOMroom").transform.Find("Кнопка").transform.localPosition = new Vector3(3.83200002f, 3.76300001f, -0.924000025f);
        }
        else
        {
            GameObject.FindWithTag("ROSATOMroom").transform.Find("Кнопка").transform.localPosition = new Vector3(3.8300271f, 3.77922201f, -0.920185685f);
        }
    }
}
