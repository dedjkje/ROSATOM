using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CalculationFormulas : MonoBehaviour
{
    public Text PowerText;
    public Text WaterLevelText;
    public Text PressureText;
    public Text SpeedText;
    public Text RadiationText;
    public Text CoolingSystemText;
    public Text CoolingLiquidText;
    public Text EnergyConsumptionText;
    private double k = 0.05;
    private double m = 0.15;
    private int n = 30;
    private int p = 2;
    private double q = 0.001;
    private double r = 0.005;
    private double s = 0.01;
    private double u = 0.02;
    private int v = 60;
    private double w = 0.015;
    private double l = 0.035;

    public float tempReactor = 700;
    public float contourPressure = 95;
    public float poolVolume = 4200;
    public float turbineSpeed = 2100;
    public double radiationAround = 0.3;
    public float coolingSystem = 85;
    public float liquidSupply = 7500;
    public float energyConsumption = 35;

    public int timePool = 0;
    public int timeLiquid = 0;

    private void CalculateDeltaT(ref double tempReactor, int startingTemp, double k, double contourPressure) {
        tempReactor = startingTemp + k * contourPressure;
    }

    private void CalculateDeltaP(ref double contourPressure, int startingPressure, double m, double tempReactor) {
        contourPressure = startingPressure + m * tempReactor;
    }

    private void CalculateDeltaV(ref int poolVolume, int startingVolume, int n,int timePool) {
        poolVolume = startingVolume - n * timePool;
    }

    private void CalculateDeltaN(ref double turbineSpeed, int startingSpeed, int p, double energyConsumption) {
        turbineSpeed = startingSpeed + p * energyConsumption;
    }

    private void CalculateDeltaR(ref double radiationAround, double startingRadiation, double q, double r, double tempReactor, double contourPressure) {
        radiationAround = startingRadiation + q * tempReactor + r * contourPressure;
    }

    private void CalculateDeltaS(ref double coolingSystem, int startingCooling, double s, double u, double tempReactor, double radiationAround) {
        coolingSystem = startingCooling - s * tempReactor - u * radiationAround;
    }

    private void CalculateDeltaQ(ref int liquidSupply, int startingReserve, int v, int timeLiquid) {
        liquidSupply = startingReserve - v * timeLiquid;
    }

    private void CalculateDeltaE(ref double energyConsumption, int startingEnergy, double w, double turbineSpeed) {
        energyConsumption = startingEnergy + w * turbineSpeed;
    }

    private void OutputPower(float value) {

        int percent = (int)((float)value / 900f * 100f);
        PowerText.text = $"Мощность:       |[{new string('=', percent / 20)}{new string(' ', 5 - percent / 20)}] {percent}% |";
    }

    private void OutputWaterLevel (float value) {
        int percent = (int)((float)value / 4200f * 100f);
        WaterLevelText.text = $"Уровень воды: |[{new string('=', percent / 20)}{new string(' ', 5 - percent / 20)}] {percent}% |";
    }

    private void OutputPressure (float value) {
        int percent = (int)((float)value / 180f * 100f);
        PressureText.text = $"Давление:        |[{new string('=', percent / 20)}{new string(' ', 5 - percent / 20)}] {percent}% |";
    }

    private void OutputSpeed (float value) {
        int percent = (int)((float)value / 2900f * 100f);
        SpeedText.text = $"Турбины:          |[{new string('=', percent / 20)}{new string(' ', 5 - percent / 20)}] {percent}% |";
    }

    private void OutputRadiation (double value) {
        int percent = (int)((float)value / 5f * 100f);
        RadiationText.text = $"Радиация:               |[{new string('=', percent / 20)}{new string(' ', 5 - percent / 20)}] {percent}% |";
    }

    private void OutputCoolingSystem (float value) {
        int percent = (int)((float)value / 100f * 100f);
        CoolingSystemText.text = $"Охлаждение:          |[{new string('=', percent / 20)}{new string(' ', 5 - percent / 20)}] {percent}% |";
    }
    //антон лох
    private void OutputCoolingLiquid (float value) {
        int percent = (int)((float)value / 7500f * 100f);
        CoolingLiquidText.text = $"Уровень топлива: |[{new string('=', percent / 20)}{new string(' ', 5 - percent / 20)}] {percent}% |";
    }

    private void OutputEnergy (float value) {
        int percent = (int)((float)value / 75f * 100f);
        EnergyConsumptionText.text = $"Энергия:                 |[{new string('=', percent / 20)}{new string(' ', 5 - percent / 20)}] {percent}% |";
    }

    void Update () {
        OutputPower(tempReactor);
        OutputWaterLevel(poolVolume);
        OutputPressure(contourPressure);
        OutputSpeed(turbineSpeed);
        OutputRadiation(radiationAround);
        OutputCoolingSystem(coolingSystem);
        OutputCoolingLiquid(liquidSupply);
        OutputEnergy(energyConsumption);
    }


}
