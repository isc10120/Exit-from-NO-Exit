using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CameraController : MonoBehaviour  // 카메라 오브젝트는 폰 바깥에 만들기
{
    public static CameraController instance;

    [SerializeField]
    private GameObject TempImage;

    [SerializeField]
    private GameObject SaveOrNotPopUp;

    private byte[] PNGbuffer;
    private string FolderPath = $"{Application.dataPath}/ScreenShots/";
    private string TotalPath;

    void Awake(){
        if(instance==null)
            instance=this;
    }

    public void TakeScreenShot(){
        GameObject.Find("Main Camera").GetComponent<TakePicture>()._willTakeScreenShot = true;
    }

    public void SaveTemporary(byte[] PNGbuffer){  // Called by <TakePicture>
        
        this.PNGbuffer = PNGbuffer;

        // Save or Not 띄우기
        TempImage.GetComponent<Image>().sprite = MakeSprite(PNGbuffer);
        TempImage.SetActive(true);
        SaveOrNotPopUp.SetActive(true);
    }

    public void SaveScreenShot(){
        int num = PhoneController.instance.NumOfScreenShots++;

        if (Directory.Exists(FolderPath) == false){
            Directory.CreateDirectory(FolderPath);
        }

        TotalPath = string.Copy(FolderPath) + "ScreenShot_" + num.ToString();
        File.WriteAllBytes(TotalPath, PNGbuffer);
            
        PrintImage.instance.PrintToGallery(num);
        closePopUP();
    }

    public void DontSaveScreenShot(){
        PNGbuffer = null;
        closePopUP();
    }

    public Sprite MakeSprite(byte[] PNGbuffer){

        Texture2D imageTexture = new Texture2D(1, 1, TextureFormat.RGB24, false);
        imageTexture.LoadImage(PNGbuffer); // 텍스쳐 생성 후 이미지 로드

        Rect rect = new Rect(0, 0, imageTexture.width, imageTexture.height);
        return Sprite.Create(imageTexture, rect, Vector2.one * 0.5f); // 스프라이트 생성 후 반환
    }

    private void closePopUP(){
        SaveOrNotPopUp.SetActive(false);
        TempImage.SetActive(false);
    }
}
