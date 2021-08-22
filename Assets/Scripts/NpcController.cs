using Optional;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public Dialog dialogManager;
    public DialogObject dialog1;
    public DialogObject dialog2;
    public bool requireItem;
    public PuzzleObject requiredItem;
    public Sprite solvedSprite;
    public SpriteRenderer solvedObject;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        SolvePuzzle();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !dialogManager.isActiveAndEnabled)
        {
            dialogManager.StartDialog(dialog1);
            requireItem = true;
        }
    }

    private void SolvePuzzle()
    {
        if (requireItem)
        {
            if (GameManager.Inst.heldItem == requiredItem.answerKanji)
            {
                GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().GiveKanji();
                requireItem = false;
                requiredItem.Solve();
                _spriteRenderer.sprite = solvedSprite;
                if(solvedObject != null) solvedObject.enabled = true;
                dialogManager.gameObject.SetActive(false);
                dialog1 = dialog2;
                dialogManager.StartDialog(dialog1);
            }
        }
    }

}
