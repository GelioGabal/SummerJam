using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] List<Animator> characters = new();
    public int currentCharacter { get; private set; } = 1;
    public Animator GetAnimator => characters[currentCharacter];
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Character"))
            SetCharacter(PlayerPrefs.GetInt("Character"));
    }
    public void SetCharacter(int id)
    {
        currentCharacter = id;
        PlayerPrefs.SetInt("Character", currentCharacter);
        if (characters.Count == 0) return;
        foreach (var character in characters) 
            character.gameObject.SetActive(false);
        characters[currentCharacter].gameObject.SetActive(true);
    }
    public void TogglePig(bool enabled) => SetCharacter(enabled ? 0 : 1);
}
