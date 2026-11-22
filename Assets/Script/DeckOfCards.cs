using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckOfCards : MonoBehaviour
{
    [SerializeField] private DynamicGrid GridForCardsInHand;
    [SerializeField] private Vector3 GridSize;
    private Dictionary<string, int> numberOfDiffrentCards = new Dictionary<string, int>();
    private Dictionary<string,Cards> Discard = new Dictionary<string,Cards>();
    private Dictionary<string,Cards>  Deck = new Dictionary<string,Cards>();
    private Dictionary<string,Cards> CardInHand = new Dictionary<string,Cards>();
    public static DeckOfCards Instance {get; private set;}
    public int SameCardsInDeck(string cardName) => numberOfDiffrentCards.TryGetValue(cardName, out int numberOfCards) ? numberOfCards : 0;
    public bool IsCard(string cardName) => numberOfDiffrentCards.ContainsKey(cardName);
    public bool IsDictionaryReady{get; private set;}
    
    private int numbersOfcardsInDeck;
    public IEnumerator InitialDrawCard()
    {
        InitializeDeck();
        
        // Debug.Log("Deck is made");
        // Debug.Log($"numbers of cards registered are {numbersOfcardsInDeck} and Deck number are {Deck.Count}");
        yield return new WaitUntil(() => Deck.Count == numbersOfcardsInDeck);
        // Debug.Log(" Wait is done");
        GridForCardsInHand.InitializeGrid(GridSize, 10, 1);

        List<string> cardNamesInDeck = new List<string>(Deck.Keys);
        foreach(Vector3 n in GridForCardsInHand.nodes)
        {
            int rando =  Random.Range(0, cardNamesInDeck.Count);
            // Debug.Log($" cards are {cardNamesInDeck[rando]}");
            Cards clone = Instantiate(Deck[cardNamesInDeck[rando]], n, Quaternion.identity);
            clone.IsClone = true;
            cardNamesInDeck.Remove(cardNamesInDeck[rando]);
        }
        
        yield return null;
    }
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(InitialDrawCard());
    }

    private void InitializeDeck()
    {
        IsDictionaryReady = false;
        numberOfDiffrentCards.Add("swipe", 4);
        numberOfDiffrentCards.Add("punch", 4);
        numberOfDiffrentCards.Add("stun", 4);
        numberOfDiffrentCards.Add("heal", 4);
        numberOfDiffrentCards.Add("shield", 4);
        numberOfDiffrentCards.Add("paw", 4);
        numberOfDiffrentCards.Add("fist of doom", 4);

        List<int> ListOfCards = new List<int>(numberOfDiffrentCards.Values);
        foreach(int n in ListOfCards)
            numbersOfcardsInDeck += n;

        IsDictionaryReady = true;
    }
    
    public void RegisterCardType(string key, Cards card)
    {
        int uniqueCardNumber = numberOfDiffrentCards[key];
        for(int i = 0; i < uniqueCardNumber; i++)
        {
            Deck.Add(key + i, card);
        }
    }
}