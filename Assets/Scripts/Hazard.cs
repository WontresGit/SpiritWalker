using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{

        void OnTriggerEnter(Collider col)
        {
        if (col.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene("Marshmallow_Level_2");
        }
    }
}
