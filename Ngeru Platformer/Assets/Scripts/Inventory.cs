using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private RectTransform inventoryRect;
    private float inventoryWidth, inventoryHeight;

    public int slots;
    public int rows;
    public float slotPaddingLeft, slotPaddingTop;
    public float slotSize;
    public GameObject slotPrefab;
    public int emptySlot;

    private List<GameObject> allSlots;


	// Use this for initialization
	void Start () {
        CreateLayout();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 10 slots
    // 3 rows
    // 20 slotsize
    // 2 slotpadding
    //
    //


    private void CreateLayout()
    {
        allSlots = new List<GameObject>();

        inventoryWidth = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;

        inventoryHeight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;

        inventoryRect = GetComponent<RectTransform>();

        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHeight);

        int columns = slots / rows;

        for (int y = 0; y < rows; y++) {
            for(int x = 0; x < columns; x++)
                { 
                    GameObject newSlot = (GameObject)Instantiate(slotPrefab);
                    RectTransform slotRect = newSlot.GetComponent<RectTransform>();
                    newSlot.name = "Slot";
                    newSlot.transform.SetParent(this.transform.parent);
                    slotRect.localPosition = inventoryRect.localPosition + new Vector3(slotPaddingLeft * (x + 1) + (slotSize * x), -slotPaddingTop * (y+1) - (slotSize *y));
                    slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                    slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);
                    allSlots.Add(newSlot);
                 }
        }
    }

    public bool AddItem(Item item) {
        if (item.maxSize == 1)
        {
            PlaceEmpty(item);
            return true;
        }
        return false;
    }

    private bool PlaceEmpty(Item item)
    {
        if (emptySlot > 0) {
            foreach (GameObject slot in allSlots) {
                Slot tmp = slot.GetComponent<Slot>();
                if (tmp.IsEmpty)
                {
                    tmp.AddItem(item);
                    emptySlot--;
                    return true;
                }
            }
        }

        return false;
    }

}
