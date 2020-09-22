using UnityEngine;
using UnityEngine.UI;

namespace Actor
{
    public class HUDController : MonoBehaviour
    {
        public Slider shieldChargeBar;

        public void SetShieldCharge(float charge)
        {
            charge = Mathf.Clamp01(charge);

            shieldChargeBar.value = charge;
        }
    }
}
