using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;

public class DeckOfCards : MonoBehaviour
{
    [SerializeField] private DynamicGrid GridForCardsInHand;
    [SerializeField] private Vector3 GridSize;
    private Dictionary<string, int> numberOfDiffrentCards = new Dictionary<string, int>();
    private Dictionary<string, GameObject> Discard = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject>  Deck = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> CardInHand = new Dictionary<string, GameObject>();
    public static DeckOfCards Instance {get; private set;}
    public int SameCardsInDeck(string cardName) => numberOfDiffrentCards.TryGetValue(cardName, out int numberOfCards) ? numberOfCards : 0;
    public bool IsCard(string cardName) => numberOfDiffrentCards.ContainsKey(cardName);
    public bool IsDictionaryReady;
    
    private int numbersOfcardsInDeck;
    private int numberOfRegisteredCard;
    public IEnumerator DrawCard()
    {
        InitializeDeck();
        
        yield return new WaitUntil(() => Deck.Count == numbersOfcardsInDeck);
        GridForCardsInHand.InitializeGrid(GridSize, 10, 1);

        List<string> cardNamesInDeck = new List<string>(Deck.Keys);
        foreach(Vector3 n in GridForCardsInHand.nodes)
        {
            int rando =  Random.Range(0, cardNamesInDeck.Count);
            Discard[cardNamesInDeck[rando]] = Deck[cardNamesInDeck[rando]];
            Deck.Remove(cardNamesInDeck[rando]);
            Debug.Log($" cards are {cardNamesInDeck[rando]}");
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
        StartCoroutine(DrawCard());
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

    public void RegisterCardType(string key, GameObject cardPrefab)
    {
        int uniqueCardNumber = numberOfDiffrentCards[key];
        for(int i = 0; i < uniqueCardNumber; i++)
        {
            Deck.Add(key + i, cardPrefab);
            numberOfRegisteredCard++;
        }
    }
}