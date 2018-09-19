using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour {

    private static Inventory instance;

    public static Inventory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Inventory>();
            }
            return Inventory.instance;
        }
    }

    public Canvas canvas;
    public EventSystem eventSystem;

    private static CanvasGroup canvasGroup;

    public static CanvasGroup CanvasGroup {
        get
        {
            return Inventory.canvasGroup;
        }
    }


    private bool fadingIn;

    private bool fadingOut;


    public float fadeTime;

    private RectTransform inventoryRect;
    private float inventoryWidth, inventoryHeight;

    public int slots;
    public int rows;
    public float slotPaddingLeft, slotPaddingTop;
    public float slotSize;

    public GameObject slotPrefab;
    public GameObject iconPrefab;

    private Slot from, to;

    private List<GameObject> allSlots;

    private static int emptySlot = 30;

    private static GameObject clicked;
    private static GameObject hoverObject;

    public bool NotInCombat;


    public GameObject mana;
    /// This is used when loading a saved inventory. Add more to this as you gain more types of consumables.
    public GameObject health;


    public static int EmptySlots
    {
        get { return emptySlot; }
        set { emptySlot = value; }
    }



    // Use this for initialization
    void Start() {
        CreateLayout();

        canvasGroup = transform.parent.GetComponent<CanvasGroup>();

    }

    // Update is called once per frame
    void Update() {

        if (hoverObject != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out position);
            // position.Set(position.x + hoverYOffset, position.y - hoverYOffset);
            hoverObject.transform.position = canvas.transform.TransformPoint(position);
        }

        if (Input.GetKeyDown(KeyCode.B) && NotInCombat == true)
        {
            if(canvasGroup.alpha > 0)
            {
                StartCoroutine("FadeOut");
                SaveInventory();
            }

            else
            {
                StartCoroutine("FadeIn");
                LoadInventory();
            }
        }



    }

    public void TurnbaseLoad()
    {


           if(canvasGroup.alpha > 0)
            {
                StartCoroutine("FadeOut");
            SaveInventory();
            }

            else
            {
                StartCoroutine("FadeIn");
          LoadInventory();
        }
    }


    public void SaveInventory() //Call this function on various triggers, such as battle start and resuming exploraiton mode. There is no need for 5+ inventory saves, as information carries through open /close.
    {
        string content = string.Empty;
        for(int i = 0; i < allSlots.Count; i++)
        {
            Slot tmp = allSlots[i].GetComponent<Slot>();

            if (!tmp.IsEmpty)
            {
                content += i + "-" + tmp.CurrentItem.type.ToString() + "-" + tmp.Items.Count.ToString() + ";";
                //This string transforms slot data into a format that tallies slot number, gets the item in said slot, then grabs the stack number.
                //It looks like this "0-HEALTH-2" if in the first slot, there was a health potion with two in the stack.


            }
        }

        PlayerPrefs.SetString("content", content); // deals with the for int cuckery.

        PlayerPrefs.SetInt("slots", slots); //set num of slots in save data.

        PlayerPrefs.SetInt("rows", rows); //set num of rows in save data.

        //This stuff saves graphical data.
        PlayerPrefs.SetFloat("slotPaddingLeft", slotPaddingLeft);
        PlayerPrefs.SetFloat("slotPaddingTop", slotPaddingTop);
        PlayerPrefs.SetFloat("slotSize", slotSize);
      //  PlayerPrefs.SetFloat("xPos", inventoryRect.position.x);
      //  PlayerPrefs.SetFloat("yPos", inventoryRect.position.y);


        PlayerPrefs.Save();
    }

    public void LoadInventory()
    {
        string content = PlayerPrefs.GetString("content");
        slots = PlayerPrefs.GetInt("slots", slots);
        rows = PlayerPrefs.GetInt("rows", rows);
        slotPaddingLeft = PlayerPrefs.GetFloat("slotPaddingLeft", slotPaddingLeft);
         slotPaddingTop = PlayerPrefs.GetFloat("slotPaddingTop", slotPaddingTop);
        slotSize =  PlayerPrefs.GetFloat("slotSize", slotSize);

        //inventoryRect.position = new Vector3(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"), inventoryRect.position.z);

        CreateLayout();


        // splitter magic starts here.

        string[] splitContent = content.Split(';');

        for (int x = 0; x < splitContent.Length-1; x++)
        {
            string[] splitValues = splitContent[x].Split('-');

            int index = System.Int32.Parse(splitValues[0]); //Reads the slot value.





            ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), splitValues[1]); //Reads the item type information.

            int amount = System.Int32.Parse(splitValues[2]); //reads stack info.

            for(int i = 0; i < amount; i++)
            {
                switch (type)   //Item Type Library declared, any items added, must go here. Must first declare them as public game objects to be hooked into the script.
                {
                    case ItemType.MANA:
                        allSlots[index].GetComponent<Slot>().AddItem(mana.GetComponent<Item>());
                        break;

                    case ItemType.HEALTH:
                        allSlots[index].GetComponent<Slot>().AddItem(health.GetComponent<Item>());
                        break;
                }
            }

        }

    }

    // 10 slots
    // 3 rows
    // 20 slotsize
    // 2 slotpadding
    //
    //


    private void CreateLayout()
    {
        if(allSlots != null)
        {
            foreach(GameObject go in allSlots)
            {
                Destroy(go);
            }

        }


        allSlots = new List<GameObject>();

        inventoryWidth = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;

        inventoryHeight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;

        inventoryRect = GetComponent<RectTransform>();

        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHeight);

        int columns = slots / rows;

        for (int y = 0; y < rows; y++) {
            for (int x = 0; x < columns; x++)
            {
                GameObject newSlot = (GameObject)Instantiate(slotPrefab);
                RectTransform slotRect = newSlot.GetComponent<RectTransform>();
                newSlot.name = "Slot";
                newSlot.transform.SetParent(this.transform.parent);
                slotRect.localPosition = inventoryRect.localPosition + new Vector3(slotPaddingLeft * (x + 1) + (slotSize * x), -slotPaddingTop * (y + 1) - (slotSize * y));
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize * canvas.scaleFactor);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize * canvas.scaleFactor);
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

        else
        {
            foreach (GameObject slot in allSlots)
            {
                Slot tmp = slot.GetComponent<Slot>();

                if (!tmp.IsEmpty)
                {
                    if (tmp.CurrentItem.type == item.type && tmp.IsAvailable) //checks if the item is of the same type, and if it is at max stacks
                    {
                        tmp.AddItem(item);
                        return true;

                    }
                }
            }
            if (emptySlot > 0)
            {
                PlaceEmpty(item);
            }

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

    //Here is the drag and drop function. Will be disabled at another time.
    public void MoveItem(GameObject clicked)
    {

        if (from == null && CanvasGroup.alpha == 1) // this means you cannot move empty space.
        {
            if (!clicked.GetComponent<Slot>().IsEmpty)
            {
                from = clicked.GetComponent<Slot>();
                from.GetComponent<Image>().color = Color.gray;

                hoverObject = (GameObject)Instantiate(iconPrefab);
                hoverObject.GetComponent<Image>().sprite = clicked.GetComponent<Image>().sprite;
                hoverObject.name = "Hover";

                RectTransform hoverTransform = hoverObject.GetComponent<RectTransform>();
                RectTransform clickedTransform = clicked.GetComponent<RectTransform>();

                hoverTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, clickedTransform.sizeDelta.x);
                hoverTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, clickedTransform.sizeDelta.y);

                hoverObject.transform.SetParent(GameObject.Find("Canvas").transform, true);

                hoverObject.transform.localScale = from.gameObject.transform.localScale;

            }
        }
        else if (to == null)
        {
            to = clicked.GetComponent<Slot>();
        }
        if (to != null && from != null) //if something is here, replace it.
        {
            Stack<Item> tmpTo = new Stack<Item>(to.Items);
            to.AddItems(from.Items);

            if (tmpTo.Count == 0)
            {
                from.ClearSlot();
            }
            else
            {
                from.AddItems(tmpTo);
            }
            from.GetComponent<Image>().color = Color.white;
            to = null;
            from = null;
            hoverObject = null;
        }
    }

    private IEnumerator FadeOut()
    {
        if (!fadingOut)
        {
            fadingOut = true;
            fadingIn = false;
            StopCoroutine("FadeIn");

            float startAlpha = canvasGroup.alpha;

            float rate = 1.0f;

            float progress = 0.0f;

            while (progress < 1.0)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, progress);

                progress += rate * Time.deltaTime;

                yield return null;
            }
            canvasGroup.alpha = 0;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            fadingOut = false;
        }
    }

    private IEnumerator FadeIn()
    {
        if (!fadingIn)
        {
            fadingOut = false;
            fadingIn = true;
            StopCoroutine("FadeOut");

            float startAlpha = canvasGroup.alpha;

            float rate = 1.0f;

            float progress = 0.0f;

            while (progress < 1.0)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, 1, progress);

                progress += rate * Time.deltaTime;

                yield return null;
            }
            canvasGroup.alpha = 1;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            fadingIn = false;
        }
    }

}
