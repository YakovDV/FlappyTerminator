using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

    public override void Open()
    {
        WindowGroup.alpha = 1.0f;
        WindowGroup.blocksRaycasts = true;
        ActionButton.interactable = true;
    }

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        WindowGroup.blocksRaycasts = false;
        ActionButton.interactable = false;
    }

    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}
