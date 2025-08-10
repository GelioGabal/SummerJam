using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] TMP_Dropdown localeDropdown;
    [SerializeField] Toggle humster;
    void Start()
    {
        humster.isOn = PlayerPrefs.HasKey("Character") ? PlayerPrefs.GetInt("Character") == 0 : false;
        int key = PlayerPrefs.HasKey("Locale") ? PlayerPrefs.GetInt("Locale") : 0;
        ChangeLocale(key);
        StartCoroutine(initLocaleDropdown());
    }
    bool localing = false;
    public void ChangeLocale(int id) { if (!localing) StartCoroutine(setLocale(id)); }
    IEnumerator setLocale(int id)
    {
        localing = true;
        localeDropdown.value = id;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[id];
        PlayerPrefs.SetInt("Locale", id);
        localing = false;
    }
    IEnumerator initLocaleDropdown()
    {
        yield return LocalizationSettings.InitializationOperation;
        List<string> locales = LocalizationSettings.AvailableLocales.Locales.Select(locale => locale.name).ToList();
        localeDropdown.options = locales.Select(locale => new TMP_Dropdown.OptionData { text = locale }).ToList();
    }
    public static string GetLocalizedString(string key) =>
        new LocalizedString { TableReference = "LocalTable", TableEntryReference = key }.GetLocalizedString();
}
