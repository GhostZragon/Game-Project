using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{

    public List<TabButton> tabButtons;
    public List<GameObject> objectsToSwap;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selecetedTab;

    private void Start()
    {
        
    }
    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTab();
        if (selecetedTab == null || button != selecetedTab)
        {
            button.background.sprite = tabHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTab();
    }

    public void OnTabSeleceted(TabButton button)
    {
        selecetedTab = button;
        ResetTab();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for(int i = 0;i < objectsToSwap.Count;i++)
        {
            if(i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTab()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selecetedTab != null && button == selecetedTab)
            {
                continue;
            }
            button.background.sprite = tabIdle;
        }
    }
}
