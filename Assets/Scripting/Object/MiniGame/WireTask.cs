using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class WireTask : MiniGamePanel
{
    public bool isAllSolved = false;
    public List<Color> wireColors = new ();
    public List<Wire> leftWires = new ();
    public List<Wire> rightWires = new ();
    public Wire curWire;
    public Wire curHoveredWire;
    
    private List<Color> _availableColors;
    private List<int> _availableLeftWireIndex;
    private List<int> _availableRightWireIndex;
    
    public UnityEvent OnSolve;

    private void Awake()
    {
        OnSolve.AddListener(() => 
        {
            Debug.Log("Solved Wires");
        });
        
        // SetWireColors();
    }

    private void Start()
    {
        // SetWireColors();
        RandomizeWireColors();
        ClosePanel();
    }
    
    public void RandomizeWireColors()
    {
        _availableColors = new List<Color>(wireColors);
        _availableLeftWireIndex = new List<int>();
        _availableRightWireIndex = new List<int>();

        for (int i = 0; i < leftWires.Count; i++)
        {
            _availableLeftWireIndex.Add(i);
        }
    
        for (int i = 0; i < rightWires.Count; i++)
        {
            _availableRightWireIndex.Add(i);
        }

        // Отдельные списки для значений индексов
        List<int> shuffledLeftIndices = new List<int>(_availableLeftWireIndex);
        List<int> shuffledRightIndices = new List<int>(_availableRightWireIndex);

        // Перемешиваем индексы
        for (int i = 0; i < shuffledLeftIndices.Count; i++) {
            int temp = shuffledLeftIndices[i];
            int randomIndex = Random.Range(i, shuffledLeftIndices.Count);
            shuffledLeftIndices[i] = shuffledLeftIndices[randomIndex];
            shuffledLeftIndices[randomIndex] = temp;
        }

        for (int i = 0; i < shuffledRightIndices.Count; i++) {
            int temp = shuffledRightIndices[i];
            int randomIndex = Random.Range(i, shuffledRightIndices.Count);
            shuffledRightIndices[i] = shuffledRightIndices[randomIndex];
            shuffledRightIndices[randomIndex] = temp;
        }
        
        for (int i = 0; i < Mathf.Min(_availableColors.Count, shuffledLeftIndices.Count, shuffledRightIndices.Count); i++)
        {
            Color color = _availableColors[i];
            int leftIndex = shuffledLeftIndices[i];
            int rightIndex = shuffledRightIndices[i];
        
            leftWires[leftIndex].SetColor(color);
            leftWires[leftIndex].isSolved = false;
            rightWires[rightIndex].SetColor(color);
            rightWires[rightIndex].isSolved = false;
        }
        
        isAllSolved = false;
    }

    public void CheckSolvedWires()
    {
        var solvedWires = rightWires.Count(t => t.isSolved);

        if (solvedWires >= rightWires.Count)
        {
            isAllSolved = true;
            OnSolve?.Invoke();
        }
        else
        {
            Debug.Log("Unsolved Wires");
        }
    }
}
