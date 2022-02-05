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
    private Spawnpj spawn;
    public GameObject[] puntos;
    private Vector3 place;
    private Vector3 vacio=new Vector3(0,0,0);
    private Vector3 point;

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
        puntos = GameObject.FindGameObjectsWithTag("Spawnpj");
        foreach (GameObject spawnpj in puntos)
        {
            spawn=spawnpj.GetComponent<Spawnpj>();
            place = spawn.spawnpj();
            if (place != vacio)
            {
                point = place;
                Debug.Log(point);
            }
        }
        
        _player.transform.position = point;
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
