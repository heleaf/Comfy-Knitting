using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Tilemap ground;
    private Movement controls;
    // Start is called before the first frame update
    private void Awake()
    {
        controls = new Movement();
    }

    private void OnEnable(){
      controls.Enable();
    }

    private void OnDisable(){
      controls.Disable();
    }
    // Update is called once per frame
    void Start()
    {
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void Move(Vector2 direction){
        if(CanMove(direction)) transform.position += (Vector3)direction;
    }

    private bool CanMove(Vector2 direction){
        Vector3Int gridPos  = ground.WorldToCell(transform.position + (Vector3)direction);
        if (!ground.HasTile(gridPos)) return false;
        return true;
    }
}
