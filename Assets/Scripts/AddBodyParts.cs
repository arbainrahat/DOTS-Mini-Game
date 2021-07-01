using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Jobs;
using Unity.Physics;

public class AddBodyParts : SystemBase
{
    private int spwanCount = 0;
    private int spwanNumber = 0;
    private float takeVal;
  //  public ComponentDataFromEntity<Translation> playerTrans;

    List<Entity> child = new List<Entity>();

    EndSimulationEntityCommandBufferSystem endSimulationEntityCommandBufferSystem;

    protected override void OnCreate()
    {
        endSimulationEntityCommandBufferSystem = World.GetExistingSystem<EndSimulationEntityCommandBufferSystem>();
       // playerTrans = GetComponentDataFromEntity<Translation>(true);
       
    }

    protected override void OnUpdate()
    {    

        var ecb = endSimulationEntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();

        float zPos = takeVal;

        if (DestroyEntity.entityDestroy == true)
        {
            if(spwanNumber == 0)
            {
                zPos = 0;
                spwanNumber++;
                Debug.Log("Spwan Number = " + spwanNumber);
            }

            if (spwanNumber > 0)
            {
                spwanCount = 1;
                zPos += 0.8f;
                takeVal = zPos;
                Debug.Log("zPos = " + zPos);

            }
        }


        if (spwanCount == 1)
        {
            Debug.Log("Generate Child Before");
            Entities.ForEach((int entityInQueryIndex, in PlayerBodyPrefabData playerBodyPrefabData) =>
            {
                

                Entity spwan = ecb.Instantiate(entityInQueryIndex, playerBodyPrefabData.bodyPrefabEntity);


                ecb.AddComponent(entityInQueryIndex, spwan, new Parent { Value = playerBodyPrefabData.parentEntity });

                ecb.AddComponent(entityInQueryIndex, spwan, new LocalToParent { Value = Matrix4x4.Rotate(Quaternion.identity) });

                 ecb.SetComponent(entityInQueryIndex, spwan, new Translation { Value = playerBodyPrefabData.bodyPrefabOffSet * zPos});


            }).ScheduleParallel();
            spwanCount = 0;
            
       }


        endSimulationEntityCommandBufferSystem.AddJobHandleForProducer(this.Dependency);

    }

    
}
