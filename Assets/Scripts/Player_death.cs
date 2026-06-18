using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_death : MonoBehaviour
{
    [SerializeField]AABB_Box player;
    [SerializeField]AABB_Box deathZone;

    void Update()
    {
        if(player.Overlaps(player.Bounds, deathZone.Bounds))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
