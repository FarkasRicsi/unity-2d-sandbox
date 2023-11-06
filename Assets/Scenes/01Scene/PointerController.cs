using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{   
    private void OnMouseUp()
    {
        logHello();
    }

    public void logHello()
    {
        Debug.Log("Hello: "+this.gameObject.name);
    }
}
