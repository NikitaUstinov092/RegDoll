using GameSystem.Scripts.GameSystem;
using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
public class PhysicalBodyPart : MonoBehaviour, IGameStartListener, IGameFixedUpdateListener
{
   [SerializeField] 
   private Transform _target;
   
   private ConfigurableJoint _joint;
   private Quaternion _startRotation;

   void IGameStartListener.OnStartGame()
   {
      _joint = GetComponent<ConfigurableJoint>();
      _startRotation = transform.localRotation;
   }
   
   void IGameFixedUpdateListener.OnFixedUpdate(float deltaTime)
   {
      _joint.targetRotation = Quaternion.Inverse(_target.localRotation) * _startRotation;
   }
}
