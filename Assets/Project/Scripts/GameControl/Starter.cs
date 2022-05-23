using System.Collections;
using Project.Scripts.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.GameControl
{
    public class Starter : MonoBehaviour
    {
        public void Start()
        {
            StartCoroutine(LoadLevel());
        }
        
        private IEnumerator LoadLevel()
        {
            yield return SceneManager.LoadSceneAsync(SceneNames.GameScene);
            yield return new WaitForEndOfFrame();
            yield return SceneManager.UnloadSceneAsync(SceneNames.StartUpScene);
        }
    }
}