using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitBtn : MonoBehaviour
{
    private Button _btn;
    [SerializeField]
    private GameObject _menu;
    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(Close);
    }

    void Close()
    {
        _menu.SetActive(true);
    }
}
