using Unity.Entities;
using UnityEngine;

public class TestAuthoring : MonoBehaviour
{
    public float AValue;
    public int BValue;


    public int OtherCount;

    class Backer : Baker<TestAuthoring>
    {
        public override void Bake(TestAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new Test_AA
            {
                Value = authoring.AValue,
                dir = 1
            });

            DynamicBuffer<Test_BB> buffer = AddBuffer<Test_BB>(entity);
            for (int i = 0; i < 8; i++)
            {
                buffer.Add(new Test_BB() { Value = authoring.BValue }) ;
            }

            for (int i = 0; i < authoring.OtherCount; i++)
            {
                Entity e = CreateAdditionalEntity(TransformUsageFlags.Dynamic, entityName: $"Solider A {i}");
                AddComponent(e, new Test_CC { Value = authoring.BValue ,dir = 1});
            }
        }
    }

}