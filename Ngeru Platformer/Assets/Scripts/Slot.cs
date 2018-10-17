
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler {
    private Stack<Item> items;

    public Text stackText;
    public Sprite slotEmpty;
    public Sprite slotHighlight;

    public PlayerHealth ItemTurn;
    public Inventory GetInventory;

    public Stack<Item> Items
    {
        get { return items; }

        set { items = value; }
    }





    public Item CurrentItem
    {
        get
        {
            return items.Peek();
        }
    }

    public bool IsAvailable
    {
        get
        {
            return CurrentItem.maxSize > items.Count;
        }
    }

    public bool IsEmpty
    {
        get { return items.Count == 0; }
    }

    void Awake()
    {
        items = new Stack<Item>();
        ItemTurn = GameObject.FindObjectOfType(typeof(PlayerHealth)) as PlayerHealth;
        GetInventory = GameObject.FindObjectOfType(typeof(Inventory)) as Inventory;
    }


    // Use this for initialization
    void Start () {

       

        RectTransform slotRect = GetComponent<RectTransform>();
        RectTransform txtRect = stackText.GetComponent<RectTransform>();

        int txtScaleFactor = (int)(slotRect.sizeDelta.x * 0.60);
        stackText.resizeTextMaxSize = txtScaleFactor;
        stackText.resizeTextMaxSize = txtScaleFactor;

        txtRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotRect.sizeDelta.y);
        txtRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotRect.sizeDelta.x);
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    public void AddItem(Item item) {
        items.Push(item);

        if (items.Count > 1) {
            stackText.text = items.Count.ToString();

        }

        ChangeSprite(item.spriteNeutral, item.spriteHighlighted);

    }



    //Optional functionality, use it or don't but it exists here because I wanted to learn how to drag stacks anyway.
    public void AddItems(Stack<Item> items)
    {
        this.items = new Stack<Item>(items);

        stackText.text = items.Count > 1 ? items.Count.ToString() : string.Empty;

        ChangeSprite(CurrentItem.spriteNeutral, CurrentItem.spriteHighlighted);
    }


    private void ChangeSprite(Sprite neutral, Sprite highlight)
    {
        GetComponent<Image>().sprite = neutral;
        SpriteState st = new SpriteState();

        st.highlightedSprite = highlight;
        st.pressedSprite = neutral;

        GetComponent<Button>().spriteState = st;

    }

    private void UseItem()
    {
        if (!IsEmpty)
        {

            items.Pop().Use();
            

            stackText.text = items.Count > 1 ? items.Count.ToString() : string.Empty;
            //this checks stackText, finds the number of items then routes the count to empty if quantity below 1.

            if (IsEmpty)
            {
                ChangeSprite(slotEmpty, slotHighlight);
                Inventory.EmptySlots++;
            }
        }

    }

   


    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right && Inventory.CanvasGroup.alpha > 0)
        {

                UseItem();
            ItemTurn.SkipTurn();
            GetInventory.TurnbaseLoad();


            
        }
    }

    public void ClearSlot()
    {
        items.Clear();
        ChangeSprite(slotEmpty, slotHighlight);
        stackText.text = string.Empty;
    }
}