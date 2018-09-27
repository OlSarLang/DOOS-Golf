﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    // Cached references
    public ParticleSystem particles;
    public Ball theBall;

    public static int shotNumber = 0;

    private void Start()
    {
        particles = FindObjectOfType<ParticleSystem>();
        theBall = FindObjectOfType<Ball>();
    }

    public void AddShot()
    {
        shotNumber++;
    }

    // Goal trigger, but if the ball is moving too fast, it won't trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (theBall.rb.velocity.magnitude < 3.5f)
        {
            StartCoroutine(Goal());
        }
    }

    IEnumerator Goal()
    {
        Debug.Log("Goal! Shots: " + shotNumber);
        theBall.DestroyBall();
        particles.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
