using UnityEngine;

[CreateAssetMenu]
public class PuzzleObject : ScriptableObject
{
    public KanjiItem answerKanji;
    public bool isSolved;

    public void Solve()
    {
        isSolved = true;
    }
}
