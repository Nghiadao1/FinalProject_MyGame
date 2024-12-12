using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCheat : GenericSingleton<CreateCheat>
{
    // Start is called before the first frame update
    [SerializeField] PopupLoader popupLoader;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            popupLoader.ShowPopup();
        }
    }
}
