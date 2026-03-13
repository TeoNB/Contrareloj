using UnityEngine;

public class Chekpoint : MonoBehaviour
{
    
    public GameManager Manager;
    public bool checkpointActivo = false;
    public Sprite SpriteActivo;
    private SpriteRenderer SpriteRenderer;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !checkpointActivo)
        {
            ActivarCheckpoint();
            
		}
	}

    void ActivarCheckpoint()
    {
        checkpointActivo = true;

        if (SpriteRenderer != null && SpriteActivo != null)
        {
            SpriteRenderer.sprite = SpriteActivo;
        }

        if (Manager != null)
        {
            Manager.Agregartiempo(5f);
        }
    }
}
