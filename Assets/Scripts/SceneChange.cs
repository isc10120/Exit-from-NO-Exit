using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void sceneChange(){
        if(SceneManager.GetActiveScene().name=="NewScene"){
            SceneManager.LoadScene("SampleScene");
        }
        else if(SceneManager.GetActiveScene().name=="SampleScene"){
            SceneManager.LoadScene("NewScene");
        }
    }
}
