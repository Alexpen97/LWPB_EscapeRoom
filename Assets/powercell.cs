using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powercell : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Renderer touchCurrentRenderer; // The Renderer that belongs to the object that the pointer is currently touching
    private Color touchOriginalColor;
    public Color touchHighlightColor;

    // Has to be "Stay" instead of "Enter", if you have overlapping objects
    private void OnTriggerStay(Collider other)
    {
        // If the pointer is not touching an object.
        // This if statement prevents the pointer from affecting multiple objects simultaneaously
        if (touchCurrentRenderer == null)
        {
            // Get Renderer component
            touchCurrentRenderer = other.GetComponent<Renderer>();
            // If the touched object has a Renderer Component
            if (touchCurrentRenderer != null)
            {
                // Save the Original Color
                touchOriginalColor = touchCurrentRenderer.material.color;
                // Highlight Object
                touchCurrentRenderer.material.color = touchHighlightColor;
            } // change texture 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (touchCurrentRenderer != null)
        {
            // Restore the Original Color
            touchCurrentRenderer.material.color = touchOriginalColor;
            touchCurrentRenderer = null;
        }
    }
}

