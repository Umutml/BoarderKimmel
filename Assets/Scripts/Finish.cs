using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    [SerializeField] ParticleSystem finish;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("WINNER!");
            audioSource.Play();
            finish.Play();
            Invoke("RestartGame", 2);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
