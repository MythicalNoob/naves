using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI shipCodeText;
    public TMP_InputField searchCodeField;
    public Button searchCodeButton;
    public Button nextButton;
    public Button previousButton;
    public Button showCodesButton;

    public List<Material> capsuleColors;
    public List<Material> metalColors;
    public List<Material> neonColors;

    public ColourShip ship;

    int permutationCode = 0;
    bool perm;
    // Start is called before the first frame update
    void Start()
    {
        searchCodeButton.onClick.AddListener(SearchCode);
        nextButton.onClick.AddListener(NextCombination);
        previousButton.onClick.AddListener(PreviousCombination);
        showCodesButton.onClick.AddListener(ShowCodes);

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void SearchCode()
    {
        int value = int.Parse(searchCodeField.text);

        permutationCode = value;

        int lightsIndex = permutationCode % neonColors.Count;
        int holderIndex = Mathf.FloorToInt(permutationCode / neonColors.Count) % metalColors.Count;
        int shipIndex = Mathf.FloorToInt(permutationCode / (neonColors.Count * metalColors.Count)) % metalColors.Count;
        int capsuleIndex = Mathf.FloorToInt(permutationCode / (neonColors.Count * metalColors.Count * metalColors.Count)) % capsuleColors.Count;

        ship.capsuleMaterial = capsuleColors[capsuleIndex];
        ship.shipMaterial = metalColors[shipIndex];
        ship.holderMaterial = metalColors[holderIndex];
        ship.lightsMaterial = neonColors[lightsIndex];
        ship.ColourShipNow();
        shipCodeText.text = permutationCode.ToString();
    }

    void NextCombination()
    {
        if (permutationCode == 9216) permutationCode = 0;
        permutationCode++;

        int lightsIndex = permutationCode % neonColors.Count;
        int holderIndex = Mathf.FloorToInt(permutationCode / neonColors.Count) % metalColors.Count;
        int shipIndex = Mathf.FloorToInt(permutationCode / (neonColors.Count * metalColors.Count)) % metalColors.Count;
        int capsuleIndex = Mathf.FloorToInt(permutationCode / (neonColors.Count * metalColors.Count * metalColors.Count)) % capsuleColors.Count;

        ship.capsuleMaterial = capsuleColors[capsuleIndex];
        ship.shipMaterial = metalColors[shipIndex];
        ship.holderMaterial = metalColors[holderIndex];
        ship.lightsMaterial = neonColors[lightsIndex];
        ship.ColourShipNow();
        shipCodeText.text = permutationCode.ToString();
    }

    void PreviousCombination()
    {
        if (permutationCode == 0) permutationCode = 9216;
        permutationCode--;

        int lightsIndex = permutationCode % neonColors.Count;
        int holderIndex = Mathf.FloorToInt(permutationCode / neonColors.Count) % metalColors.Count;
        int shipIndex = Mathf.FloorToInt(permutationCode / (neonColors.Count * metalColors.Count)) % metalColors.Count;
        int capsuleIndex = Mathf.FloorToInt(permutationCode / (neonColors.Count * metalColors.Count * metalColors.Count)) % capsuleColors.Count;

        ship.capsuleMaterial = capsuleColors[capsuleIndex];
        ship.shipMaterial = metalColors[shipIndex];
        ship.holderMaterial = metalColors[holderIndex];
        ship.lightsMaterial = neonColors[lightsIndex];
        ship.ColourShipNow();
        shipCodeText.text = permutationCode.ToString();
    }

    void ShowCodes()
    {
        /*ship.capsuleMaterial = capsuleColors[0]; 
        ship.shipMaterial = metalColors[0]; 
        ship.holderMaterial = metalColors[0]; 
        ship.lightsMaterial = neonColors[0];
        ship.ColourShipNow();*/

        StartCoroutine(NextColor());

       // StartCoroutine(capColors());
    }

    IEnumerator NextColor()
    {
        yield return new WaitForSeconds(0.2f);
        int lightsIndex = permutationCode % neonColors.Count;
        int holderIndex = Mathf.FloorToInt(permutationCode/ neonColors.Count) % metalColors.Count;
        int shipIndex = Mathf.FloorToInt(permutationCode/ (neonColors.Count * metalColors.Count)) % metalColors.Count;
        int capsuleIndex = Mathf.FloorToInt(permutationCode/ (neonColors.Count * metalColors.Count * metalColors.Count)) % capsuleColors.Count;

        ship.capsuleMaterial = capsuleColors[capsuleIndex];
        ship.shipMaterial = metalColors[shipIndex];
        ship.holderMaterial = metalColors[holderIndex];
        ship.lightsMaterial = neonColors[lightsIndex];
        ship.ColourShipNow();
        permutationCode++;
        shipCodeText.text = permutationCode.ToString();

        StartCoroutine(NextColor());
    }

    

    //INTENTO DE PERMUTACIÓN

 /*   IEnumerator capColors()
    {
        int index = 0;


        while (perm)
        {
            index++;

            yield return new WaitForSeconds(5);
            ship.capsuleMaterial = capsuleColors[index];
            ship.ColourShipNow();
            StartCoroutine(shColors());

            if (index == 8) perm = false;
        }
    }

    IEnumerator shColors()
    {
        int index = 0;


        while (perm)
        {
            index++;

            yield return new WaitForSeconds(4);
            ship.shipMaterial = metalColors[index];
            ship.ColourShipNow();
            StartCoroutine(holdColors());

            if (index == 12) perm = false;
        }
    }
    IEnumerator holdColors()
    {
        int index = 0;


        while (perm)
        {
            index++;

            yield return new WaitForSeconds(3);
            ship.holderMaterial = metalColors[index];
            ship.ColourShipNow();
            StartCoroutine(nColors());

            if (index == 12) perm = false;
        }
    }

    IEnumerator nColors()
    {
        int index = 0;


        while (perm)
        {
            index++;

            yield return new WaitForSeconds(2);
            ship.lightsMaterial = neonColors[index];
            ship.ColourShipNow();

            if (index == 8) perm = false;
        }
    }*/
}
