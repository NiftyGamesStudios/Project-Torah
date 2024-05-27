using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowAndHidePassword : MonoBehaviour
{
    public TMP_InputField password_Field;
    public Image image;
    public Sprite[] eyes;
    bool isHiden = true;
    public void ShowOrHidePass()
    {
        isHiden = !isHiden;
        if (isHiden)
        {
            password_Field.contentType = TMP_InputField.ContentType.Password;
            image.sprite = eyes[0];
        }
        else
        {
            password_Field.contentType = TMP_InputField.ContentType.Standard;
            image.sprite = eyes[1];
        }
            password_Field.ForceLabelUpdate();
    }
}
