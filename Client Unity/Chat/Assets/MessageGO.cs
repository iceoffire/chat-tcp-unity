using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageGO : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI message;
    public TextMeshProUGUI date;
    
    public void SetMessageInfo(string message, bool mine=false)
    {
        int lenght = message.Length;
        this.message.text = message;
        this.date.text = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}";
        
        if (mine)
            this.image.rectTransform.sizeDelta = new Vector2(Math.Min(764,this.message.GetPreferredValues().x+10), 0);
        else
            this.image.rectTransform.sizeDelta = new Vector2(Math.Min(764,this.message.GetPreferredValues().x+60), 0);
        
        this.message.ForceMeshUpdate();
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(764, this.message.GetPreferredValues().y+10);
        this.message.ForceMeshUpdate();
    }
}
