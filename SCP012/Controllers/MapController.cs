namespace SCP012.Controllers;

using Exiled.API.Enums;
using Exiled.API.Features;
using MapEditorReborn.API;
using MapEditorReborn.API.Enums;
using MapEditorReborn.API.Extensions;
using MapEditorReborn.API.Features;
using MapEditorReborn.API.Features.Objects;
using MapEditorReborn.API.Features.Serializable;
using UnityEngine;

internal class MapController
{
    internal static SchematicObject SCP012Containment;
    internal static PrimitiveObject SCP012Object;

    internal static bool InitializeMap()
    {
        SpawnDoor(ObjectType.HczDoor, new(1.900002f, 0f, 1.674999f), RoomType.LczToilets);

        ObjectSpawner.SpawnTeleport(new SerializableTeleport { Scale = new(1f, 1f, 1f), Position = new(0.01828003f, 14.21185f, -10.1787f), RoomType = RoomType.LczToilets, ObjectId = 2, ParentId = 36812, Cooldown = 2f });
        ObjectSpawner.SpawnTeleport(new SerializableTeleport { Scale = new(1f, 1f, 1f), Position = new(1.941559f, 1.000001f, 1.359612f), RoomType = RoomType.LczToilets, ObjectId = 1, ParentId = 36812, Cooldown = 2f });

        SCP012Object = ObjectSpawner.SpawnPrimitive(new PrimitiveSerializable { PrimitiveType = PrimitiveType.Cube, Color = "#FFFFFF55", Position = new(-2.645027f, 9.446946f, 0.4674072f), RoomType = RoomType.LczToilets, Scale = new(0.05f, 0.7f, 0.05f) });

        ObjectSpawner.SpawnSchematic(new SchematicSerializable { SchematicName = "SCP012Room", Position = new(0.05078125f, 13.40859f, -2.941406f), Rotation = new(0f, 270f, 0f), RoomType = RoomType.LczToilets });
        SCP012Containment = ObjectSpawner.SpawnSchematic(new SchematicSerializable { SchematicName = "SCP012Containment", Position = new(0.05000305f, 13.3f, -2.93f), Rotation = new(0f, 270f, 0f), RoomType = RoomType.LczToilets });

        if (SCP012Containment is null || SCP012Object is null)
            return false;

        return true;
    }

    internal static void SpawnDoor(ObjectType objectType, Vector3 position, RoomType roomType)
    => Object.Instantiate(
        objectType.GetObjectByMode(),
        API.GetRelativePosition(position, Room.Get(roomType)),
        API.GetRelativeRotation(Vector3.zero, Room.Get(roomType))
    )
    .AddComponent<DoorObject>()
    .Init(new DoorSerializable
    {
        IsLocked = true,
        DoorHealth = 500000f
    });
}