// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class InputMaster : InputActionAssetReference
{
    public InputMaster()
    {
    }
    public InputMaster(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // Player
        m_Player = asset.GetActionMap("Player");
        m_Player_Movement = m_Player.GetAction("Movement");
        m_Player_KeyMovement = m_Player.GetAction("KeyMovement");
        m_Player_Reset = m_Player.GetAction("Reset");
        // Camera
        m_Camera = asset.GetActionMap("Camera");
        m_Camera_MouseMove = m_Camera.GetAction("MouseMove");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_Player = null;
        m_Player_Movement = null;
        m_Player_KeyMovement = null;
        m_Player_Reset = null;
        m_Camera = null;
        m_Camera_MouseMove = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Player
    private InputActionMap m_Player;
    private InputAction m_Player_Movement;
    private InputAction m_Player_KeyMovement;
    private InputAction m_Player_Reset;
    public struct PlayerActions
    {
        private InputMaster m_Wrapper;
        public PlayerActions(InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement { get { return m_Wrapper.m_Player_Movement; } }
        public InputAction @KeyMovement { get { return m_Wrapper.m_Player_KeyMovement; } }
        public InputAction @Reset { get { return m_Wrapper.m_Player_Reset; } }
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
    }
    public PlayerActions @Player
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new PlayerActions(this);
        }
    }
    // Camera
    private InputActionMap m_Camera;
    private InputAction m_Camera_MouseMove;
    public struct CameraActions
    {
        private InputMaster m_Wrapper;
        public CameraActions(InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseMove { get { return m_Wrapper.m_Camera_MouseMove; } }
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
    }
    public CameraActions @Camera
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new CameraActions(this);
        }
    }
}
