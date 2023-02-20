using System.Collections;
using System;
using UnityEngine;
using Unity.Entities;

public class PlayerShoot : ComponentSystem
{
    private EntityQuery _shootQuery;

    protected override void OnCreate()
    {
        _shootQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<ShootData>(),
            ComponentType.ReadOnly<PlayerInputData>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_shootQuery).ForEach(
           (Entity entity, PlayerInputData input, ref InputData inputData) =>
           {
               if(inputData.shoot > 0f && input.shootAction is IShoot shoot)
               {
                   shoot.Execute();
               }
           });
    }
}
