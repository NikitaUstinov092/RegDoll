using GameSystem.Scripts.GameSystem;
using UnityEngine;

public class MoveComponent : MonoBehaviour, IGameFixedUpdateListener
{
   [SerializeField] 
   private Transform _target;
   
   [SerializeField] 
   private Transform _pelvis;

   [SerializeField] 
   private ConfigurableJoint _joint;

   void IGameFixedUpdateListener.OnFixedUpdate(float deltaTime)
   {
      var targetDistance = _target.position - _pelvis.position;
      var xz = new Vector3(targetDistance.x, 0, targetDistance.z);
      var rotation = Quaternion.LookRotation(xz);
      _joint.targetRotation = Quaternion.Inverse(rotation);
   }
}
