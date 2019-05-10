using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class ReadXmlData : MonoBehaviour {

    public static ReadXmlData _instance;
   public  List<List<string>> questionList = new List<List<string>>();
    List<string> itemList;
    private void Awake()
    {
        _instance = this;
      //  LoadXmlData();
    }
    void Start () {
        LoadXmlData();
	}
	

    //点击货币知识问答时执行
    public  void LoadXmlData()
    {
        string filePath = Application.dataPath + "/data.xml";
        if(File.Exists (filePath ))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNodeList tis = xmlDoc.GetElementsByTagName("ti");
            foreach (XmlNode ti  in tis)
            {
                itemList = new List<string>();
             
                string question = ti.Attributes[0].Value;
                string a = ti.Attributes[1].Value;
                string b = ti.Attributes[2].Value;
                string c = ti.Attributes[3].Value;
                string answer = ti.Attributes[4].Value;
                string detail = ti.Attributes[5].Value;
                itemList.Add(question);
                itemList.Add(a);
                itemList.Add(b);
                itemList.Add(c);
                itemList.Add(answer);
                itemList.Add(detail);
                questionList.Add(itemList );
                
            }
        }else
        {
            throw new System.Exception("文档不存在");
        }
    }
}
