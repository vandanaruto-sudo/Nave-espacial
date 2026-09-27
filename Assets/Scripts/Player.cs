using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float thrustForce = 400f;
    public float rotationSpeed = 130f;

    public GameObject gun;
    public static int SCORE;
    

    private Rigidbody2D rb;


    void Start()
    {
        SCORE =0;
        
        rb = GetComponent<Rigidbody2D>();
        
    }


    void Update()
    {
        float thrust = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");

        Vector3 thrustDirection = transform.right;
        rb.AddForce(thrustDirection * thrust * thrustForce * Time.deltaTime);
        transform.Rotate(Vector3.forward, -rotation * rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = BulletPool.Instance.RequestBullet();
            if (bullet != null)
            {
                 bullet.transform.position = gun.transform.position;
                 bullet.transform.rotation = Quaternion.identity; 

                 bullet.GetComponent<Bullet>().tarjectVector = thrustDirection;
            }

    
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy")){
        SCORE = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
