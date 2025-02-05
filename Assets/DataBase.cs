using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DataBase : MonoBehaviour
{
    public bool tumblerLeft = false;
    public bool tumblerRight = false;
    public int polzunokLeft = 2;
    public int polzunokRight = 2;
    public int krugLeft = 2;
    public bool buttonLeft = false;

    int isOk = 8;

    [SerializeField]
    CalculationFormulas calculationFormulas;
    [SerializeField]
    Player player;

    [SerializeField]
    Canvas lose;

    [SerializeField]
    Canvas win;

    // Start is called before the first frame update
    void Start()
    {
        lose.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (polzunokLeft == 1)
        {
            calculationFormulas.tempReactor -= (0.2f / 1.5f);
            calculationFormulas.contourPressure -= 0.05f / 1.5f;
            calculationFormulas.turbineSpeed -= 0.2f / 1.5f;
            transform.Find("Ползунок(гл. ч.)").transform.localPosition = new Vector3(5.57000017f, 3.79854393f, 0.100000001f);
        }
        if (polzunokLeft == 2)
        {
            transform.Find("Ползунок(гл. ч.)").transform.localPosition = new Vector3(4.98600006f, 3.79854393f, -0.237000003f);
        }
        if (polzunokLeft == 3)
        {
            calculationFormulas.tempReactor += 0.2f / 1.5f;
            calculationFormulas.contourPressure += 0.05f / 1.5f;
            calculationFormulas.turbineSpeed += 0.2f / 1.5f;
            transform.Find("Ползунок(гл. ч.)").transform.localPosition = new Vector3(4.3579998f, 3.79854393f, -0.600000024f);
        }

        if (polzunokRight == 1)
        {
            transform.Find("Ползунок(гл. ч.).001").transform.localPosition = new Vector3(-4.80600023f, 3.74650908f, -0.456f);
            calculationFormulas.turbineSpeed -= 0.3f / 1.5f;
            if (calculationFormulas.coolingSystem < 100)
                calculationFormulas.coolingSystem += 0.01f / 1.5f;
            calculationFormulas.liquidSupply -= 0.05f / 1.5f;
        }
        if (polzunokRight == 2)
        {
            transform.Find("Ползунок(гл. ч.).001").transform.localPosition = new Vector3(-5.40779352f, 3.74650908f, -0.108942963f);
            if (calculationFormulas.coolingSystem < 100)
                calculationFormulas.coolingSystem += 0.005f / 1.5f;
            calculationFormulas.liquidSupply -= 0.1f / 1.5f;
        }
        if (polzunokRight == 3)
        {
            transform.Find("Ползунок(гл. ч.).001").transform.localPosition = new Vector3(-6.00699997f, 3.74650908f, 0.237000003f);
            calculationFormulas.turbineSpeed += 0.3f / 1.5f;
            calculationFormulas.coolingSystem -= 0.02f / 1.5f;
            calculationFormulas.liquidSupply -= 0.15f / 1.5f;
        }

        if (krugLeft == 1)
        {
            transform.Find("Ручка").transform.rotation = new Quaternion(0.0432651006f, -0.609830499f, -0.790297806f, 0.0407955013f);
            calculationFormulas.turbineSpeed -= 1f / 1.5f;
        }
        if (krugLeft == 2)
        {
            transform.Find("Ручка").transform.rotation = new Quaternion(-0.577853203f, -0.199626684f, -0.165138766f, 0.773927689f);
        }
        if (krugLeft == 3)
        {

            transform.Find("Ручка").transform.rotation = new Quaternion(-0.342384368f, 0.506495833f, 0.704815447f, 0.359819621f);
            calculationFormulas.turbineSpeed += 1f / 1.5f;
        }

        if (tumblerLeft)
        {
            calculationFormulas.poolVolume += 0.4f / 1.5f;

            GameObject.FindWithTag("ROSATOMroom").transform.Find("Тумблер").transform.rotation = new Quaternion(-0.608761549f, -0.396676511f, -1.04308128e-07f, 0.687064171f);
        }
        else
        {
            calculationFormulas.poolVolume -= 0.2f / 1.5f;
            GameObject.FindWithTag("ROSATOMroom").transform.Find("Тумблер").transform.rotation = new Quaternion(-0.527202964f, -1.52736888e-07f, -0.304380655f, 0.793353319f);
        }
        if (tumblerRight)
        {
            GameObject.FindWithTag("ROSATOMroom").transform.Find("Тумблер.001").transform.rotation = new Quaternion(0.345815271f, 0.776155889f, -0.372770309f, 0.372875601f);
            calculationFormulas.liquidSupply += 0.6f / 1.5f;
        }
        else
        {
            GameObject.FindWithTag("ROSATOMroom").transform.Find("Тумблер.001").transform.rotation = new Quaternion(0.485922545f, 0.485785812f, -0.710906267f, 0.150012299f);
        }

        if (buttonLeft)
        {
            calculationFormulas.contourPressure -= 0.3f / 1.5f;
            GameObject.FindWithTag("ROSATOMroom").transform.Find("Кнопка").transform.localPosition = new Vector3(3.83200002f, 3.76300001f, -0.924000025f);
        }
        else
        {
            GameObject.FindWithTag("ROSATOMroom").transform.Find("Кнопка").transform.localPosition = new Vector3(3.8300271f, 3.77922201f, -0.920185685f);
        }









        if (calculationFormulas.contourPressure < 80)
        {
            calculationFormulas.PressureText.color = Color.red;
        }
        if (calculationFormulas.contourPressure > 160)
        {
            calculationFormulas.PressureText.color = Color.red;
        }
        if (calculationFormulas.contourPressure > 80 && calculationFormulas.contourPressure < 160)
        {
            calculationFormulas.PressureText.color = Color.green;
        }
        if (calculationFormulas.contourPressure < 60 || calculationFormulas.contourPressure > 180)
        {
            Lose();
        }

        if (calculationFormulas.tempReactor < 600)
        {
            calculationFormulas.PowerText.color = Color.red;
        }
        if (calculationFormulas.tempReactor > 800)
        {
            calculationFormulas.PowerText.color = Color.red;
        }
        if (calculationFormulas.tempReactor > 600 && calculationFormulas.tempReactor < 800)
        {
            calculationFormulas.PowerText.color = Color.green;
        }
        if (calculationFormulas.tempReactor < 550 || calculationFormulas.tempReactor > 850)
        {
            Lose();
        }

        if (calculationFormulas.poolVolume < 3600)
        {
            calculationFormulas.WaterLevelText.color = Color.red;
        }
        if (calculationFormulas.poolVolume > 3900)
        {
            calculationFormulas.WaterLevelText.color = Color.red;
        }
        if (calculationFormulas.poolVolume > 3600 && calculationFormulas.poolVolume < 3900)
        {
            calculationFormulas.WaterLevelText.color = Color.green;
        }
        if (calculationFormulas.poolVolume < 3400 || calculationFormulas.poolVolume > 4000)
        {
            Lose();
        }

        if (calculationFormulas.turbineSpeed < 2200)
        {
            calculationFormulas.SpeedText.color = Color.red;
        }
        if (calculationFormulas.turbineSpeed > 2800)
        {
            calculationFormulas.SpeedText.color = Color.red;
        }
        if (calculationFormulas.turbineSpeed > 2200 && calculationFormulas.turbineSpeed < 2800)
        {
            calculationFormulas.SpeedText.color = Color.green;
        }
        if (calculationFormulas.turbineSpeed < 2000 || calculationFormulas.turbineSpeed > 3000)
        {
            Lose();
        }

        calculationFormulas.radiationAround -= 0.0002f;

        if (calculationFormulas.radiationAround < 4)
        {
            calculationFormulas.RadiationText.color = Color.red;
        }
        if (calculationFormulas.radiationAround > 4)
        {
            calculationFormulas.RadiationText.color = Color.green;
        }
        if (calculationFormulas.radiationAround < 3)
        {
            Lose();
        }

        if (calculationFormulas.coolingSystem < 40)
        {
            Lose();
        }
        if (calculationFormulas.coolingSystem < 70)
        {
            calculationFormulas.CoolingSystemText.color = Color.red;
        }
        else
        {
            calculationFormulas.CoolingSystemText.color = Color.green;
        }

        if (calculationFormulas.liquidSupply < 5000)
        {
            calculationFormulas.CoolingLiquidText.color = Color.red;
        }
        if (calculationFormulas.liquidSupply > 6700)
        {
            calculationFormulas.CoolingLiquidText.color = Color.red;
        }
        if (calculationFormulas.liquidSupply > 5000 && calculationFormulas.liquidSupply < 6700)
        {
            calculationFormulas.CoolingLiquidText.color = Color.green;
        }
        if (calculationFormulas.liquidSupply < 3000 || calculationFormulas.liquidSupply > 7000)
        {
            Lose();
        }
    }

    public void Lose()
    {
        lose.enabled = true;
        player.enabled = false;
        player.cameraRotation.enabled = false;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }
    public void Win()
    {
        win.enabled = true;
        player.enabled = false;
        player.cameraRotation.enabled = false;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }
}