using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QAManager : MonoBehaviour {

    public GameObject Panel_QA;
    public GameObject questionPanel;
    public GameObject answerPanel;
    public Text question;
    public Text a;
    public Text b;
    public Text c;
    public Text right;
    public Text detail;
    public Text result;//是否正确;
    public Text titleText;
    private int questionIndex;
    string   rightStr;//正确答案的字母
    public GameObject canvasTrans;
	void Start () {
      
        RefreshQA();
 
      Button [] btns=  questionPanel.GetComponentsInChildren<Button>();
        foreach (Button  item in btns)
        {
            item.onClick.AddListener(delegate { Check(item ); });
        }
	}

  //  private void 
    public void RefreshQA()
    {
        if(questionIndex <ReadXmlData ._instance .questionList .Count )
        {
            List<string> temp = ReadXmlData._instance.questionList[questionIndex];
            question.text = temp[0];
            a.text = temp[1];
            b.text = temp[2];
            c.text = temp[3];
            right.text = " 正确答案：" + temp[4];
            rightStr = temp[4];
            detail.text = temp[5];
            questionIndex++;
            titleText.text = "第" + questionIndex.ToString() + "题";
        }
        else
        {
           // answerPanel.SetActive(false);
            canvasTrans.SetActive(true);
        }
        
    }

    /// <summary>
    /// 返回首页
    /// </summary>
    public void RerturnBtn()
    {
        SceneManager.LoadScene(0);
    }
    public void JumbToChallenge()
    {
        SceneManager.LoadScene(1);
    }
     //下一题
    public void NextBtn()
    {
        RefreshQA();
        answerPanel.SetActive(false);
        questionPanel.SetActive(true);
       
    }

    private void Check(Button btn)
    {
        answerPanel.SetActive(true);
        questionPanel.SetActive(false);
        if(rightStr.Substring (0,1) ==btn.name.Substring (0,1))
        {
            result.text = "回答正确";
        }
        else
        {
            result.text = "回答错误";
        }
     
    }
}
