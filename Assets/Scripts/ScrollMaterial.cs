using UnityEngine;

public class ScrollMaterial : MonoBehaviour
{
    public float scrollSpeed;

    private Renderer _renderer;
    private static readonly int MainTex = Shader.PropertyToID("_MainTex");

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        var offset = Time.time * scrollSpeed;
        _renderer.material.SetTextureOffset(MainTex, new Vector2(0, offset));
    }
}