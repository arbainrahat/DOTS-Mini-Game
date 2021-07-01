using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct PlayerBodyPrefabData : IComponentData
{
    public Entity bodyPrefabEntity;
    public Entity parentEntity;

    public float3 bodyPrefabOffSet;
}
