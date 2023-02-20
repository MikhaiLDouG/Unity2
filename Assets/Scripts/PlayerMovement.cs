using System.Collections;
using System;
using UnityEngine;
using Unity.Entities;

public class PlayerMovement : ComponentSystem
{
    private EntityQuery _moveQuery;

    protected override void OnCreate()
    {
        _moveQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(), ComponentType.ReadOnly<MoveData>(),
            ComponentType.ReadOnly<Transform>(), ComponentType.ReadOnly<PlayerInputData>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_moveQuery).ForEach(
           (Entity entity, Transform transform, ref MoveData move, ref InputData inputData) =>
           {
               if (Math.Abs(inputData.move.x) > 0 || Math.Abs(inputData.move.y) > 0)
               {
                   var pos = transform.position;
                   pos += new Vector3(inputData.move.x * move.Speed, 0, inputData.move.y * move.Speed);
                   transform.position = pos;

                   float axis = Mathf.Atan2(inputData.move.x, inputData.move.y) * Mathf.Rad2Deg;
                   transform.eulerAngles = new Vector3(0, axis, 0);
               }
           });
    }
}
