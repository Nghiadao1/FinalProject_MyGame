using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCheat : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PopupLoader popupLoader;

    // Update is called once per frame
    void Update()
    {
        //if ckick "c" key 5 times open popup popupLoader
        if (Input.GetKeyDown(KeyCode.C))
        {
            popupLoader.ShowPopup();
        }
    }
}
