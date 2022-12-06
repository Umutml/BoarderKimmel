using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    SurfaceEffector2D surfaceEffector;
    Rigidbody2D rb;
    float axisH;
    
    [SerializeField] float torqSpeed; // Check inspector
    [SerializeField] float BoostSpeed = 25;
    [SerializeField] float defaultSpeed = 15;
    private float fuel = 10;
    [SerializeField] Slider fuelSlider;
    public bool isGameOver;

    void Start()
    {
        fuelSlider.value = fuel;
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }
    void Update()
    {
        if (!isGameOver)
        {
            Movement();
            Boost();
        }
    }
    void Boost()
    {
        if (Input.GetButton("Jump") && fuel >= 0)
        {
            surfaceEffector.speed = BoostSpeed;
            Debug.Log(fuel);
            fuel -= 1 * Time.deltaTime;
            fuelSlider.value = fuel;
        }
        else                                        // Space button speed boost
        {
            surfaceEffector.speed = defaultSpeed;                                             
        }
    }
    void Movement()
    {
            axisH = Input.GetAxis("Horizontal");
        rb.AddTorque(-axisH * torqSpeed * Time.deltaTime);
    }

}
