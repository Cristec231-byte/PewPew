using NUnit.Framework;
using UnityEngine;

public class HealthTest
{
    private GameObject setQualityGameObject;
    private SetQuality setQualityScript;

    [SetUp]
    public void Setup()
    {
        // Create a new GameObject to attach the SetQuality script to
        setQualityGameObject = new GameObject();
        setQualityScript = setQualityGameObject.AddComponent<SetQuality>();
    }

    [TearDown]
    public void Teardown()
    {
        // Clean up the GameObject after each test
        GameObject.Destroy(setQualityGameObject);
    }

    [Test]
    public void SetLowQuality_SetsQualityToLow()
    {
        // Act
        setQualityScript.SetLowQuality();

        // Assert
        Assert.AreEqual(0, QualitySettings.GetQualityLevel()); // Check if quality is set to low
    }

    [Test]
    public void SetMediumQuality_SetsQualityToMedium()
    {
        // Act
        setQualityScript.SetMediumQuality();

        // Assert
        Assert.AreEqual(3, QualitySettings.GetQualityLevel()); // Check if quality is set to medium
    }

    [Test]
    public void SetHighQuality_SetsQualityToHigh()
    {
        // Act
        setQualityScript.SetHighQuality();

        // Assert
        Assert.AreEqual(5, QualitySettings.GetQualityLevel()); // Check if quality is set to high
    }

    [Test]
    public void SetQualityLevel_SetsQualityToGivenIndex()
    {
        // Arrange
        int qualityIndex = 2; // Example quality index

        // Act
        setQualityScript.SetQualityLevel(qualityIndex);

        // Assert
        Assert.AreEqual(qualityIndex, QualitySettings.GetQualityLevel()); // Check if quality is set to the given index
    }
}
