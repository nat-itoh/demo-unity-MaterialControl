using UnityEngine;
using UnityEngine.UI;

namespace Project.MaterialControl
{

    /// <summary>
    /// Mesh 用のマテリアルコントローラ
    /// </summary>
    public abstract class UIhMaterialController<T> : MaterialControllerBase<T>
        where T : MaterialHandler
    {

        [SerializeField] private Image _image = null;


        protected override void ApplyMaterial()
        {
            if (_image != null && _handler != null)
            {
                _handler.OnApplayMaterial(_image);
            }
        }

        protected override void OnValidate()
        {
            if (_image == null)
                _image = GetComponent<Image>();
            base.OnValidate();
        }
    }
}