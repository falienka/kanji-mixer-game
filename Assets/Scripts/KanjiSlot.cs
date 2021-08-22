using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KanjiSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image image;
    [SerializeField] KanjiInformation kanjiInformation;
    public GiveKanjiPopUp giveKanjiBox;
    public bool isSelected;
    public bool isHeld;
    public Color selectedColor = Color.magenta;

    private Inventory _inventory;
    [SerializeField] private KanjiItem _item;
    [SerializeField] public KanjiItem Item
    {
        get
        {
            return _item;
        }
        set
        {
            _item = value;

            if (_item == null)
            {
                image.color = Color.clear;
                image.enabled = false;
            }
            else
            {
                image.color = Color.white;
                image.sprite = _item.kanjiIcon;
                image.SetNativeSize();
                image.enabled = true;
            }
        }
    }

    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    public void SelectKanji()
    {
        if (HasItem())
        {
            if (!isSelected)
            {
                if (_inventory.numberSelected < 2)
                {
                    isSelected = true;
                    transform.parent.GetComponent<Image>().color = selectedColor;
                    _inventory.numberSelected++;
                }
            }
            else
            {
                isSelected = false;
                transform.parent.GetComponent<Image>().color = Color.white;
                _inventory.numberSelected--;
            }
        }
    }

    public void UnselectKanji()
    {
        if (isSelected)
        {
            isSelected = false;
            transform.parent.GetComponent<Image>().color = Color.white;
            _inventory.numberSelected--;
        }
    }

    public void DisableKanji()
    {
        transform.parent.GetComponent<Image>().color = Color.gray;
        UnselectKanji();
        isHeld = false;
        giveKanjiBox.gameObject.SetActive(false);
        GetComponent<Button>().interactable = false;
        transform.parent.GetComponent<Button>().interactable = false;
    }

    public bool HasItem()
    {
        return _item != null;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (HasItem())
        {
            kanjiInformation.ShowInformation(Item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        kanjiInformation.HideInformation();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GetComponent<Button>().interactable)
        {
            if (!isHeld && eventData.button == PointerEventData.InputButton.Left)
            {
                SelectKanji();
            }
            else if (HasItem() && !isSelected && eventData.button == PointerEventData.InputButton.Right)
            {
                if (!GameManager.Inst.heldItem)
                {
                    EquipKanji();
                }
                else if(isHeld)
                {
                    UnequipKanji();
                }
            }
        }
    }

    private void EquipKanji()
    {
        _inventory.UnselectAll();
        isHeld = true;
        GameManager.Inst.heldItem = _item;
        giveKanjiBox.GiveKanjiPopUpText(_item);
        
    }

    private void UnequipKanji()
    {
        isHeld = false;
        GameManager.Inst.heldItem = null;
        giveKanjiBox.gameObject.SetActive(false);
    }
}
