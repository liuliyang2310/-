using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChallengeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// 点击跳转的Scene_2趣味问答
    /// </summary>
    public void OnClickJumbToQA()
    {
        SceneManager.LoadScene(0);
    }
    
}
