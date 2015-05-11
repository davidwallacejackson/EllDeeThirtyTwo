using UnityEngine;
using System.Collections;

namespace LD32
{
    public class Sparks : BaseBehaviour
    {
        const float TIMEOUT = 4f;

        static GameObject prefab
        {
            get
            {
                return Resources.Load<GameObject>("Sparks");
            }
        }

        #region Unity Hooks
        public override void Awake()
        {
            base.Awake();

            StartCoroutine(Timeout());
        }
        #endregion

        #region Public API
        public static void Instantiate(Vector2 location, Vector2 normal)
        {
            var sparks = Instantiate<GameObject>(
                prefab).GetComponentInChildren<Sparks>();
            sparks.transform.position = location;
            sparks.transform.LookAt(location + normal, Vector3.right);
        }
        #endregion

        #region Internal Methods
        IEnumerator Timeout()
        {
            yield return new WaitForSeconds(TIMEOUT);
            Destroy(this.gameObject);
        }
        #endregion

        #region Event Callbacks
        #endregion
    }
}