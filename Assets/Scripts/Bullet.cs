using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 7f;
    public float vidaBala = 3f;
    public Vector3 tarjectVector;

    void OnEnable()
    {
        Invoke(nameof(Desactivar), 3f);
        
    }
    private void Desactivar()
    {
        gameObject.SetActive(false);
    }


    void Update()
    {
        transform.Translate(speed * tarjectVector * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IncreaseScore();
        if (collision.gameObject.CompareTag("Enemy")){
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }

    private void IncreaseScore()
    {
        Player.SCORE++;

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<TextMeshProUGUI>().text = "Puntos: " + Player.SCORE;
    }
}
