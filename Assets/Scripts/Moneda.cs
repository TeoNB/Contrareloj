using UnityEngine;

public class Moneda : MonoBehaviour
{
    public GameManager Manager;
    public GameObject monBronze;
    public GameObject monSilver;
    public GameObject monGold;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.name.Contains("Bronze"))
            {
                Manager.AddScore(10);
                Destroy(gameObject);
            }
            else if (gameObject.name.Contains("Silver"))
            {
                Manager.AddScore(20);
				Destroy(gameObject);
			}
            else if (gameObject.name.Contains("Gold"))
            {
                Manager.AddScore(30);
				Destroy(gameObject);
			}
            Destroy(gameObject);
        }
	}
}
