using NUnit.Framework;
using UnityEngine;

public class SetQualityTests
{
    private GameObject setQualityGameObject;
    private SetQuality setQualityScript;

    [SetUp]
    public void Setup()
    {
        setQualityGameObject = new GameObject();
        setQualityScript = setQualityGameObject.AddComponent<SetQuality>();
    }

    [TearDown]
    public void Teardown()
    {
        GameObject.Destroy(setQualityGameObject);
    }

    [Test]
    public void SetLowQuality()
    {
        setQualityScript.SetLowQuality();
        Assert.AreEqual(0, QualitySettings.GetQualityLevel());
    }

    [Test]
    public void SetMediumQuality()
    {
        setQualityScript.SetMediumQuality();
        Assert.AreEqual(3, QualitySettings.GetQualityLevel());
    }

    [Test]
    public void SetHighQuality()
    {
        setQualityScript.SetHighQuality();
        Assert.AreEqual(5, QualitySettings.GetQualityLevel());
    }
}
