﻿using System;
using System.Collections.Generic;
using ROSBridgeLib;
using UnityEngine;

public abstract class ROSController : MonoBehaviour
{
    public enum RobotLocomotionState { MOVING, STOPPED }
    public enum RobotLocomotionType { WAYPOINT, DIRECT }

    public delegate void RosStarted(ROSBridgeWebSocketConnection rosBridge);
    public event RosStarted OnRosStarted;

    public RobotLocomotionState CurrentRobotLocomotionState { get; protected set; }
    public RobotLocomotionType CurrenLocomotionType { get; protected set; }
    public RobotConfigFile RobotConfig;

    protected bool _robotModelInitialised;
    protected ROSBridgeWebSocketConnection _rosBridge;
    protected List<GeoPointWGS84> Waypoints;

    protected virtual void OnApplicationQuit()
    {
        StopROS();
    }

    protected abstract void StartROS();

    /// <summary>
    /// Disconnects from rosbridge.
    /// </summary>
    protected virtual void StopROS()
    {
        _rosBridge.Disconnect();
    }

    protected virtual void LostConnection()
    {
        RobotMasterController.Instance.RobotLostConnection(this);
        StopROS();
    }

    /// <summary>
    /// Disconnects from rosbridge and destroys robot gameobject.
    /// </summary>
    public void Destroy()
    {
        StopROS();
        Destroy(gameObject);
    }

    public abstract void MoveDirect(Vector2 movementCommand);

    public abstract void MoveToPoint(GeoPointWGS84 point);

    public abstract void MovePath(List<GeoPointWGS84> waypoints);

    public abstract void PausePath();

    public abstract void ResumePath();

    public abstract void StopRobot();

    public abstract void OnSelected();

    public abstract void OnDeselected();

    public virtual void InitialiseRobot(ROSBridgeWebSocketConnection rosBridge, RobotConfigFile robotConfig)
    {
        _rosBridge = rosBridge;
        _rosBridge.OnDisconnect += clean => { if (!clean) LostConnection(); };
        RobotConfig = robotConfig;
        StartROS();
        if (OnRosStarted != null)
            OnRosStarted(rosBridge);

        /*
        if (Param.has("robot_description"))
        {
            string robotDescription = "";
            Debug.Log("Generating robot from robot description");
            Param.get("robot_description", ref robotDescription);
            GenerateRobot(robotDescription);
        }
        else
            Debug.Log("---No robot description available - could not automatically generate robot---");
        _robotModelInitialised = true;
        */
    }

    private void GenerateRobot(string robotDescription) {
        //_robot = RobotUrdfUtility.GenerateRobotGameObjectFromDescription(robotDescription, _alwaysGenerateRobot).transform;
    }
}
