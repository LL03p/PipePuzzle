using System.Collections.Generic;
using UnityEngine;

public class ScriptGameplay : MonoBehaviour
{
    public GameObject Level;
    public GameObject Inventory;

    public List<GameObject> Slot;

    private float DropDistance = 40;

    private Vector2 objectInitPost;

    public ConnectionPoint point1, point2;

    public enum ConnectionPoint
    {
        Top,
        Left,
        Right,
        Bottom
    }

    void Start()
    {
        objectInitPost = Inventory.transform.position;
    }

    public void DragObject()
    {
        transform.position = Input.mousePosition;
        transform.SetParent(Level.transform);
    }

    public void DropObject()
    {
        bool isDrop = false;

        foreach (GameObject slot in Slot)
        {
            float slotDistance = Vector3.Distance(transform.position, slot.transform.position);

            if (slotDistance < DropDistance)
            {
                if (slot.transform.childCount == 0)
                {
                    transform.position = slot.transform.position;
                    transform.SetParent(slot.transform);
                    isDrop = true;
                    
                    SlotCheck slotCheck = slot.GetComponent<SlotCheck>();
                    
                    slotCheck.isTop = false;
                    slotCheck.isLeft = false;
                    slotCheck.isRight = false;
                    slotCheck.isBottom = false;

                    if (point1 == ConnectionPoint.Top)
                        slotCheck.isTop = true;
                    else if (point1 == ConnectionPoint.Left)
                        slotCheck.isLeft = true;
                    else if (point1 == ConnectionPoint.Right)
                        slotCheck.isRight = true;
                    else if (point1 == ConnectionPoint.Bottom)
                        slotCheck.isBottom = true;

                    if (point2 == ConnectionPoint.Top)
                        slotCheck.isTop = true;
                    else if (point2 == ConnectionPoint.Left)
                        slotCheck.isLeft = true;
                    else if (point2 == ConnectionPoint.Right)
                        slotCheck.isRight = true;
                    else if (point2 == ConnectionPoint.Bottom)
                        slotCheck.isBottom = true;
                    
                    slotCheck.CheckSlot();
                    
                    SlotCheck[] allSlotChecks = FindObjectsOfType<SlotCheck>();

                    foreach (SlotCheck s in allSlotChecks)
                    {
                        s.CheckEnd();
                    }
                }

                else
                {
                    transform.position = objectInitPost;
                    transform.SetParent(Inventory.transform);
                }
                
                break;
            }
        }

        if (!isDrop)
        {
            transform.position = objectInitPost;
            transform.SetParent(Inventory.transform);
        }
    }
}