using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GYInputField : InputField
{
    Color baseColor;
    public bool isCorrect;

    protected override void Awake()
    {
        isCorrect = true;
        baseColor = image.color;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (!isCorrect)
        {
            text = "";
            image.color = baseColor;
        }
    }
}
