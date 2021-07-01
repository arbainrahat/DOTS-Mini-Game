using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;

public class DestroyEntity : SystemBase
{
    public static bool entityDestroy = false;
  //  public static EntityManager entityManager;
    private static Entity destEntity;

    EndSimulationEntityCommandBufferSystem endSimulationEntityCommandBufferSystem;

    protected override void OnCreate()
    {
       // entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        endSimulationEntityCommandBufferSystem = World.GetExistingSystem<EndSimulationEntityCommandBufferSystem>();
        entityDestroy = false;
    }

    protected override void OnUpdate()
    {
        var ecb = endSimulationEntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();
        if (entityDestroy == true)
        {
            Debug.Log("Destroying Entity");
            World.DefaultGameObjectInjectionWorld.EntityManager.DestroyEntity(destEntity);
            entityDestroy = false;
            Score.scorePoint = true;
        }
        //Entities.ForEach(( int entityInQueryIndex, in Entity entity) =>
        //{
        //    if (entityDestroy == true)
        //    {
        //        // entityManager.DestroyEntity(destEntity);
        //        Debug.Log("Destroy Entity");
        //      //  ecb.DestroyEntity(entityInQueryIndex, destEntity);
        //        entityDestroy = false;
        //        Score.scorePoint = true;
        //    }

        //}).Schedule();

        endSimulationEntityCommandBufferSystem.AddJobHandleForProducer(this.Dependency);
    }

    public static void GetEntity(Entity entity)
    {
        destEntity = entity;
    }

  
}
