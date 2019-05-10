using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	
	//void Start () {
 //       Button[] btns = transform.GetComponentsInChildren<Button>();
 //       for (int i = 0; i < btns.Length; i++)
 //       {
 //           btns[i].onClick.AddListener(delegate( ) { OnClickChallenge(i); });
 //       }
      
 //   }
	


    public void OnClickChallenge(int btnIndex)
    {
      
        SceneManager.LoadScene(btnIndex);
    }

}
