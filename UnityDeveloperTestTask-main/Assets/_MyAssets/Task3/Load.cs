using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    ARPlacement ar;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return null;

        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName("3-Foundation"));
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(1);

        ar = FindObjectOfType<ARPlacement>();
        gameObject.transform.position = ar.placementPos;
        gameObject.transform.rotation = ar.placementRot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
