using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitBtn : MonoBehaviour
{
    private Button _btn;
    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(Close);
    }

    void Close()
    {
        FindObjectOfType<Main>().exitGame();
    }
}
