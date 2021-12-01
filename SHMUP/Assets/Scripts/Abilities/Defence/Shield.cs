using System;
using System.Collections;
using Actor;
using UnityEngine;

namespace Abilities.Defence
{
    public class Shield : MonoBehaviour, IAbility
    {
        [Tooltip("In seconds per second.")] public float shieldRechargeRate = 1.5f;
        public float maxShieldDuration = 5f;
        public bool connectToHUD;

        public GameObject shieldObject;

        private float _durationLeft;

        private Action<float> shieldChargeBarSetter;

        public void Activate()
        {
            if(shieldObject.activeSelf)
                return;
            
            shieldObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(ShieldDepleter());
        }

        public void Deactivate()
        {
            if(!shieldObject.activeSelf)
                return;

            shieldObject.SetActive(false);
            StopAllCoroutines();
            StartCoroutine(ShieldRecharger());
        }

        public void Equip(Transform slot, GameObject owner)
        {
            shieldObject.SetActive(false);
            transform.parent = slot;

            _durationLeft = maxShieldDuration;

            if (connectToHUD)
            {
                shieldChargeBarSetter = owner.GetComponent<HUDController>().SetShieldCharge;
                shieldChargeBarSetter?.Invoke(_durationLeft / maxShieldDuration);
            }
        }

        private IEnumerator ShieldDepleter()
        {
            while (_durationLeft > 0)
            {
                _durationLeft -= Time.deltaTime;
                shieldChargeBarSetter?.Invoke(_durationLeft / maxShieldDuration);
                yield return null;
            }
            Deactivate();
        }

        private IEnumerator ShieldRecharger()
        {
            while (_durationLeft < maxShieldDuration)
            {
                _durationLeft += shieldRechargeRate * Time.deltaTime;
                shieldChargeBarSetter?.Invoke(_durationLeft / maxShieldDuration);
                yield return null;
            }

            _durationLeft = maxShieldDuration;
        }
    }
}
