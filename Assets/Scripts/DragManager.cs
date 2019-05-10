using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragManager : MonoBehaviour,IBeginDragHandler ,IDragHandler ,IEndDragHandler {
    public RectTransform _Target;
    Vector2 _initPos;
    Transform _trans;
    public RectTransform _CanvasRT;
    Vector3 _offset;
   
    void Start()
    {
        _trans = this.transform;
        _initPos = _trans.position;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _trans.parent.SetAsLastSibling();
      //  _trans.SetAsLastSibling();
        Vector3 outPos = new Vector3();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(_CanvasRT, eventData.position, eventData .enterEventCamera, out outPos);
        _offset = _trans.position - outPos;

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 outPos = new Vector3();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(_CanvasRT, eventData.position, eventData.enterEventCamera, out outPos);
      _trans.position = outPos +_offset ;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
      // RectTransformUtility.Re
       if( RectTransformUtility.RectangleContainsScreenPoint(_Target, eventData.position))
        {
           // print("面额匹配");
            Match();
            LevelMananger._Instance.Calculate();
        }
       else
        {

            UnMatch();
        }
    }
    /// <summary>
    /// 拖拽的面额与数字匹配后调用
    /// </summary>
    void Match()
    {
       _trans.parent.Find("Correct").gameObject .SetActive (true );
        _trans.gameObject.SetActive(false);
        _trans.position = _initPos;
    }
    /// <summary>
    /// 拖拽的面额与数字不匹配
    /// </summary>
    void UnMatch()
    {
        _trans.position = _initPos;
    }
 
}
