using System.Collections;
using Project.Scripts.Constants;
using Project.Scripts.GameControl.Loader;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Project.Scripts.GameControl
{
    public class Starter : MonoBehaviour
    {
        private ILevelLoader _loader;
        
        [Inject]
        private void Construct(ILevelLoader loader)
        {
            _loader = loader;
        }
            
        public void Initialize()
        {
            StartCoroutine(LoadLevel());
        }
        
        private IEnumerator LoadLevel()
        {
            DontDestroyOnLoad(gameObject);
            yield return SceneManager.LoadSceneAsync(SceneNames.GameScene);
            _loader.Load().Then(() => Destroy(gameObject));
        }
    }
}