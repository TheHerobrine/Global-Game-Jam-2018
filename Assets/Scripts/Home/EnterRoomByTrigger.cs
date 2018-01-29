using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnterRoomByTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered) return;
        triggered = true;
        StartCoroutine("FadeFogOfWar");
        this.enabled = false;
    }

    IEnumerator FadeFogOfWar()
    {
        Renderer r = this.GetComponent<Renderer>();
        Color c = r.material.color;
        for (float f = 1f; f >= 0; f -= 1.0f*Time.deltaTime)
        {
            c.a = f;
            r.material.color = c;
            yield return null;
        }
        this.gameObject.SetActive(false);
    }
}
