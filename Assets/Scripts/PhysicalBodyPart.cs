using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
public class PhysicalBodyPart : MonoBehaviour, IGameStartListener, IGameFixedUpdateListener
{
   [SerializeField] 
   private Transform _target;
   
   private ConfigurableJoint _joint;
   private Quaternion _startRotation;

   //Cтарт
   void IGameStartListener.OnStartGame() 
   {
      _joint = GetComponent<ConfigurableJoint>();
      _startRotation = transform.localRotation;
   }
   
   //Фикст апдейт
   void IGameFixedUpdateListener.OnFixedUpdate(float deltaTime)
   {
      _joint.targetRotation = Quaternion.Inverse(_target.localRotation) * _startRotation;
   }
}
