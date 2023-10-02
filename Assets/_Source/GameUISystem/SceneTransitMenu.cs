using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace GameUISystem
{
    public class SceneTransitMenu : MonoBehaviour, ISceneTransitMenu
    {
        [SerializeField] private int nextSceneID;
        
        public void OnTransit(InputAction.CallbackContext obj)
        {
            SceneManager.LoadScene(nextSceneID);
        }
    }
}