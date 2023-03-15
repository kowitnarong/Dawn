using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class rescalemat : MonoBehaviour
{
    public float scaleFactor = 1.0f;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(transform.localScale.x / scaleFactor, transform.localScale.z / scaleFactor);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged && Application.isEditor && !Application.isPlaying)
        {
            GetComponent<Renderer>().material.mainTextureScale = new Vector2(transform.localScale.x / scaleFactor, transform.localScale.z / scaleFactor);
            transform.hasChanged = false;
        }
    }
}
