using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PrintImage : MonoBehaviour
{
    public static PrintImage instance;
    private string Path = $"{Application.dataPath}/ScreenShots/ScreenShot_";

    [SerializeField]
    private GameObject emptyImage;

    void Awake(){
        if(instance==null){
            instance = this;
        }
    }
    public void PrintToGallery(int num){  // GameManager에 num값 저장해야함
        
        string totalPath = string.Copy(Path) + num.ToString(); // 파일 지정

        GameObject picture = Instantiate(emptyImage,gameObject.transform);
        picture.GetComponent<Image>().sprite = CameraController.instance.MakeSprite(File.ReadAllBytes(totalPath));
    }
}
