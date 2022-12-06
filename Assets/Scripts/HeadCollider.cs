using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadCollider : MonoBehaviour
{
    [SerializeField] float restartDelay;
    [SerializeField] ParticleSystem blood;
    [SerializeField] AudioClip crashSound;
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !player.isGameOver)
        {
            Debug.Log("You Crashed! Game Restarting...");
            blood.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            player.isGameOver = true;
            
            //rb.velocity = Vector3.zero;                           // Head touched ground
            //rb.simulated = false;
            Invoke("RestartGame", restartDelay);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
