using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargsPress : MonoBehaviour {
    public bool Charged = true;
    public int charges_capacity = 10;
    SpriteRenderer m_SpriteRenderer;
    public Color m_NewColor;
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
        

    public void Charg()
    {
        Charged = false;
        m_SpriteRenderer.color = Color.gray;
    }
}
