using Unity.Entities;
using UnityEngine;

public class TestCubeSpawnerAuthoring : MonoBehaviour
{
    public GameObject CubePrefab;
    public bool spwan;
    public class Baker : Baker<TestCubeSpawnerAuthoring>
    {
        public override void Bake(TestCubeSpawnerAuthoring authoring)
        {
            Entity entityPrefab = GetEntity(authoring.CubePrefab, TransformUsageFlags.Dynamic);

            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent<Test_CubePrefab>(entity, new Test_CubePrefab() { CubePrefab = entityPrefab });
            SetComponentEnabled<Test_CubePrefab>(entity, authoring.spwan);
        }
    }
}