using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.IO;
using UnityEngine;

namespace Sources
{
    public class PythonDll
    {
        private readonly ScriptEngine _engine;
        private readonly ScriptScope _scope;

        private PythonDll(string path)
        {
            _engine = Python.CreateEngine();
            var paths = _engine.GetSearchPaths();

            paths.Add(Path.Combine(Application.dataPath, "Packages", "IronPython.StdLib.3.4.2", "content", "lib"));

            _engine.SetSearchPaths(paths);
            _scope = _engine.ExecuteFile(path);
        }

        public static PythonDll From(string path) => new PythonDll(path);

        public dynamic GetVariable(string name) => _scope.GetVariable(name);
    }
}
