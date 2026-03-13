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

	//Temporizador
	public TextMeshProUGUI tiempoText;
	int minutos = 1;
	float segundos = 30f;
	bool terminado = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        


		ActualizarTiempo();

	}

    // Update is called once per frame
    void Update()
    {
		if (terminado) return;
		segundos -= Time.deltaTime;
		if (segundos <= 0 && minutos > 0) 
		{
			minutos -= 1;
			segundos = 60;
		} else if(segundos <= 0 && minutos <= 0)
		{
			GameOver();
		}

		ActualizarTiempo();

	}

    private void LateUpdate()
    {
        Vector3 posicionDeseada = player.position + new Vector3(desplazamiento.x, desplazamiento.y, -10);
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, velCamara);
        transform.position = posicionSuavizada;
	}

	public void ActualizarTiempo()
	{
		if (segundos < 9.5f)
		{
			tiempoText.text = "Time: " + minutos.ToString("0") + ":" + segundos.ToString("00.0");
		}
		else
		{
			tiempoText.text = "Time: " + minutos.ToString("0") + ":" + segundos.ToString("00");
		}
	}


	
	
	public void Agregartiempo(float extra) 
	{
		segundos += extra;
	}

	public void AddScore(int points)
	{
		score += points;
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		terminado = true;
		gameovertext.text = "Game Over! Final Score: " + score;
		gameovertext.gameObject.SetActive(true);

	}

	public void Victoria()
	{
		terminado = true;
		Victory.text = "Victory! Final Score: " + score;
		Victory.gameObject.SetActive(true);

		
	}
}
