using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public float velCamara = 0.025f;
    public Vector2 desplazamiento;

	//Puntuación
	public TextMeshProUGUI scoreText;
	int score = 0;
	public TextMeshProUGUI gameovertext;
    public TextMeshProUGUI Victory;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 posicionDeseada = player.position + new Vector3(desplazamiento.x, desplazamiento.y, -10);
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, velCamara);
        transform.position = posicionSuavizada;
	}

	public void AddScore(int points)
	{
		score += points;
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		
		// Mostrar mensaje de Game Over
		gameovertext.text = "Game Over! Final Score: " + score;
		gameovertext.gameObject.SetActive(true);

	}
}
