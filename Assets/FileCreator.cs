using System.IO;
using UnityEngine;

public class FileCreator : MonoBehaviour
{
    public CameraRotation cameraRotation;
    public Player player;

    void Start()
    {
        CreateTextFile();
    }

    void CreateTextFile()
    {
        string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        string folderName = "ROSATOM";
        string fileName = "settings.txt";

        string folderPath = Path.Combine(documentsPath, folderName);
        string filePath = Path.Combine(folderPath, fileName);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        if (!File.Exists(filePath))
        {
            string textToWrite = cameraRotation.sensivity.ToString() + "split" + player.volume.ToString();
            File.WriteAllText(filePath, textToWrite);
        }
        
    }
}