using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    private Button _btn;
    [SerializeField]
    private List<RoomSpawn> _rs;
    [SerializeField]
    private GameObject _spawnPoint;
    [SerializeField]
    private GameObject _player;

    private void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(RespawnOnClick);
        GameEvent.OnPlayerRespawn += OnPlayerRespawn;
    }

    private void OnPlayerRespawn()
    {
        RespawnOnClick();
    }

    private void RespawnOnClick()
    {
        _player.transform.position = _spawnPoint.transform.position;
        Player player = _player.GetComponent<Player>();
        player.SetMaximumHealth();

        List<Spawned> _spawned = new List<Spawned>(FindObjectsOfType<Spawned>());
        for (int i = 0; i < _spawned.Count; i++)
        {
            Destroy(_spawned[i].gameObject);
        }
        for (int i = 0; i < _rs.Count; i++)
            _rs[i].Respawn();
    }
}
