using UnityEngine;

namespace Project.MaterialControl
{

    /// <summary>
    /// Mesh 用のマテリアルコントローラ
    /// </summary>
    public abstract class MeshMaterialController<T> : MaterialControllerBase<T>
        where T : MaterialHandler
    {

        [SerializeField] private Renderer _renderer = null;


        protected override void ApplyMaterial()
        {
            if (_renderer != null && _handler != null)
            {
                _handler.OnApplayMaterial(_renderer);
            }
        }

        protected override void OnValidate()
        {
            if (_renderer == null)
                _renderer = GetComponent<Renderer>();
            base.OnValidate();
        }
    }
}