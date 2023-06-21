using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScrolling : MonoBehaviour
{
    public float scrollSpeed;
    private Renderer meshRenderer;
    private Vector2 savedOffset;

    private void Start()
    {
        meshRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        // Hướng từ trái qua phải
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1f);
        Vector2 offset = new Vector2(x, 0f);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
