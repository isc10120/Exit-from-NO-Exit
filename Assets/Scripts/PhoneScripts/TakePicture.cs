using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePicture : MonoBehaviour  // WorldToScreenPoint로 증거 오브젝트 인식하는 기능 추가하기
{
    public bool _willTakeScreenShot = false;
    Texture2D screenTex;
    Rect area;

    void Awake(){
        screenTex = new Texture2D(1920, 1080, TextureFormat.RGB24, false);
        area = new Rect(0f, 0f, 1920f, 1080f);
    }

    private void OnPostRender(){
        if (_willTakeScreenShot)
        {
            _willTakeScreenShot = false;
            screenTex.ReadPixels(area, 0, 0);

            CameraController.instance.SaveTemporary(screenTex.EncodeToPNG());
            
        }
    }
}
