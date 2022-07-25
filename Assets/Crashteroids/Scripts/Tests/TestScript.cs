using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    [UnityTest]
    public IEnumerator TestScriptWithEnumeratorPasses()
    {
        GameObject gameHandler = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameHandler"));
        DuckMovement player = gameHandler.GetComponent<GameHandler>().GetPlayer();
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        float initialXPos = player.transform.position.x;
        Vector3 dir = new Vector3(20f, 0, 0); 
        player.Move(dir);
        yield return new WaitForSeconds(0.5f);
        Assert.Greater(player.transform.position.x, initialXPos);
        yield return null;
    }
}
