using UnityEngine;
using System.Collections;

public abstract class Cards : MonoBehaviour
{
    public bool IsClone = false;
    protected IEnumerator Register()
    {
        yield return new WaitUntil(() => DeckOfCards.Instance.IsDictionaryReady);

        if(DeckOfCards.Instance.IsCard(this.tag))
        {
            DeckOfCards.Instance.RegisterCardType(tag, this);
        }
    }

    public void Start()
    {
        if(IsClone) return;
        StartCoroutine(Register());
    }
}
