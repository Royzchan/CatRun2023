using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField, Header("ÉvÉåÉCÉÑÅ[Çì¸ÇÍÇÈ")]
    private GameObject _player;

    private Vector3 _direction;
    // Start is called before the first frame update
    void Start()
    {
        _direction = this.transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = _player.transform.position + _direction;
        this.transform.position = new Vector3(pos.x, this.transform.position.y, pos.z);
    }
}
