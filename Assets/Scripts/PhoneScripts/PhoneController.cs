using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public static PhoneController instance;
    private Stack<GameObject> TabStack;
    public GameObject ChocoTalk;
    public GameObject Allbum;
    public int NumOfScreenShots = 1;

    void Awake(){
        if(instance == null){
            instance = this;
            TabStack = new Stack<GameObject>();
        }
    }
    public void ActiveTab(GameObject tab){
        TabStack.Push(tab);
        tab.SetActive(true);
    }
    public void Backward(){
        if(TabStack.Count!=0)
            TabStack.Pop().SetActive(false);
    }

    public void Home(){
        while(TabStack.Count!=0){
            TabStack.Pop().SetActive(false);
        }
    }
    
    public void ActiveChocoTalk(){
        ActiveTab(ChocoTalk);
    }
    
    public void TakeScreenShotAndUpload(){ // 카메라로 옮길 코드
        //NumOfScreenShots++;
        GameObject.Find("Main Camera").GetComponent<TakePicture>()._willTakeScreenShot = true;
    }
}
