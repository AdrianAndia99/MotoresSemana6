using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    private float speed = 5f;
    private Vector2 moveInput;
    public AudioSource collisionSound1;
    public AudioSource collisionSound2;
    public AudioSource footstepSound;
    public AudioSettings audioSettings;

    private float footstepInterval = 0.5f;
    private float footstepTimer;

    private void Update()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        transform.Translate(moveDirection * speed * Time.deltaTime);

        if (IsMoving())
        {
            if (Time.time >= footstepTimer)
            {
                footstepSound.Play();
                footstepTimer = Time.time + footstepInterval;
            }
        }
        else
        {
            footstepSound.Stop();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag ==("cubo"))
        {
            if (collisionSound1 != null)
            {
                collisionSound1.volume = audioSettings.sfxVolume;
                collisionSound1.Play();
                Debug.Log("sonando");
            }
        }
        else if(collision.gameObject.tag == ("cubo2"))
        {
            if(collisionSound2 != null)
            {
                collisionSound2.volume = audioSettings.sfxVolume;
                collisionSound2.Play();
                Debug.Log("sonando");
            }
        }

        if(collision.gameObject.tag == "cambio")
        {
            SceneManager.LoadScene("Parte2");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == ("cubo"))
        {
            if (collisionSound1 != null)
            {
                collisionSound1.Stop();
            }
        }
        else if (collision.gameObject.tag == ("cubo2"))
        {
            if (collisionSound2 != null)
            {
                collisionSound2.Stop();
            }
        }
    }
    private bool IsMoving()
    {
        return moveInput.magnitude > 0;
    }
}