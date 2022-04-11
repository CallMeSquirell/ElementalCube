using System.Collections;
using Project.Scripts.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.GameControl
{
    public class Starter : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(LoadLevel());
        }
        
        private IEnumerator LoadLevel()
        {
            DontDestroyOnLoad(gameObject);
            yield return SceneManager.LoadSceneAsync(SceneNames.GameScene);
            Destroy(gameObject);
        }
    }
}