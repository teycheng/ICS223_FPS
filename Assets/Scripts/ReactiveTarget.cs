using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit() {
        WanderingAI enemyAI = GetComponent<WanderingAI> ();
        if (enemyAI != null) {
            enemyAI.ChangeState (EnemyStates.dead);
        }
        StartCoroutine (Die ());
    }

    private IEnumerator Die() {
        // Enemy falls over and disappears after two seconds
        iTween.RotateAdd (this.gameObject, new Vector3 (-75, 0, 0), 1);
        yield return new WaitForSeconds (2);
        Destroy (this.gameObject);
    }
}
