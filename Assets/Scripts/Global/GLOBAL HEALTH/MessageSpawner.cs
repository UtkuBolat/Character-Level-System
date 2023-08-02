using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.System.MessageSystem
{
    public class MessageSpawner : MonoBehaviour
    {
        [SerializeField]
        private Vector2 initialPosition;

        [SerializeField]
        private GameObject messagePrefab;

        public void SpawnMessage(string msg)
        {
            var msgObj = Instantiate(messagePrefab, GetSpawnPosition(), Quaternion.identity);
            var inGameMessage = msgObj.GetComponent<FloatingMessage>();
        }
        private Vector3 GetSpawnPosition()
        {
            return transform.position + (Vector3) initialPosition;
        }
    }
}
