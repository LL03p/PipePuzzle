using System;
using UnityEngine;

public class SlotCheck : MonoBehaviour
{
    public GameObject WinPanel;
    
    public bool isTop;
    public bool isLeft;
    public bool isRight;
    public bool isBottom;
    public bool isTrue;
    public bool isEnd;

    [Serializable]
    public class SlotData
    {
        public ScriptGameplay.ConnectionPoint point;
        public GameObject slotObject;
    }

    public SlotData[] Grid;

    void Update()
    {
        CheckEnd();
    }
    
    public void CheckSlot()
    {
        SlotCheck[] allSlotChecks = FindObjectsOfType<SlotCheck>();

        foreach (SlotCheck slotCheck in allSlotChecks)
        {
            if (slotCheck.transform.childCount == 0)
            {
                slotCheck.isTop = false;
                slotCheck.isLeft = false;
                slotCheck.isRight = false;
                slotCheck.isBottom = false;
                slotCheck.isTrue = false;
            }
        }
        
        if (Grid[0].slotObject == null)
            isTop = false;
        if (Grid[1].slotObject == null)
            isLeft = false;
        if (Grid[2].slotObject == null)
            isRight = false;
        if (Grid[3].slotObject == null)
            isBottom = false;
    }

    public void CheckEnd()
    {
        if (Grid[0].slotObject == null)
        {
            
        }
        
        else if (Grid[0].slotObject.GetComponent<SlotCheck>() != null)
        {
            if (Grid[0].slotObject.GetComponent<SlotCheck>().isBottom && isTop)
            {
                if (Grid[0].slotObject.GetComponent<SlotCheck>().isTrue)
                    isTrue = true;

                if (Grid[0].slotObject.GetComponent<SlotCheck>().isEnd && isTrue)
                {
                    Grid[0].slotObject.GetComponent<SlotCheck>().isTrue = true;
                    WinPanel.SetActive(true);
                }
            }
        }
        
        if (Grid[1].slotObject == null)
        {
            
        }
        
        else if (Grid[1].slotObject.GetComponent<SlotCheck>() != null)
        {
            if (Grid[1].slotObject.GetComponent<SlotCheck>().isRight && isLeft)
            {
                if (Grid[1].slotObject.GetComponent<SlotCheck>().isTrue) 
                    isTrue = true;
                
                if (Grid[1].slotObject.GetComponent<SlotCheck>().isEnd && isTrue)
                {
                    Grid[1].slotObject.GetComponent<SlotCheck>().isTrue = true;
                    WinPanel.SetActive(true);
                }
            }
        }
        
        if (Grid[2].slotObject == null)
        {
            
        }
        
        else if (Grid[2].slotObject.GetComponent<SlotCheck>() != null)
        {
            if (Grid[2].slotObject.GetComponent<SlotCheck>().isLeft && isRight)
            {
                if (Grid[2].slotObject.GetComponent<SlotCheck>().isTrue) 
                    isTrue = true;
                
                if (Grid[2].slotObject.GetComponent<SlotCheck>().isEnd && isTrue)
                {
                    Grid[2].slotObject.GetComponent<SlotCheck>().isTrue = true;
                    WinPanel.SetActive(true);
                }
            }
        }
        
        if (Grid[3].slotObject == null)
        {
            
        }
        
        else if (Grid[3].slotObject.GetComponent<SlotCheck>() != null)
        {
            if (Grid[3].slotObject.GetComponent<SlotCheck>().isTop && isBottom)
            {
                if (Grid[3].slotObject.GetComponent<SlotCheck>().isTrue) 
                    isTrue = true;
                
                if (Grid[3].slotObject.GetComponent<SlotCheck>().isEnd && isTrue)
                {
                    Grid[3].slotObject.GetComponent<SlotCheck>().isTrue = true;
                    WinPanel.SetActive(true);
                }
            }
        }
    }
}