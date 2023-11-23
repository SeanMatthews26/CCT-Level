using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    private Manager manager;
    [SerializeField] private GameObject compass;
    private Compass compassScript;

    public Sprite icon;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        manager = gameManager.GetComponent<Manager>();

        compassScript = compass.GetComponent<Compass>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        manager.Collect();
        compassScript.RemoveCollectable(this);
        Destroy(gameObject);
    }

    public Vector2 GetPosition()
    {
        return new Vector2(transform.position.x, transform.position.z);
    }
}
