using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RockPaperScossors : MonoBehaviour
{
    private enum ElementChoise
    {
        Rock,
        Paper,
        Scissors
    }

    [SerializeField] private Button _rockButton;
    [SerializeField] private Button _paperButton;
    [SerializeField] private Button _scissorsButton;
    
    private ElementChoise _playerElementChoise;
    private ElementChoise _computerElementChoise;
    private bool _buttonClickVisibility;

    private void Start()
    {
        _rockButton.onClick.AddListener(PlayerRockChoise);
        _paperButton.onClick.AddListener(PlayerPaperChoise);
        _scissorsButton.onClick.AddListener(PlayerScissorsChoise);
    }

    private void PlayerRockChoise()
    {
        _playerElementChoise = ElementChoise.Rock;
        Debug.Log("Вы выбрали: " + _playerElementChoise);

        _rockButton.GameObject().SetActive(false);
        
        StartCoroutine(ChooiseRockTick());
    }
    
    private void PlayerPaperChoise()
    {
        _playerElementChoise = ElementChoise.Paper;
        Debug.Log("Вы выбрали: " + _playerElementChoise);
        
        _rockButton.GameObject().SetActive(false);

        StartCoroutine(ChooisePaperTick());
    }
    
    private void PlayerScissorsChoise()
    {
        _playerElementChoise = ElementChoise.Scissors;
        Debug.Log("Вы выбрали: " + _playerElementChoise);
        
        _rockButton.GameObject().SetActive(false);

        StartCoroutine(ChooiseScissorsTick());
    }

    private void ComputerChoise()
    {
        _computerElementChoise = (ElementChoise)Random.Range(0, 3);
        Debug.Log("Компьютер выбрал: " + _computerElementChoise);
    }
    
    private IEnumerator ChooiseRockTick()
    {
        yield return new WaitForSeconds(2);
        
        ComputerChoise();
        
        switch (_playerElementChoise)
        {
            case ElementChoise.Rock:
                if (_computerElementChoise == ElementChoise.Scissors)
                {
                    Debug.Log("Вы победили");
                    _rockButton.GameObject().SetActive(true);
                }
                else if (_computerElementChoise == ElementChoise.Paper)
                {
                    Debug.Log("Вы проиграли");
                    _rockButton.GameObject().SetActive(true);
                }
                else if (_computerElementChoise == ElementChoise.Rock)
                {
                    Debug.Log("Ничья");
                    _rockButton.GameObject().SetActive(true);
                }
                break;
        }
    }

    private IEnumerator ChooisePaperTick()
    {
        yield return new WaitForSeconds(2);
        
        ComputerChoise();
        
        switch (_playerElementChoise)
        {
            case ElementChoise.Paper:
                if (_computerElementChoise == ElementChoise.Scissors)
                {
                    Debug.Log("Вы проиграли");
                    _rockButton.GameObject().SetActive(true);
                }
                else if (_computerElementChoise == ElementChoise.Paper)
                {
                    Debug.Log("Ничья");
                    _rockButton.GameObject().SetActive(true);
                }
                else if (_computerElementChoise == ElementChoise.Rock)
                {
                    Debug.Log("Вы победили");
                    _rockButton.GameObject().SetActive(true);
                }
                break;
        }
    }

    private IEnumerator ChooiseScissorsTick()
    {
        yield return new WaitForSeconds(2);
        
        ComputerChoise();
        
        switch (_playerElementChoise)
        {
            case ElementChoise.Scissors:
                if (_computerElementChoise == ElementChoise.Scissors)
                {
                    Debug.Log("Ничья");
                    _rockButton.GameObject().SetActive(true);
                }
                else if (_computerElementChoise == ElementChoise.Paper)
                {
                    Debug.Log("Вы победили");
                    _rockButton.GameObject().SetActive(true);
                }
                else if (_computerElementChoise == ElementChoise.Rock)
                {
                    Debug.Log("Вы проиграли");
                    _rockButton.GameObject().SetActive(true);
                }
                break;
        }
    }
}
