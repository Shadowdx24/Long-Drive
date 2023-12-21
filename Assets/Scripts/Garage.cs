using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Garage : MonoBehaviour
{
    [SerializeField] private Image carSelection;
    [SerializeField] private Sprite[] carImages;
    private int carIndex;
    // Start is called before the first frame update
    void Start()
    {
        carIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextCar()
    {
        carIndex++;
        ShowCar(carIndex);
    }
    public void PrevCar()
    {
        carIndex--;
        ShowCar(carIndex);
    }
    private void ShowCar(int carNumber)
    {
        if(carNumber >= carImages.Length-1)
        {
            carNumber =0;
        }
        else if(carNumber < 0)
        {
            carNumber =carImages.Length-1;
        }
        carIndex = carNumber;
        carSelection.sprite = carImages[carIndex];
    }
}
