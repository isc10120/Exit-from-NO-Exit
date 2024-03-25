using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TakePicture : MonoBehaviour
{
    public bool _willTakeScreenShot = false;
    private string FolderPath = $"{Application.dataPath}/ScreenShots/";
    private string TotalPath;
    Texture2D screenTex;
    Rect area;

    void Awake(){
        screenTex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        area = new Rect(0f, 0f, Screen.width, Screen.height);
    }

    private void OnPostRender(){
        if (_willTakeScreenShot)
        {
            int num = PhoneController.instance.NumOfScreenShots;
            _willTakeScreenShot = false;
            screenTex.ReadPixels(area, 0, 0);

            if (Directory.Exists(FolderPath) == false){
                Directory.CreateDirectory(FolderPath);
            }
            TotalPath = string.Copy(FolderPath) + "ScreenShot_" + num.ToString();
            File.WriteAllBytes(TotalPath, screenTex.EncodeToPNG());
            
            PrintImage.instance.PrintScreenshot(num);
        }
    }
}
