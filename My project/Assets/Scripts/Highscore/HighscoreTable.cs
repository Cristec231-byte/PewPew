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

        // Sort the entry list by time (ascending order)
        highscores.highscoreEntryList.Sort((x, y) => x.time.CompareTo(y.time));

        // Limit to the top 5 times
        highscoreEntryTransformList = new List<Transform>();
        int topScoresCount = Mathf.Min(highscores.highscoreEntryList.Count, 5);
        for (int i = 0; i < topScoresCount; i++)
        {
            CreateHighscoreEntryTransform(highscores.highscoreEntryList[i], entryContainer, highscoreEntryTransformList);
        }
    }

    private void AddDefaultHighscores(Highscores highscores)
    {
        AddHighscoreEntry(1200, "CMK"); // Updated to match method signature
        AddHighscoreEntry(1300, "JOE");
        AddHighscoreEntry(1500, "DAV");
        AddHighscoreEntry(1600, "CAT");
        AddHighscoreEntry(1700, "MAX");
        AddHighscoreEntry(1800, "AAA");

        // Save the updated highscores back to PlayerPrefs
        SaveHighscores(highscores);
    }

    private void SaveHighscores(Highscores highscores)
    {
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    public void AddHighscoreEntry(int time, string name)
    {
        // Load the current highscore table
        string jsonString = PlayerPrefs.GetString("highscoreTable", "{}");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null || highscores.highscoreEntryList == null)
        {
            highscores = new Highscores { highscoreEntryList = new List<HighscoreEntry>() };
        }

        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { time = time, name = name };
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        SaveHighscores(highscores);

        // Refresh the highscore display (optional)
        RefreshHighscoreTable();
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
        entryTransform.Find("scoreText").GetComponent<Text>().text = highscoreEntry.time.ToString();
        entryTransform.Find("nameText").GetComponent<Text>().text = highscoreEntry.name;

        transformList.Add(entryTransform);
    }

    private void RefreshHighscoreTable()
    {
        // Remove all existing entries
        foreach (Transform child in entryContainer)
        {
            Destroy(child.gameObject);
        }

        // Reload the highscores and display the top 5 again
        string jsonString = PlayerPrefs.GetString("highscoreTable", "{}");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Sort by shortest time
        highscores.highscoreEntryList.Sort((x, y) => x.time.CompareTo(y.time));

        highscoreEntryTransformList = new List<Transform>();
        int topScoresCount = Mathf.Min(highscores.highscoreEntryList.Count, 5);
        for (int i = 0; i < topScoresCount; i++)
        {
            CreateHighscoreEntryTransform(highscores.highscoreEntryList[i], entryContainer, highscoreEntryTransformList);
        }
    }

    [System.Serializable]
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int time; // Time instead of score
        public string name;
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    public void Awake()
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

        // Sort the entry list by score
        highscores.highscoreEntryList.Sort((x, y) => y.score.CompareTo(x.score));

        // Limit to the top 5 scores
        highscoreEntryTransformList = new List<Transform>();
        int topScoresCount = Mathf.Min(highscores.highscoreEntryList.Count, 5);
        for (int i = 0; i < topScoresCount; i++)
        {
            CreateHighscoreEntryTransform(highscores.highscoreEntryList[i], entryContainer, highscoreEntryTransformList);
        }
    }

    public void AddDefaultHighscores(Highscores highscores)
    {
        AddHighscoreEntry(1000000, "CMK", highscores);
        AddHighscoreEntry(897621, "JOE", highscores);
        AddHighscoreEntry(872931, "DAV", highscores);
        AddHighscoreEntry(785123, "CAT", highscores);
        AddHighscoreEntry(542024, "MAX", highscores);
        AddHighscoreEntry(68245, "AAA", highscores);

        // Save the updated highscores back to PlayerPrefs
        SaveHighscores(highscores);
    }

    public void SaveHighscores(Highscores highscores)
    {
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    public void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
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
        entryTransform.Find("scoreText").GetComponent<Text>().text = highscoreEntry.score.ToString();
        entryTransform.Find("nameText").GetComponent<Text>().text = highscoreEntry.name;

        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(int score, string name, Highscores highscores)
    {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        SaveHighscores(highscores);
    }

    [System.Serializable]
    public class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList = new List<HighscoreEntry>();
    }

    [System.Serializable]
    public class HighscoreEntry
    {
        public int score;
        public string name;
    }
}*/
