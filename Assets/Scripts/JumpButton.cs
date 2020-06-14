using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (PlayerJump.instance !=null)
        {
            PlayerJump.instance.GivePower(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (PlayerJump.instance !=null)
        {
            PlayerJump.instance.GivePower(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
