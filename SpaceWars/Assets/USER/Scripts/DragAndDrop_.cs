using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop_ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
