﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnCollide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            foreach(SpriteRenderer renderer in this.gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                StartCoroutine(FadeTo(renderer));
            }
            
        }
    }

    // Define an enumerator to perform our fading.
    // Pass it the material to fade, the opacity to fade to (0 = transparent, 1 = opaque),
    // and the number of seconds to fade over.
    //  https://gamedev.stackexchange.com/questions/142791/how-can-i-fade-a-game-object-in-and-out-over-a-specified-duration
    IEnumerator FadeTo(SpriteRenderer renderer)
    {

        // Cache the current color of the material, and its initiql opacity.
        Color color = renderer.color;
        float startOpacity = color.a;
        float targetOpacity = 0.0f;
        float duration = 2.5f;

        // Track how many seconds we've been fading.
        float t = 0;

        while (t < duration)
        {
            // Step the fade forward one frame.
            t += Time.deltaTime;
            // Turn the time into an interpolation factor between 0 and 1.
            float blend = Mathf.Clamp01(t / duration);

            // Blend to the corresponding opacity between start & target.
            color.a = Mathf.Lerp(startOpacity, targetOpacity, blend);

            // Apply the resulting color to the material.
            renderer.color = color;

            // Wait one frame, and repeat.
            yield return null;
        }
    }
}
