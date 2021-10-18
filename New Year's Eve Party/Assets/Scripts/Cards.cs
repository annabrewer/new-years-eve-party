
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Cards : UdonSharpBehaviour
{
    public GameObject card;
    public GameObject cardStack;
    public GameObject cardFront;
    public Material[] materials;
    private int[] cardNumbers;
    private int cardIndex = 0;
    private Random random = new Random();
    private float totalTime = 0;
    private string cardState; // workaround because enum not supported

    private float topCardHeight = 0.021f;
    private float cardStackYScale = 0.05f;

    void Start()
    {
        cardState = "idle";
        cardNumbers = new int[52];
        for (int i = 0; i < 52; i++)
        {
            cardNumbers[i] = i;
        }
        shuffle(cardNumbers);
    }

    private void Update()
    {
        switch (cardState)
        {
            case "idle":
                break;
            case "aboutToDraw":
                break;
            case "drawingCard":
                totalTime += Time.deltaTime;
                card.transform.Translate(Vector3.up * Time.deltaTime);
                card.transform.Translate(Vector3.forward * (-1f * Time.deltaTime));
                card.transform.Rotate(Vector3.right, 90f * Time.deltaTime);
                if (totalTime >= 1)
                {
                    cardState = "floatingCard";
                    totalTime = 0;
                }
                break;
            case "floatingCard":
                card.transform.Rotate(Vector3.forward, 90f * Time.deltaTime);
                break;
        }
    }

    public override void Interact()
    {
        drawCard();
    }

    public void drawCard()
    {
        if (cardIndex <= 51)
        {
            cardState = "drawingCard";
            card.transform.localPosition = new Vector3(0, topCardHeight, 0);
            card.transform.localRotation = Quaternion.Euler(0, 0, 0);
            int cardNumber = cardNumbers[cardIndex];
            cardFront.GetComponent<Renderer>().material = materials[cardNumber]; // just using one suit for now
            cardStack.transform.localScale = new Vector3(0.25f, cardStackYScale * ((51 - cardIndex) / 52.0f), 0.35f);
            cardIndex++;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Fisher-Yates shuffle
    void shuffle(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < (n - 1); i++)
        {
            int r = i + Random.Range(0, n - i);
            int t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
}