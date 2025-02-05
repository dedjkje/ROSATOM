using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;


public class DataBase : MonoBehaviour
{
    public bool tumblerLeft = false;
    public bool tumblerRight = false;
    public int polzunokLeft = 2;
    public int polzunokRight = 2;
    public int krugLeft = 2;
    public bool buttonLeft = false;

    int isOk = 8;
    bool flag = true;
    bool flagFirstLevelUp = false;
    bool flagFirstLevelDown = false;
    bool flagSecondLevel = false;
    bool flagFourthLevel = false;
    bool flagFifthLevel = false;
    bool flagSixthLevel = false;
    private Coroutine runningCoroutine;


    private int level = 0;

    [SerializeField]
    CalculationFormulas calculationFormulas;


    public void FirstLevelButton() {
        level = 1;
        Debug.Log("lvl 1");
    }

    public void SecondLevelButton() {
        level = 2;
        Debug.Log("lvl 2");
    }

    public void ThirdLevelButton() {
        level = 3;
        Debug.Log("lvl 3");
    }

    public void FourthLevelButton() {
        level = 4;
        Debug.Log("lvl 4");
    }

    public void FifthLevelButton() {
        level = 5;
        Debug.Log("lvl 5");
    }

    public void SixthLevelButton() {
        level = 6;
        Debug.Log("lvl 6");
    }

    public void SeventhLevelButton() {
        level = 7;
        Debug.Log("lvl 7");
    }

    IEnumerator PauseForAnySeconds(float timePause) {
        int t = 0;
        while (t < timePause) {
            t++;
            yield return new WaitForSeconds(1f);
        }
    }

    void ChangesEvent() {
        if (level == 1) {
            if (flagFirstLevelDown) {
                calculationFormulas.tempReactor -=5;
            }
            if (flagFirstLevelUp) {
                calculationFormulas.tempReactor +=5;
            }
        }
        if (level == 2) {
            if (flagSecondLevel) {
                calculationFormulas.contourPressure +=2;
            }
        }
        if (level == 4) {
            if (flagFourthLevel) {
                calculationFormulas.turbineSpeed += 18;
            }
        }
        if (level == 5) {
            if (flagFifthLevel) {
                // где радиация изменение ????
            }
        }
        if (level == 6) {
            if (flagSixthLevel) {
               calculationFormulas.coolingSystem -=2;
            }
        }
        }
    }
    void ChangesBySwitches () {
        if (polzunokLeft == 1)
        {
            calculationFormulas.tempReactor -= 0.2f;
            calculationFormulas.contourPressure -= 0.05f;
            calculationFormulas.turbineSpeed -= 0.2f;
            transform.Find("��������(��. �.)").transform.localPosition = new Vector3(5.57000017f, 3.79854393f, 0.100000001f);
        }
        if (polzunokLeft == 2)
        {
            transform.Find("��������(��. �.)").transform.localPosition = new Vector3(4.98600006f, 3.79854393f, -0.237000003f);
        }
        if (polzunokLeft == 3)
        {
            calculationFormulas.tempReactor += 0.2f;
            calculationFormulas.contourPressure += 0.05f;
            calculationFormulas.turbineSpeed += 0.2f;
            transform.Find("��������(��. �.)").transform.localPosition = new Vector3(4.3579998f, 3.79854393f, -0.600000024f);
        }

        if (polzunokRight == 1)
        {
            transform.Find("��������(��. �.).001").transform.localPosition = new Vector3(-4.80600023f, 3.74650908f, -0.456f);
            calculationFormulas.turbineSpeed -= 0.3f;
            calculationFormulas.coolingSystem -= 0.01f;
            calculationFormulas.liquidSupply -= 0.05f;
        }
        if (polzunokRight == 2)
        {
            transform.Find("��������(��. �.).001").transform.localPosition = new Vector3(-5.40779352f, 3.74650908f, -0.108942963f);
            calculationFormulas.coolingSystem += 0.005f;
            calculationFormulas.liquidSupply -= 0.1f;
        }
        if (polzunokRight == 3)
        {
            transform.Find("��������(��. �.).001").transform.localPosition = new Vector3(-6.00699997f, 3.74650908f, 0.237000003f);
            calculationFormulas.turbineSpeed += 0.3f;
            calculationFormulas.coolingSystem += 0.02f;
            calculationFormulas.liquidSupply -= 0.15f;
        }

        if (krugLeft == 1)
        {
            transform.Find("�����").transform.rotation = new Quaternion(0.0432651006f, -0.609830499f, -0.790297806f, 0.0407955013f);
            calculationFormulas.turbineSpeed -= 1f;
        }
        if (krugLeft == 2)
        {
            transform.Find("�����").transform.rotation = new Quaternion(-0.577853203f, -0.199626684f, -0.165138766f, 0.773927689f);
        }
        if (krugLeft == 3)
        {

            transform.Find("�����").transform.rotation = new Quaternion(-0.342384368f, 0.506495833f, 0.704815447f, 0.359819621f);
            calculationFormulas.turbineSpeed += 1f;
        }

        if (tumblerLeft)
        {
            calculationFormulas.poolVolume += 0.4f;

            GameObject.FindWithTag("ROSATOMroom").transform.Find("�������").transform.rotation = new Quaternion(-0.608761549f, -0.396676511f, -1.04308128e-07f, 0.687064171f);
        }
        else
        {
            calculationFormulas.poolVolume -= 0.2f;
            GameObject.FindWithTag("ROSATOMroom").transform.Find("�������").transform.rotation = new Quaternion(-0.527202964f, -1.52736888e-07f, -0.304380655f, 0.793353319f);
        }
        if (tumblerRight)
        {
            GameObject.FindWithTag("ROSATOMroom").transform.Find("�������.001").transform.rotation = new Quaternion(0.345815271f, 0.776155889f, -0.372770309f, 0.372875601f);
            calculationFormulas.liquidSupply += 0.6f;
        }
        else
        {
            GameObject.FindWithTag("ROSATOMroom").transform.Find("�������.001").transform.rotation = new Quaternion(0.485922545f, 0.485785812f, -0.710906267f, 0.150012299f);
        }

        if (buttonLeft)
        {
            calculationFormulas.contourPressure -= 0.3f;
            GameObject.FindWithTag("ROSATOMroom").transform.Find("������").transform.localPosition = new Vector3(3.83200002f, 3.76300001f, -0.924000025f);
        }
        else
        {
            GameObject.FindWithTag("ROSATOMroom").transform.Find("������").transform.localPosition = new Vector3(3.8300271f, 3.77922201f, -0.920185685f);
        }

    }


    void DisplayingDangerZones() {
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
        if ((calculationFormulas.contourPressure < 60 || calculationFormulas.contourPressure > 180) && level == 2)
        {
            if (runningCoroutine != null) {
                StopCoroutine(runningCoroutine);
                runningCoroutine = null;
            }
            flag = false;
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
        if ((calculationFormulas.tempReactor < 550 || calculationFormulas.tempReactor > 850) && level == 1)
        {
            if (runningCoroutine != null) {
                StopCoroutine(runningCoroutine);
                runningCoroutine = null;
            }
            flag = false;
            // рестарт уровня
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
           if (runningCoroutine != null) {
                StopCoroutine(runningCoroutine);
                runningCoroutine = null;
            }
            flag = false;
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
           if (runningCoroutine != null) {
                StopCoroutine(runningCoroutine);
                runningCoroutine = null;
            }
            flag = false;
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
            if (runningCoroutine != null) {
                StopCoroutine(runningCoroutine);
                runningCoroutine = null;
            }
            flag = false;
        }

        if (calculationFormulas.coolingSystem > 100 || calculationFormulas.coolingSystem < 40)
        {
            if (runningCoroutine != null) {
                StopCoroutine(runningCoroutine);
                runningCoroutine = null;
            }
            flag = false;
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
            if (runningCoroutine != null) {
                StopCoroutine(runningCoroutine);
                runningCoroutine = null;
            }
            flag = false;
        }
    }

    void StartFirstLevel() {
        Time.timeScale = 0f;

        runningCoroutine = StartCoroutine(PauseForAnySeconds(7));
        if (flag==false) {break;}

        Time.timeScale = 0.02f;

        runningCoroutine = StartCoroutine(PauseForAnySeconds(10));
        if (flag==false) {break;}
        flagFirstLevelUp = true;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(40));
        flagFirstLevelUp = false;
        if (flag==false) {break;}
        runningCoroutine = StartCoroutine(PauseForAnySeconds(10));
        if (flag==false) {break;}
        flagFirstLevelDown = true;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(40));
        flagFirstLevelDown = false;
        if (flag==false) {break;}
        runningCoroutine = StartCoroutine(PauseForAnySeconds(10));
        if (flag==false) {break;}
        flagFirstLevelUp = true;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(40));
        flagFirstLevelUp = false;
        if (flag==false) {break;}

    }

    void StartSecondLevel() {
        Time.timeScale = 0f;

        runningCoroutine = StartCoroutine(PauseForAnySeconds(7));
        if (flag==false) {break;}

        Time.timeScale = 0.02f;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(10));
        if (flag==false) {break;}
        flagSecondLevel = true;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(40));
        flagSecondLevel = false;
        if (flag==false) {break;}
        runningCoroutine = StartCoroutine(PauseForAnySeconds(20));
        if (flag==false) {break;}
        flagSecondLevel = true;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(40));
        flagSecondLevel = false;
        if (flag==false) {break;}
    }

    void StartThirdLevel() {
        Time.timeScale = 0f;

        runningCoroutine = StartCoroutine(PauseForAnySeconds(7));
        if (flag==false) {break;}

        Time.timeScale = 0.02f;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(60));
        if (flag==false) {break;}
    }

    void StartFourthLevel() {
        Time.timeScale = 0f;

        runningCoroutine = StartCoroutine(PauseForAnySeconds(7));
        if (flag==false) {break;}

        Time.timeScale = 0.02f;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(10));
        if (flag==false) {break;}
        flagFourthLevel = true;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(40));
        flagFourthLevel = false;
        if (flag==false) {break;}
        runningCoroutine = StartCoroutine(PauseForAnySeconds(20));
        if (flag==false) {break;}
        flagFourthLevel = true;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(40));
        flagFourthLevel = false;
        if (flag==false) {break;}
        runningCoroutine = StartCoroutine(PauseForAnySeconds(15));
        if (flag==false) {break;}
        flagFourthLevel = true;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(40));
        flagFourthLevel = false;
        if (flag==false) {break;}
    }

    void StartFifthLevel() {
        Time.timeScale = 0f;

        runningCoroutine = StartCoroutine(PauseForAnySeconds(7));
        if (flag==false) {break;}

        Time.timeScale = 0.02f;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(10));
        if (flag==false) {break;}
        flagFifthLevel = true;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(20));
        flagFifthLevel = false;
        if (flag==false) {break;}
        runningCoroutine = StartCoroutine(PauseForAnySeconds(10));
        if (flag==false) {break;}
        flagFifthLevel = true;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(20));
        flagFifthLevel = false;
        if (flag==false) {break;}
    }

    void StartSixthLevel() {
        Time.timeScale = 0f;

        runningCoroutine = StartCoroutine(PauseForAnySeconds(7));
        if (flag==false) {break;}

        Time.timeScale = 0.02f;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(10));
        flagSixthLevel = true;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(30));
        flagSixthLevel = false;
        if (flag==false) {break;}

    }

    void StartSeventhLevel() {
        Time.timeScale = 0f;

         runningCoroutine = StartCoroutine(PauseForAnySeconds(7));
        if (flag==false) {break;}

        Time.timeScale = 0.02f;
        runningCoroutine = StartCoroutine(PauseForAnySeconds(60));
        if (flag==false) {break;}
    }


    void Start()
    {
        while (true) {
            flag = true;
            if (level == 1) {
                StartFirstLevel();
            }
            if (level == 2) {
                StartSecondLevel();
            }
            if (level == 3) {
                StartThirdLevel();
            }
            if (level == 4) {
                StartFourthLevel();
            }
            if (level == 5) {
                StartFifthLevel();
            }
            if (level == 6) {
                StartSixthLevel();
            }
            if (level == 7) {
                StartSeventhLevel();
            }
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        ChangesBySwitches();
        DisplayingDangerZones();
        ChangesEvent();









}
