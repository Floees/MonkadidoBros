using UnityEngine;

/// Drop on an empty GameObject, assign your camera (or leave empty for Main Camera),
/// then fill the Layers list back-to-front. Layers are created at runtime as children.
public class ParallaxBackground : MonoBehaviour
{
    [System.Serializable]
    public class Layer
    {
        public string name;
        public Sprite sprite;
        [Tooltip("Fraction of camera movement the layer moves on screen. 0 = glued to camera (sky), 1 = moves with the world.")]
        [Range(0f, 1f)] public float scrollSpeed = 0.5f;
        [Tooltip("Extra drift in world units per second (clouds, mist).")]
        public float autoScroll = 0f;
        [Tooltip("Repeat endlessly sideways. Turn off for the sky.")]
        public bool tileHorizontally = true;

        [HideInInspector] public Transform t;
        [HideInInspector] public float width;
    }

    public Camera cam;
    public Layer[] layers;
    public string sortingLayerName = "Default";
    public int baseSortingOrder = -100;

    Vector3 lastCamPos;

    void Start()
    {
        if (!cam) cam = Camera.main;
        lastCamPos = cam.transform.position;

        for (int i = 0; i < layers.Length; i++)
        {
            var L = layers[i];
            if (!L.sprite) continue;

            var go = new GameObject(string.IsNullOrEmpty(L.name) ? L.sprite.name : L.name);
            go.transform.SetParent(transform, false);
            go.transform.position = new Vector3(lastCamPos.x, lastCamPos.y, 0f);

            var sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = L.sprite;
            sr.sortingLayerName = sortingLayerName;
            sr.sortingOrder = baseSortingOrder + i;

            L.width = L.sprite.bounds.size.x;
            if (L.tileHorizontally)
            {
                // Needs Mesh Type = Full Rect on the sprite import settings.
                sr.drawMode = SpriteDrawMode.Tiled;
                sr.size = new Vector2(L.width * 3f, L.sprite.bounds.size.y);
            }
            L.t = go.transform;
        }
    }

    void LateUpdate()
    {
        Vector3 camPos = cam.transform.position;
        float dx = camPos.x - lastCamPos.x;
        lastCamPos = camPos;

        foreach (var L in layers)
        {
            if (L.t == null) continue;

            Vector3 p = L.t.position;
            p.x += dx * (1f - L.scrollSpeed) + L.autoScroll * Time.deltaTime;
            p.y = camPos.y; // layers stay vertically centred on the camera

            if (L.tileHorizontally)
            {
                float dist = camPos.x - p.x;
                if (Mathf.Abs(dist) >= L.width)
                    p.x += Mathf.Sign(dist) * L.width * Mathf.Floor(Mathf.Abs(dist) / L.width);
            }
            L.t.position = p;
        }
    }
}
