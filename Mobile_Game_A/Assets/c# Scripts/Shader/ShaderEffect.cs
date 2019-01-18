using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderEffect : MonoBehaviour {

    public Material mat;        // The shader material

    void OnRenderImage(RenderTexture source, RenderTexture destination)  // Render image on camera
    {
        Graphics.Blit(source, destination, mat);        // Negative the screen with shader
    }
}
