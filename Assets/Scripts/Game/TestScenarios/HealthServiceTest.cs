using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthServiceTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForCharacter());
    }

    IEnumerator WaitForCharacter()
    {
        yield return new WaitUntil(() => Game.Model.Characters.HasUniqueName(Name.TestAgent));
        Test();
    }

    void Test()
    {
        Game.Do(new TestHealthCommand());
    }
}
