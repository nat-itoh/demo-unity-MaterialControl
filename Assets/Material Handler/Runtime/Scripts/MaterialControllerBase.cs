using UnityEngine;

// [REF]
//  qiita: 3Dオブジェクトの残像処理 https://qiita.com/madoramu_f/items/fada99645cd03fd7f515
//  UnityIndies: マテリアル、理解してないとすぐにメモリリーク https://www.create-forever.games/unity-material-memory-leak/

namespace Project.MaterialControl {

    /// <summary>
    /// マテリアルの操作を行うコンポーネント．
    /// </summary>
    public abstract class MaterialControllerBase<T> : MonoBehaviour
        where T : MaterialHandler {

        [SerializeField] Shader _shader = null;
        protected T _handler = null;

        [SerializeField] float _rate;

        /// <summary>
        /// 対象マテリアル．
        /// </summary>
        public T Handler => _handler;

        /// <summary>
        /// マテリアル変数を一括操作するためのプロパティ．
        /// </summary>
        public float Rate {
            get => _rate;
            set {
                _rate = value;
                if (_handler != null) {
                    _handler.Rate = _rate;
                }
            }
        }


        /// ----------------------------------------------------------------------------
        // Lifecycle Events

        private void Awake() {
            _handler = CreateHandler(_shader);
            ApplyMaterial();

            _handler.Rate = _rate;
        }

        private void OnDestroy() {
            _handler?.Dispose();
        }

        protected virtual void OnValidate() {
            if (_handler != null) {
                _handler.Rate = _rate;
            }
            if (_shader == null) _shader = FindShader();
        }


        /// ----------------------------------------------------------------------------
        // Protected Method 

        /// <summary>
        /// ハンドラーを生成する．
        /// </summary>
        protected abstract T CreateHandler(Shader shader);

        /// <summary>
        /// 対象シェーダーを取得する．
        /// </summary>
        protected abstract Shader FindShader();

        /// <summary>
        /// マテリアルを適用する（派生クラスで実装）
        /// </summary>
        protected abstract void ApplyMaterial();
    }

}

