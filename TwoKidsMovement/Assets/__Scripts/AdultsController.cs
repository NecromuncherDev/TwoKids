using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class AdultsController : MonoBehaviour
{
    [SerializeField]
    float startFollowingTimeout = 3;

    public static AdultsController Instance;

    public bool isFollowing;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleFollow()
    {
        StartCoroutine(Follow());
    }

    private IEnumerator Follow()
    {
        isFollowing = !isFollowing;
        yield return new WaitForSeconds(isFollowing ? startFollowingTimeout : 0);
        for (int i = 0; i < transform.childCount; i++)
        {
            Adult adult = transform.GetChild(i).GetComponent<Adult>();
            adult.GetComponent<AICharacterControl>().SetTarget(isFollowing ? FindObjectOfType<ThirdPersonUserControl>().transform : adult.GetSpawnTransform());
        }
    }
}
