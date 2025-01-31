using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Slider sensitivitySlider;
    public Slider volumeSlider;

    private string filePath;

    void Start()
    {
        string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        string folderName = "ROSATOM";
        filePath = Path.Combine(documentsPath, folderName, "settings.txt");

        LoadSettings();

        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void LoadSettings()
    {
        string[] values = File.ReadAllText(filePath).Split(new string[] { "split" }, System.StringSplitOptions.None);
        if (values.Length == 2)
        {
            if (float.TryParse(values[0], out float sensitivity))
            {
                sensitivitySlider.value = sensitivity;
            }
            if (float.TryParse(values[1], out float volume))
            {
                volumeSlider.value = volume;
            }
        }
    }

    void OnSensitivityChanged(float value)
    {
        SaveSettings();
    }

    void OnVolumeChanged(float value)
    {
        SaveSettings();
    }

    void SaveSettings()
    {
        string textToWrite = sensitivitySlider.value.ToString() + "split" + volumeSlider.value.ToString();
        File.WriteAllText(filePath, textToWrite);
    }
}