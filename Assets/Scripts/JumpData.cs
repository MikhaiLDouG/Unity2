using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class JumpData : ComponentSystem
{
    private EntityQuery _jumpQuery;
   

    protected override void OnCreate()
    {
        _jumpQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<PlayerInputData>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_jumpQuery).ForEach(
           (Entity entity, PlayerInputData input, ref InputData inputData) =>
           {
               if (inputData.jump > 0f && input.jumpAction is IJump jump)
               {
                   jump.Execute();
               }
           });
    }
}
