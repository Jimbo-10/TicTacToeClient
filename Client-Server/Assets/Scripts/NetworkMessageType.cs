using UnityEngine;

public static class NetworkMessageType
{
    public const string CreateAccount = "CreateAccount";
    public const string Login = "Login";
    public const string CreateOrJoinRoom = "CreateOrJoinRoom";
    public const string RoomJoined = "RoomJoined";
    public const string RoomWaiting = "RoomWaiting";
    public const string RoomStart = "RoomStart";
    public const string LeaveRoom = "LeaveRoom";
    public const string PlayerAction = "PlayerAction";
}

