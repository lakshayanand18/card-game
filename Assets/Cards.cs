using UnityEngine;
using System.Collections;

public abstract class Cards : MonoBehaviour
{
    protected IEnumerator Register()
    {
        yield return new WaitUntil(() => DeckOfCards.Instance.IsDictionaryReady);

        if(DeckOfCards.Instance.IsCard(this.tag))
        {
            DeckOfCards.Instance.RegisterCardType(tag, gameObject);
        }
    }
    
    public void Start()
    {
        StartCoroutine(Register());
    }
}
