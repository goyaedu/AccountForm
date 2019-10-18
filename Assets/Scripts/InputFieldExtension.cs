using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

static public class InputFieldExtension
{
    public static void Incorrect(this GYInputField inputField)
    {
        inputField.image.color = Color.red;
        inputField.isCorrect = false;
    }
}
