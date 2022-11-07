using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestKeyboard : MonoBehaviour
{
    private TouchScreenKeyboard overlayKeyboard;
    [SerializeField] TMP_InputField input;

    private void Start()
    {
        overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        gameObject.AddComponent<OVRRaycaster>();
    }

    private void Update()
    {
        if (overlayKeyboard != null)
            input.text = overlayKeyboard.text;         
    }
}
