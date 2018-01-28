using UnityEngine;

public class RoofHandler : MonoBehaviour
{
    public EnvironmentManager envManager;
    public SpriteRenderer roof;
    public float fadeSpeed = 1f;
	
	void Update()
    {
        float targetOpacity = envManager.outside ? 1f : 0f;
        Color c = roof.material.color;
        c.a += (targetOpacity - c.a) * Time.deltaTime * fadeSpeed;
        roof.material.color = c;
    }
}
