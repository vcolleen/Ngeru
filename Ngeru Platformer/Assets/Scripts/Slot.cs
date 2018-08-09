using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {
    private Stack<Item> items;

    public Text stackText;

    public Sprite slotEmpty;
    public Sprite slotHighlight;

    public bool IsEmpty
    {
        get { return items.Count == 0; }
    }

	// Use this for initialization
	void Start () {
        items = new Stack<Item>();

        RectTransform slotRect = GetComponent<RectTransform>();
        RectTransform txtRect = GetComponent<RectTransform>();

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

    private void ChangeSprite(Sprite neutral, Sprite highlight)
    {
        GetComponent<Image>().sprite = neutral;
        SpriteState st = new SpriteState();

        st.highlightedSprite = highlight;
        st.pressedSprite = neutral;

        GetComponent<Button>().spriteState = st;

    }
}
