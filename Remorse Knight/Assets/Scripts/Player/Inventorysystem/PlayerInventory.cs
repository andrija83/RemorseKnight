using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInventory : MonoBehaviour
{
    public WeaponAttack[] weapons;
    public List<GameObject> pickedItems = new List<GameObject>();
    public GameObject ui_Window;
    public Image[] itemsImages;
    public GameObject ui_DescriptionWindow;
    public Image descriptionImage;
    public Text descriptionTitle;


    public bool isInventoryOpen = false;
    private static PlayerInventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }
    private void Update()
    {
        if(InputPLayer.GetInstance().GetInventoryPressed())
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        ui_Window.SetActive(isInventoryOpen);
    }



    public void PickUpItem(GameObject item)
    {
        //pickedItemss.Add(item);
        pickedItems.Add(item);
        UpdateUI();
    }
    void UpdateUI()
    {
        HideAll();
        for (int i = 0; i < pickedItems.Count; i++)
        {
            itemsImages[i].sprite =  pickedItems[i].GetComponent<SpriteRenderer>().sprite;
            itemsImages[i].gameObject.SetActive(true);
        }
    }
    void HideAll()
    {
        foreach (var item in itemsImages)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void ShowDescrition(int id)
    {
        descriptionImage.sprite = itemsImages[id].sprite;
        descriptionTitle.text = pickedItems[id].name;
        descriptionImage.gameObject.SetActive(true);
        descriptionTitle.gameObject.SetActive(true);

    }
    public void HideDescription()
    {
        descriptionImage.gameObject.SetActive(false);
        descriptionTitle.gameObject.SetActive(false);
    }
    public static PlayerInventory GetInstance() => instance;
}
