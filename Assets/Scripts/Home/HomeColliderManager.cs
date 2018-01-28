using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HomeColliderManager : MonoBehaviour
{
    public EnvironmentManager envManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        envManager.outside = false;
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        envManager.outside = true;
    }
}
