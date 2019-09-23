using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public int points;
    public int hitsToBreak;
    //public MeshRenderer hitSprite;

    public void BreakBrick()
    {
        hitsToBreak--;
        Renderer rend = GetComponent<MeshRenderer>();
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);

    }
}
