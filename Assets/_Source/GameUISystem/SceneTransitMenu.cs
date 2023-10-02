using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameUISystem
{
    public class SceneTransitMenu : MonoBehaviour, ISceneTransitMenu
    {
        [SerializeField] private int nextSceneID;
        public void OnTransit(InputAction.CallbackContext obj)
        {
            Destroy(FindObjectOfType<SceneContext>().gameObject);
            SceneManager.LoadScene(nextSceneID);
        }
    }
}