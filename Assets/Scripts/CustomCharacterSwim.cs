using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    [AddComponentMenu("Corgi Engine/Character/Abilities/CustomCharacter Swim")]
    public class CustomCharacterSwim : CharacterSwim
    {
        [Tooltip("If this is true, will get input from an input source, otherwise you'll have to set it via SetHorizontalMove()")]
        public bool ReadInput = true;

        [Header("Swim")]
        public float SwimSpeed = 3f;

        protected float _horizontalMovement;
        protected float _verticalMovement;

        [Range(0f, 1f)]
        [Tooltip("How much air control the player has")]
        public float AirControl = 1f;

        public float WaterColliderTriggerHeight;

        public ParticleSystem waterParticle;

        protected override void HandleInput()
        {
            if (!ReadInput)
            {
                return;
            }

            _horizontalMovement = _horizontalInput;
            _verticalMovement = _verticalInput;

            if ((AirControl < 1f) && !_controller.State.IsGrounded)
            {
                _horizontalMovement = Mathf.Lerp(1, _horizontalInput, AirControl);
            }

        }

        protected void Update()
        {
            if (InWater)
            {
                FindObjectOfType<CharacterHorizontalMovement>().AbilityPermitted = false;
                Swim();

                // Update character direction based on movement
                if (_horizontalMovement > 0)
                {
                    // Face right
                    transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                }
                else if (_horizontalMovement < 0)
                {
                    // Face left
                    transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                }

            }
            else
            {
                // Handle other cases here
            }
        }

        public override void EnterWater()
        {
            waterParticle.Play();
            base.EnterWater();
        }
        protected override void Swim()
        {
            // Apply swim movement
            Vector2 swimDirection = new Vector2(_horizontalMovement, _verticalMovement).normalized;
            Vector3 swimVelocity = new Vector3(swimDirection.x * SwimSpeed, swimDirection.y * SwimSpeed, 0f);
            _controller.SetHorizontalForce(swimVelocity.x);
            _controller.SetVerticalForce(swimVelocity.y);

            // Check for vertical restriction
              if (_verticalMovement > 0 && transform.position.y > WaterColliderTriggerHeight)
              {
                // Restrict vertical movement above water collider height
                _controller.SetVerticalForce(Mathf.Sqrt(2f * SwimHeight * Mathf.Abs(_controller.Parameters.Gravity)));
            }
           // base.Swim();

        }

        public override void ExitWater()
        {
            // Face right
            waterParticle.Stop();
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            FindObjectOfType<CharacterHorizontalMovement>().AbilityPermitted = true;
            base.ExitWater();
        }

        // Add methods for handling water entry and exit effects if needed

        private bool IsPlayerMoving()
        {
            // Check if the player's velocity is greater than a small threshold
            return (_horizontalMovement != 0 || _verticalMovement != 0);
        }
    }
}
