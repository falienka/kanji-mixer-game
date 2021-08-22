using UnityEngine;

public class Kanji : MonoBehaviour
{   
    public GameObject kanjiSign;
    public KanjiItem kanjiItem;

    [SerializeField] private bool triggerActive = false;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _kanjiRenderer;
    private Inventory _inventory;

    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _kanjiRenderer = kanjiSign.GetComponent<SpriteRenderer>();
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
            _kanjiRenderer.enabled = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
            _kanjiRenderer.enabled = false;
        }
    }

    void OnMouseDown()
    {
        if (triggerActive)
        {
            _inventory.AddItem(kanjiItem);
            Destroy(gameObject);
        }
    }
}
