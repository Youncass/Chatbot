using System.IO;
using UnityEngine;

namespace Sources
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private ChatView _cv;
        [SerializeField] private OptionsMenu _om;

        private AI _ai;

        private void Start()
        {
            string pythonPath = Path.Combine(Application.dataPath, "Sources", "Python", "test2.py");
            _ai = new AI(view: _cv, personality: _om, PythonDll.From(pythonPath));
        }

        private void OnDestroy()
        {
            _ai.Dispose();
        }
    }
}
