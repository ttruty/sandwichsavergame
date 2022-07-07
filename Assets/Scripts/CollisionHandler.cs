
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  void OnCollisionEnter(Collision other) {
    switch (other.gameObject.tag) {
      case "Friendly":
        Debug.Log("Friendly"+ "!");
        break;
      case "Finish":
        Debug.Log("Finish"+ "!");
        break;
      default:
        Debug.Log("You hit a " + other.gameObject.tag + "!");
        ReloadLevel();
        break;
    }
  }

  void ReloadLevel() {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
  }
}
