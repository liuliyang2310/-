using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMananger : MonoBehaviour {

    public static LevelMananger _Instance;
    private int _cout;//答题正确的数目
    private int _numQA=8;//问题的数目
                         // int _nextSceneIndex;
    string nexScene;
    public GameObject _InterMid;//跳转面板
    public GameObject _Challenge;//Leve3答题面板
    void Awake()
    {
        _Instance = this;
     
    }
    void Start()
    {
        
        if (_Instance.name == "LevelManager_3")
        {
            _numQA = 5;
            //_nextSceneIndex = 4;
            nexScene = "QA";
        }
        else if(_Instance .name =="LevelManager_2")
        {
            _numQA = 8;
            // _nextSceneIndex = 3;
            nexScene = "Level3";
        }else
        {
            _numQA = 8;
            // _nextSceneIndex = 2;
            nexScene = "Level2";
        }
    }
    /// <summary>
    /// 答题正确后调用 _count++
    /// </summary>

    public void Calculate()
    {
        _cout++;
        if(_cout ==_numQA )
        {
           // print("通过关");
            if(nexScene !="QA"  )
            {
                SceneManager.LoadScene(nexScene );
         
            }else
            {
                if (_InterMid != null)
                {
                    _InterMid.SetActive(true);
                    _Challenge.SetActive(false);
                }
            }
             
        }
    }
    /// <summary>
    /// 返回主页
    /// </summary>
    public void OnClickReturn()
    {
        SceneManager.LoadScene(0);
    }
   

    public void OnClickJumbToQA()
    {
        SceneManager.LoadScene(nexScene );
    }
   
}
