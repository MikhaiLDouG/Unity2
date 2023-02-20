using System;
using UnityEngine;
using Unity.Entities;

public class AnimMove : ComponentSystem
{
    private EntityQuery _moveQuery;
    protected override void OnCreate()
    {
        _moveQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(), ComponentType.ReadOnly<Animator>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_moveQuery).ForEach(
         (Entity entity, Animator animator, ref InputData inputData) =>
         {
             animator.SetFloat("velocity", Math.Abs(inputData.move.x + inputData.move.y));
         });
    }
}
