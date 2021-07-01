//using Unity.Entities;
//using Unity.Transforms;
//using Unity.Mathematics;
//using Unity.Jobs;

//public class PlayerMoveSystem : SystemBase
//{
//    protected override void OnUpdate()
//    {
//        float deltaTime = Time.DeltaTime;

//        Entities.ForEach((ref Translation pos, in MoveData moveData) =>
//        {
//            float3 normalizeDir = math.normalizesafe(moveData.direction);
//            pos.Value += normalizeDir * moveData.speed * deltaTime;

//        }).Schedule();
//    }
//}
