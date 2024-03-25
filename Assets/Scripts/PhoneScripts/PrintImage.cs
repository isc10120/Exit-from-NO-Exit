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
    public void PrintScreenshot(int num){
        GameObject picture = Instantiate(emptyImage,gameObject.transform);
        picture.GetComponent<Image>().sprite = MakeSprite(num);
    }
    
    Sprite MakeSprite(int num){

        string totalPath = string.Copy(Path) + num.ToString(); // 파일 지정

        Texture2D imageTexture = new Texture2D(1, 1, TextureFormat.RGB24, false);
        imageTexture.LoadImage(File.ReadAllBytes(totalPath)); // 텍스쳐 생성 후 파일 읽어와 로드

        Rect rect = new Rect(0, 0, imageTexture.width, imageTexture.height);
        return Sprite.Create(imageTexture, rect, Vector2.one * 0.5f); // 스프라이트 생성 후 반환
    }
}
