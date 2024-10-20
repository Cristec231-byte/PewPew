using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        // Attempt to load the highscores from PlayerPrefs
        string jsonString = PlayerPrefs.GetString("highscoreTable", "{}");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Check if highscores is null or if the list is null
        if (highscores == null || highscores.highscoreEntryList == null)
        {
            // Initialize with default test values
            Debug.Log("Initializing table with default values...");
            highscores = new Highscores
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
            AddDefaultHighscores(highscores);
        }

        // Sort the entry list by time in ascending order (shortest time first)
        highscores.highscoreEntryList.Sort((x, y) => x.time.CompareTo(y.time)); // Using timer for sorting

        // Limit to the top 5 times
        highscoreEntryTransformList = new List<Transform>();
        int topTimesCount = Mathf.Min(highscores.highscoreEntryList.Count, 5);
        for (int i = 0; i < topTimesCount; i++)
        {
            CreateHighscoreEntryTransform(highscores.highscoreEntryList[i], entryContainer, highscoreEntryTransformList);
        }
    }

    private void AddDefaultHighscores(Highscores highscores)
    {
        // Adding default entries with timer values
        AddHighscoreEntry(60.52f, "CMK", highscores); // Time in seconds
        AddHighscoreEntry(45.89f, "JOE", highscores); // Time in seconds
        AddHighscoreEntry(78.29f, "DAV", highscores); // Time in seconds
        AddHighscoreEntry(90.12f, "CAT", highscores); // Time in seconds
        AddHighscoreEntry(120.24f, "MAX", highscores); // Time in seconds
        AddHighscoreEntry(32.45f, "AAA", highscores); // Time in seconds

        // Save the updated highscores back to PlayerPrefs
        SaveHighscores(highscores);
    }

    private void SaveHighscores(Highscores highscores)
    {
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 60f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
        // Display time instead of score
        entryTransform.Find("scoreText").GetComponent<Text>().text = highscoreEntry.time.ToString("F2") + "s"; // Timer is shown here
        entryTransform.Find("nameText").GetComponent<Text>().text = highscoreEntry.name;

        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(float time, string name, Highscores highscores)
    {
        // Create HighscoreEntry using timer
        HighscoreEntry highscoreEntry = new HighscoreEntry { time = time, name = name }; // Timer value
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        SaveHighscores(highscores);
    }

    [System.Serializable]
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList = new List<HighscoreEntry>();
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public float time; // Changed from 'score' to 'time' for the timer
        public string name;
    }
}
