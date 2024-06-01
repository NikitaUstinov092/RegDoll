using UnityEngine;

public class AnimatedSignals : MonoBehaviour
{
  [SerializeField]
  private PhysicMaterial _defaultFriction;
  
  [SerializeField]
  private PhysicMaterial _zeroFriction;

  [SerializeField] 
  private Collider _leftCollider;
  
  [SerializeField] 
  private Collider _rightCollider;
  
  
  public void SetLeftFriction()
  {
    _leftCollider.material = _defaultFriction;
    _rightCollider.material = _zeroFriction;
  }
  
  public void SetRightFriction()
  {
    _leftCollider.material = _zeroFriction;
    _rightCollider.material = _defaultFriction;
  }
}
