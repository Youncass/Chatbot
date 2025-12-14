using System.IO;
using UnityEngine;

namespace Sources
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private ChatView _cv;

        private AI _ai;

        private void Start()
        {
            string pythonPath = Path.Combine(Application.dataPath, "Sources", "Python", "test2.py");
            _ai = new AI(view: _cv, PythonDll.From(pythonPath));
        }

        private void OnDestroy()
        {
            _ai.Dispose();
        }
    }
}
