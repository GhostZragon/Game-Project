using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerExitHandler,IPointerEnterHandler
{
    public TabGroup tabGroup;

    public Image background;

   
    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSeleceted(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    private void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);

    }
}
