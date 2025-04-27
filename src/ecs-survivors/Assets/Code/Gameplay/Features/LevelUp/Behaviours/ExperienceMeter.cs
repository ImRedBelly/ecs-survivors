using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.LevelUp.Behaviours
{
    public class ExperienceMeter : MonoBehaviour
    {
        [SerializeField] private Slider progressBar;
        [SerializeField] private Image fillImage;

        public void SetExperience(float heroExperience, float experienceLevelUp)
        {
            fillImage.type = Image.Type.Tiled;
            progressBar.value = heroExperience / experienceLevelUp;
        }
    }
}